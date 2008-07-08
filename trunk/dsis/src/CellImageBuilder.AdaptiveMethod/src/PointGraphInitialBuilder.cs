using System;
using System.Collections.Generic;
using System.Reflection;
using System.Text;
using DSIS.BoxIterators.Generator;
using DSIS.IntegerCoordinates;
using DSIS.Utils;

namespace DSIS.CellImageBuilder.AdaptiveMethod
{
  public class PointGraphInitialBuilder
  {
    private readonly Dictionary<int, IGraphBuilder> myBuilders = new Dictionary<int, IGraphBuilder>();

    public PointGraphInitialBuilder()
    {
      myBuilders[1] = new GraphBuildOneDiminsion();
    }

    public IGraphBuilder BuildGraph(int dim)
    {
      lock (myBuilders)
      {
        IGraphBuilder bld;
        if (!myBuilders.TryGetValue(dim, out bld))
        {
          bld = GenerateCode(dim);
          myBuilders[dim] = bld;
        }

        return bld;
      }
    }

    protected static IGraphBuilder GenerateCode(int dim)
    {
      Assembly ass =
        CodeCompiler.CodeCompiler.CreateCompiler().CompileCSharpCode(DoGenerateCode(dim), typeof (IGraphBuilder),
                                                                     typeof (IIntegerCoordinateSystem));
      return (IGraphBuilder) Activator.CreateInstance(ass.GetType("GenerateCodeImpl" + dim));
    }

    private static string DoGenerateCode(int dim)
    {
      return
        string.Format(
          @" using {0};
             using {1};
             using System.Collections.Generic;
                public class GenerateCodeImpl{3} : IGraphBuilder {{
                   public int Dimension {{ get {{ return {3}; }} }}

                   public IGraphBuilderProcessor Init(IIntegerCoordinateSystem info) {{
                       return new Processor(info);
                   }}                   

                   private class Processor : IGraphBuilderProcessor {{
                       {2}

                       public Processor(IIntegerCoordinateSystem info) {{
                          {4}
                       }}

                       public IEnumerable<PointGraphEdge> BuildGraph(PointGraph graph, double[] point) {{
                          {5}
                       }}
                   }}
                }}
",
          typeof (IGraphBuilder).Namespace,
          typeof (IIntegerCoordinateSystem).Namespace,
          BuildPrivateFields(dim),
          dim,
          BuildProcessorConstructor(dim),
          BuildGeneratorCode(dim));
    }

    private static string BuildPrivateFields(int dim)
    {
      StringBuilder sb = new StringBuilder();
      for (int i = 0; i < dim; i++)
      {
        sb.AppendFormat("  private double myEps{0};", i);
        sb.AppendFormat("  private double myEpsHalf{0};", i);
      }
      return sb.ToString();
    }

    private static string BuildProcessorConstructor(int dim)
    {
      StringBuilder sb = new StringBuilder();
      for (int i = 0; i < dim; i++)
      {
        sb.AppendFormat("  myEps{0} = info.CellSize[{0}];", i);
        sb.AppendFormat("  myEpsHalf{0} = info.CellSizeHalf[{0}];", i);
      }
      return sb.ToString();
    }

    private static int[] FillArray(int dim, int v)
    {
      int[] r = new int[dim];
      for (int i = 0; i < dim; i++)
        r[i] = v;
      return r;
    }

    private static string ArrayToString(IEnumerable<int> v)
    {
      string s = String.Empty;
      foreach (int i in v)
      {
        s += i;
      }
      return s;
    }

    private delegate string Element(int i);

    private static string EnumerateArray(int dim, Element el)
    {
      StringBuilder sb = new StringBuilder();
      for (int i = 0; i < dim; i++)
      {
        sb.AppendFormat("{1}{0}", el(i), i != 0 ? ", " : "");
      }
      return sb.ToString();
    }

    private static bool IsArc(int[] from, int[] to)
    {
      int diffs = 0;
      for (int i = 0; i < to.Length && diffs < 2; i++)
      {
        if (from[i] != to[i])
          diffs++;
      }
      return diffs == 1;
    }

    private static string BuildGeneratorCode(int dim)
    {
      StringBuilder sb = new StringBuilder();

      for (int i = 0; i < dim; i++)
      {
        sb.AppendFormat("double myLeft{0} = point[{0}];", i);
        sb.AppendLine();
        sb.AppendFormat("double myRight{0} = myLeft{0} + myEps{0};", i);
        sb.AppendLine();
        sb.AppendFormat("double myMiddle{0} = myLeft{0} + myEpsHalf{0};", i);
        sb.AppendLine();
      }

      int[] zeros = FillArray(dim, 0);
      int[] ones = FillArray(dim, 1);

      foreach (int[] pt in BoxIteratorGenerator<int>.GenerateIterator(dim).EnumerateBox(zeros, ones, new int[dim]))
      {
        sb.AppendFormat("PointGraphNode node{0} = graph.CreateNodeNoCopy({1});",
                        ArrayToString(pt),
                        EnumerateArray(dim, delegate(int i) { return (pt[i] == 0 ? "myLeft" : "myRight") + i; })
          );
        sb.AppendLine();
      }

      sb.AppendFormat("PointGraphNode nodeMiddle = graph.CreateNodeNoCopy({0});",
                      EnumerateArray(dim, delegate(int i) { return "myMiddle" + i; }));

      sb.AppendLine();
      sb.AppendLine();
      sb.AppendLine();

      AddedEdgesHash hash = new AddedEdgesHash();

      sb.AppendLine("return new PointGraphEdge[] {");
      foreach (int[] pt in BoxIteratorGenerator<int>.GenerateIterator(dim).EnumerateBox(zeros, ones, new int[dim]))
      {
        sb.AppendFormat("graph.AddEdge(nodeMiddle, node{0}),", ArrayToString(pt));
        sb.AppendLine();

        foreach (int[] pt2 in BoxIteratorGenerator<int>.GenerateIterator(dim).EnumerateBox(zeros, ones, new int[dim]))
        {
          if (IsArc(pt, pt2) && !hash.HasArc(pt, pt2))
          {
            sb.AppendFormat("graph.AddEdge(node{1}, node{0}),", ArrayToString(pt), ArrayToString(pt2));
            sb.AppendLine();
            hash.AddEdge(pt, pt2);
          }
        }
      }
      sb.AppendLine("};");

      return sb.ToString();
    }

    private class AddedEdgesHash
    {
      private readonly Hashset<int[]> data = new Hashset<int[]>(ArrayEqualityComparer<int>.INSTANCE);

      public void AddEdge(int[] from, int[] to)
      {
        data.Add(MakeKey(from, to));
        data.Add(MakeKey(to, from));
      }

      public bool HasArc(int[] from, int[] to)
      {
        return data.Contains(MakeKey(from, to));
      }

      private static int[] MakeKey(int[] from, int[] to)
      {
        int[] key = new int[from.Length + to.Length];
        for (int i = 0; i < from.Length; i++)
        {
          key[i] = from[i];
        }
        for (int i = 0; i < to.Length; i++)
        {
          key[from.Length + i] = to[i];
        }
        return key;
      }
    }
  }
}