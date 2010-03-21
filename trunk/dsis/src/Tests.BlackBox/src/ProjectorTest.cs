using System;
using System.Collections.Generic;
using System.Linq;
using DSIS.Core.Coordinates;
using DSIS.Graph;
using DSIS.Scheme.Actions;
using DSIS.Scheme.Ctx;
using DSIS.Scheme.Impl;
using DSIS.Scheme.Impl.Tests;
using NUnit.Framework;

namespace DSIS.Tests.BlackBox
{
  public abstract class ProjectorTestBase : SimbolicImageBuildTestBase2
  {
    [Test]
    public void Test_1_3()
    {
      DoTestAssertSame(1, 3);
    }

    [Test]
    public void Test_1_4()
    {
      DoTestAssertSame(1, 4);
    }

    [Test]
    public void Test_1_5()
    {
      DoTestAssertSame(1, 5);
    }

    [Test]
    public void Test_1_6()
    {
      DoTestAssertSame(1, 6);
    }

    [Test]
    public void Test_1_7()
    {
      DoTestAssertSame(1, 7);
    }

    [Test]
    public void Test_2_7()
    {
      DoTestAssertSame(2, 7);
    }

    [Test]
    public void Test_3_7()
    {
      DoTestAssertSame(3, 7);
    }

    [Test]
    public void Test_4_7()
    {
      DoTestAssertSame(4, 7);
    }

    [Test]
    public void Test_5_7()
    {
      DoTestAssertSame(5, 7);
    }

    [Test]
    public void Test_5_10()
    {
      DoTestAssertSame(5, 10);
    }

    [Test]
    public void Test_5_12()
    {
      DoTestAssertSame(5, 12);
    }

    [Test]
    public void Test_7_12()
    {
      DoTestAssertSame(7, 12);
    }

    private void DoTestAssertSame(int a, int b)
    {
      DoTest(a, b, AssertSame);
    }

    private void DoTest(int a, int b, AssertProjectedGraphs assert)
    {
      DoTest(b, (_, ad, leaf) => ad.AddEdge(leaf, new RememberGraphAction(_, a, assert)),
             delegate { });
    }


    private delegate void AssertProjectedGraphs(int projNodes, int projFNodes, int projEdges, int projFEdges);

    public static void AssertSame(int projNodes, int projFNodes, int projEdges, int projFEdges)
    {
      Assert.AreEqual(projNodes, projFNodes);
      Assert.AreEqual(projEdges, projFEdges);
    }


    private class RememberGraphAction : IntegerCoordinateSystemActionBase3
    {
      private readonly int myIndex;
      private IGraph myGraph;
      private readonly AssertProjectedGraphs myAssert;
      private readonly ILoopAction myLoop;

      public RememberGraphAction(ILoopAction loop, int index, AssertProjectedGraphs assert)
      {
        myIndex = index;
        myAssert = assert;
        myLoop = loop;
      }

      protected override void Apply<T, Q>(Context input, Context output)
      {
        LoopIndex index = myLoop.Key.Get(input);
        if (index.Index == myIndex)
        {
          IGraphStrongComponents<Q> components = Keys.GetGraphComponents<Q>().Get(input);
          myGraph = components.AsGraph(components.Components);
        }
        else if (index.Count - 1 == index.Index)
        {
          IGraphStrongComponents<Q> components = Keys.GetGraphComponents<Q>().Get(input);
          IGraph<Q> other = components.AsGraph(components.Components);
          var prev = (IGraph<Q>) myGraph;

          ICellCoordinateSystemProjector<Q> project =
            other.CoordinateSystem.Project(Factor(other.CoordinateSystem, prev.CoordinateSystem));
          ICellCoordinateSystemProjector<Q> filteredProject = new GraphCellCoordinateProjector<Q>(prev, project);

          int projNodes;
          int projFNodes;
          int projEdges;
          int projFEdges;

          ComputeProjectedGraphParams(other, project, out projNodes, out projEdges);
          ComputeProjectedGraphParams(other, filteredProject, out projFNodes, out projFEdges);

          DumpProjected(projNodes, projFNodes, projEdges, projFEdges);
          myAssert(projNodes, projFNodes, projEdges, projFEdges);
        }
        Assert.Less(myIndex, index.Count - 1, "Nothing to project");
      }

      private static void DumpProjected(int projNodes, int projFNodes, int projEdges, int projFEdges)
      {
        Console.Out.WriteLine("projNodes = {0}", projNodes);
        Console.Out.WriteLine("projFNodes = {0}", projFNodes);

        Console.Out.WriteLine("projEdges = {0}", projEdges);
        Console.Out.WriteLine("projFEdges = {0}", projFEdges);
      }

      public void ComputeProjectedGraphParams<Q>(IReadonlyGraph<Q> graph, ICellCoordinateSystemProjector<Q> proj, out int nodes,
                                                 out int edges)
        where Q : ICellCoordinate
      {
        var counter = new Counter<Q>{Projector = proj};
        graph.DoGeneric(counter);

        nodes = counter.Nodes;
        edges = counter.Edges;
      }

      private class Counter<Q> : IReadonlyGraphWith<Q> where Q : ICellCoordinate
      {
        public int Nodes { get; private set; }
        public int Edges { get; private set; }
        public ICellCoordinateSystemProjector<Q> Projector { get; set; }
        public void With<TNode>(IReadonlyGraph<Q, TNode> graph) where TNode : class, INode<Q>
        {
          Nodes = 0;
          Edges = 0;

          foreach (var node in graph.NodesInternal)
          {
            bool hasNodeProj = !graph.CoordinateSystem.IsNull(Projector.Project(node.Coordinate));
            if (hasNodeProj)
              Nodes++;
            Edges += graph.GetEdgesInternal(node)
              .Select(edge => !graph.CoordinateSystem.IsNull(Projector.Project(edge.Coordinate)))
              .Count(hasEdge => hasEdge && hasNodeProj);
          }
        }
      }

      private static long[] Factor(ICellCoordinateSystem from, ICellCoordinateSystem to)
      {
        return from.Subdivision.Select((t, i) => t/to.Subdivision[i]).ToArray();
      }
    }
  }
}