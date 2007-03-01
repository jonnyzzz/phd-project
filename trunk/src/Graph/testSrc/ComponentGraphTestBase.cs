using System;
using System.Collections.Generic;
using DSIS.Core.Util;
using DSIS.Graph.Abstract;
using DSIS.IntegerCoordinates;
using DSIS.IntegerCoordinates.Tests;
using NUnit.Framework;

namespace DSIS.Graph.Test
{
  public abstract class ComponentGraphTestBase
  {
    protected IGraphWithStrongComponent<IntegerCoordinate> myGraph;
    protected IGraphStrongComponents<IntegerCoordinate> myComponents = null;
    protected IntegerCoordinateSystem mySystem;
    private int myNodeId;

    public void ComputeComponents()
    {
      myComponents = myGraph.ComputeStrongComponents(NullProgressInfo.INSTANCE);
    }

    [SetUp]
    public virtual void SetUp()
    {
      mySystem = new IntegerCoordinateSystem(new MockSystemSpace(1, 0, 1, 1000));
      myGraph = CreateGraph();
      myNodeId = 0;
    }

    protected abstract IGraphWithStrongComponent<IntegerCoordinate> CreateGraph();

    [TearDown]
    public virtual void TearDown()
    {
      mySystem = null;
      myGraph = null;
    }


    protected INode<IntegerCoordinate> CreateNode()
    {
      return myGraph.AddNode(new IntegerCoordinate(myNodeId++));
    }

    protected List<IStrongComponentInfo> OneComponent
    {
      get
      {
        Assert.AreEqual(1, myComponents.ComponentCount);
        List<IStrongComponentInfo> list = new List<IStrongComponentInfo>(myComponents.Components);
        Assert.AreEqual(1, list.Count);
        return list;
      }
    }

    protected void DoCircleTest(int length)
    {
      DoTest(delegate
               {
                 BuildCircle(0, 1, length);

                 ComputeComponents();

                 Assert.AreEqual(1, myComponents.ComponentCount, "Wrong component count");
                 Assert.AreEqual(length, OneComponent[0].NodesCount, "Wrong node count number");
               });
    }

    protected void BuildCircle(int offset, int factor, int length)
    {
      INode<IntegerCoordinate> n = null;
      INode<IntegerCoordinate> n2 = null;
      for (int i = 0; i < length; i++)
      {
        INode<IntegerCoordinate> n1;
        n1 = n2;
        n2 = myGraph.AddNode(new IntegerCoordinate(offset + (i + 1)*factor));
        if (n == null)
          n = n2;
        if (n1 != null)
          myGraph.AddEdgeToNode(n1, n2);
      }
      myGraph.AddEdgeToNode(n2, n);
    }

    protected void DoTest(VoidDelegate deleg)
    {
      try
      {
        deleg();
      }
      catch
      {
        Dump();
        throw;
      }
    }

    protected void Dump()
    {
      Console.Out.WriteLine(myGraph.Dump());
    }

    protected delegate void VoidDelegate();
  }
}