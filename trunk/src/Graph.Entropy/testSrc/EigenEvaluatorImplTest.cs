using System;
using System.Collections.Generic;
using System.Text;
using DSIS.Core.Coordinates;
using DSIS.Core.Util;
using DSIS.Graph.Abstract;
using DSIS.Graph.Entropy.Impl.Eigen;
using DSIS.Graph.Entropy.Impl.Util;
using DSIS.IntegerCoordinates.Impl;
using NUnit.Framework;

namespace DSIS.Graph.Entropy
{
  [TestFixture]
  public class EigenEvaluatorImplTest : GraphBaseTest
  {
    private const double EPS = 1e-4;

    public void DoTest_Full_n(int n)
    {
      DoTest(Math.Log(n)/Math.Log(2), delegate(IGraph<IntegerCoordinate> graph)
                                        {
                                          for (int i = 0; i < n; i++)
                                            for (int j = 0; j < n; j++)
                                              AddEdge(graph, i, j);
                                        });
    }


    private static void DoTest(double v, BuildGraph bg)
    {
      TarjanGraph<IntegerCoordinate> graph = DoBuildGraph(bg);
      IGraphStrongComponents<IntegerCoordinate> components = graph.ComputeStrongComponents(NullProgressInfo.INSTANCE);

      EntropyController controller = new EntropyController(graph, components);
      new EntropyEvaluatorImpl().ComputeEntropy(controller, NullProgressInfo.INSTANCE);

      Assert.AreEqual(v, controller.Result, EPS);
    }

    private class EntropyEvaluatorImpl : EigenEntropyEvaluatorImpl<IntegerCoordinate>
    {
    }

    private class EntropyController : IEntropyEvaluatorController<IntegerCoordinate>
    {
      private readonly IGraphStrongComponents<IntegerCoordinate> myComponents;
      private readonly IGraph<IntegerCoordinate> myGraph;
      private double? myResult;

      public EntropyController(IGraph<IntegerCoordinate> graph, IGraphStrongComponents<IntegerCoordinate> components)
      {
        myGraph = graph;
        myComponents = components;
      }

      public double Result
      {
        get { return myResult.Value; }
      }

      #region IEntropyEvaluatorController<IntegerCoordinate> Members

      public bool SubdivideNext(ICellCoordinateSystem<IntegerCoordinate> system)
      {
        throw new NotImplementedException();
      }

      public void SetCoordinateSystem(ICellCoordinateSystem<IntegerCoordinate> system)
      {
      }

      public void OnResult<Q>(double result, IDictionary<IntegerCoordinate, double> measure,
                              IDictionary<Q, double> edges) where Q : PairBase<IntegerCoordinate>
      {
        Assert.AreEqual(null, myResult);
        myResult = result;
      }

      public IGraph<IntegerCoordinate> Graph
      {
        get { return myGraph; }
      }

      public IGraphStrongComponents<IntegerCoordinate> Components
      {
        get { return myComponents; }
      }

      #endregion
    }

    [Test]
    public void Test_01()
    {
      new EntropyEvaluatorImpl();
    }

    [Test]
    public void Test_02()
    {
      DoTest(0, delegate(IGraph<IntegerCoordinate> graph)
                  {
                    AddEdge(graph, 1, 1);
                    AddEdge(graph, 2, 2);
                  });
    }

    [Test]
    public void Test_03()
    {
      DoTest(1, delegate(IGraph<IntegerCoordinate> graph)
                  {
                    AddEdge(graph, 1, 1);
                    AddEdge(graph, 2, 1);
                    AddEdge(graph, 2, 2);
                    AddEdge(graph, 1, 2);
                  });
    }

    [Test]
    public void Test_04()
    {
      DoTest_Full_n(4);
    }

    [Test]
    public void Test_05()
    {
      DoTest_Full_n(5);
    }

    [Test]
    public void Test_06()
    {
      DoTest(0, delegate(IGraph<IntegerCoordinate> graph)
                  {
                    AddEdge(graph, 1, 2);
                    AddEdge(graph, 2, 3);
                    AddEdge(graph, 3, 4);
                    AddEdge(graph, 4, 1);
                  });
    }

    [Test]
    public void Test_07()
    {
      DoTest(0, delegate(IGraph<IntegerCoordinate> graph)
                  {
                    AddEdge(graph, 1, 2);
                    AddEdge(graph, 2, 3);
                    AddEdge(graph, 3, 4);
                    AddEdge(graph, 4, 1);

                    AddEdge(graph, 5, 6);
                    AddEdge(graph, 6, 5);
                  });
    }

    [Test]
    public void Test_08()
    {
      DoTest(0.2250, delegate(IGraph<IntegerCoordinate> graph)
                       {
                         AddEdge(graph, 1, 2);
                         AddEdge(graph, 2, 3);
                         AddEdge(graph, 3, 5);
                         AddEdge(graph, 5, 1);
                         AddEdge(graph, 3, 8);
                         AddEdge(graph, 8, 7);
                         AddEdge(graph, 7, 6);
                         AddEdge(graph, 6, 2);
                       });
    }

    private static void DumpMatrix(IGraph<IntegerCoordinate> graph)
    {
      long? min = null;
      long? max = null;
      foreach (INode<IntegerCoordinate> node in graph.Nodes)
      {
        long v = node.Coordinate.GetCoordinate(0);
        if (min == null || min > v)
          min = v;
        
        if (max == null || max < v)
          max = v;
      }

      long sz = (long)max - (long)min + 1;
      long[][] m = new long[sz][];
      for(int i=0; i<sz; i++)
      {
        m[i] = new long[sz];
        for(int j = 0; j<sz; j++)
        {
          m[i][j] = 0;
        }
      }

      foreach (INode<IntegerCoordinate> node in graph.Nodes)
      {
        long index0 = node.Coordinate.GetCoordinate(0) - min.Value;
        foreach (INode<IntegerCoordinate> edge in graph.GetEdges(node))
        {
          long index1 = edge.Coordinate.GetCoordinate(0) - min.Value;
          m[index0][index1] = 1;
        }
      }

      StringBuilder sb = new StringBuilder();
      sb.Append("[");
      bool f1 = true;
      foreach (long[] longs in m)
      {
        if (!f1)
          sb.Append(",").AppendLine();
        else
          f1 = false;

        bool f2 = true;
        sb.Append("[");
        foreach (long l in longs)
        {
          if (!f2)
            sb.Append(", ");
          else
            f2 = false;
          sb.AppendFormat("{0}", l);
        }
        sb.Append("]");
      }
      sb.Append("]");

      Console.Out.WriteLine(sb);
    }
  }
}