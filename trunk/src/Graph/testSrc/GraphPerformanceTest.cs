using System;
using System.Collections.Generic;
using DSIS.Graph.Abstract;
using DSIS.Graph.Adapter;
using DSIS.IntegerCoordinates;
using DSIS.IntegerCoordinates.Tests;
using NUnit.Framework;

namespace DSIS.Graph
{
  [TestFixture]
  public class GraphPerformanceTest
  {
    protected TarjanGraph<IntegerCoordinate> myGraph;
    protected IIntegerCoordinateSystem<IntegerCoordinate> myIcs;

    [SetUp]
    public void SetUp()
    {
      MockSystemSpace ss =
        new MockSystemSpace(3, new double[] {0, 0, 0}, new double[] {1, 1, 1}, new long[] {1000, 1000, 1000});
      myIcs = IntegerCoordinateSystemFactory.Create(ss);
      myGraph = new TarjanGraph<IntegerCoordinate>(myIcs);
    }


    [Test]
    public void Test_01()
    {
      for (int i = 0; i < 1000; i++)
      {
        myGraph.AddNode(myIcs.Create(i, i, i));
      }
    }

    [Test]
    public void Test_02()
    {
      INode<IntegerCoordinate> node2 = null;
      for (int i = 0; i < 1000; i++)
      {
        INode<IntegerCoordinate> node1 = node2;
        node2 = myGraph.AddNode(myIcs.Create(i, i, i));
        if (node1 != null)
          myGraph.AddEdgeToNode(node1, node2);
      }
    }

    [Test]
    public void Test_03()
    {
      INode<IntegerCoordinate> node2 = null;
      for (int j = 0; j < 1000; j++)
        for (int i = 0; i < 100; i++)
        {
          INode<IntegerCoordinate> node1 = node2;
          node2 = myGraph.AddNode(myIcs.Create(i, j, i));
          if (node1 != null)
            myGraph.AddEdgeToNode(node1, node2);

          node1 = node2;
          node2 = myGraph.AddNode(myIcs.Create(j, j, i));
          if (node1 != null)
            myGraph.AddEdgeToNode(node1, node2);

          node1 = node2;
          node2 = myGraph.AddNode(myIcs.Create(j, j, j));
          if (node1 != null)
            myGraph.AddEdgeToNode(node1, node2);

          node1 = node2;
          node2 = myGraph.AddNode(myIcs.Create(i, j, j));
          if (node1 != null)
            myGraph.AddEdgeToNode(node1, node2);
        }
    }

    private static void Iterate<T>(IEnumerable<T> ts)
    {
      foreach (T __ in ts)
      {        
      }
    }

    [Test]
    public void Test_04_ConnectCellToRect()
    {
      RectProcessor ps = new RectProcessor((IntegerCoordinateSystem)myIcs, new double[] { 0, 0, 0 });
      for (int j = 0; j < 100; j++)
        for (int i = 0; i < 100; i++)
        {
          Iterate(ps.ConnectCellToRect(new double[] { i / 1000.0, j / 1000.0, i / 1000.0 },
                               new double[] {(i + 6)/1000.0, (j + 4)/1000.0, (i + 8)/1000.0}));
        }
    }

    public void Test_05_CreateNode()
    {
      for (int j = 0; j < 1000; j++)
        for (int i = 0; i < 1000; i++)
        {
          myGraph.AddNode(myIcs.Create(i, j, i));
        }

      Console.Out.WriteLine("GC.GetTotalMemory(true) = {0} Mb", GC.GetTotalMemory(true)/1024.0/1024.0);
    }
  }
}