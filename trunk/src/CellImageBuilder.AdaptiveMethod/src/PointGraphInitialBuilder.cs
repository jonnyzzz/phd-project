using System;
using System.Collections.Generic;
using System.Reflection;
using System.Text;
using DSIS.IntegerCoordinates;

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
                                                                     typeof (IIntegerCoordinateSystemInfo));
      return (IGraphBuilder) Activator.CreateInstance(ass.GetType("GenerateCodeImpl" + dim));
    }

    private static string DoGenerateCode(int dim)
    {
      return
        string.Format(
          @" using {0};
                using {1};
                public class GenerateCodeImpl{3} : IGraphBuilder {{
                   public int Dimension {{ get {{ return {3}; }} }}

                   public IGraphBuilderProcessor Init(IIntegerCoordinateSystemInfo info) {{
                       return new Processor(info);
                   }}                   

                   private class Processor : IGraphBuilderProcessor {{
                       {2}

                       public Processor(IIntegerCoordinateSystemInfo info) {{
                          {4}
                       }}

                       public void BuildGraph(PointGraph graph, double[] point) {{
                       }}
                   }}
                }}
",
          typeof (IGraphBuilder).Namespace,
          typeof (IIntegerCoordinateSystemInfo).Namespace,
          BuildPrivateFields(dim),
          dim,
          BuildProcessorConstructor(dim));
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
  }
}