using System;
using System.Collections.Generic;
using DSIS.Core.Coordinates;
using DSIS.Graph;
using DSIS.Scheme.Actions;
using DSIS.Scheme.Ctx;
using DSIS.Scheme.Impl;
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


    private class RememberGraphAction : IntegerCoordinateSystemActionBase2
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

      protected override void Apply<T, Q>(T system, Context input, Context output)
      {
        LoopIndex index = myLoop.Key.Get(input);
        if (index.Index == myIndex)
        {
          IGraphStrongComponents<Q> components = Keys.GraphComponents<Q>().Get(input);
          myGraph = components.AsGraph(components.Components);
        }
        else if (index.Count - 1 == index.Index)
        {
          IGraphStrongComponents<Q> components = Keys.GraphComponents<Q>().Get(input);
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

      public void ComputeProjectedGraphParams<Q>(IGraph<Q> graph, ICellCoordinateSystemProjector<Q> proj, out int nodes,
                                                 out int edges)
        where Q : ICellCoordinate
      {
        nodes = 0;
        edges = 0;

        foreach (INode<Q> node in graph.Nodes)
        {
          bool hasNodeProj = proj.Project(node.Coordinate) != null;
          if (hasNodeProj)
            nodes++;
          foreach (INode<Q> edge in graph.GetEdges(node))
          {
            bool hasEdge = proj.Project(edge.Coordinate) != null;
            if (hasEdge && hasNodeProj)
              edges++;
          }
        }
      }

      private static long[] Factor(ICellCoordinateSystem from, ICellCoordinateSystem to)
      {
        var list = new List<long>();
        for (int i = 0; i < from.Subdivision.Length; i++)
        {
          list.Add(from.Subdivision[i]/to.Subdivision[i]);
        }
        return list.ToArray();
      }
    }
  }
}