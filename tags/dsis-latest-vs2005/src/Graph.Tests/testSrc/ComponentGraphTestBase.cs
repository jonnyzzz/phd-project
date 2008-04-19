using System;
using System.Collections.Generic;
using DSIS.Core.Util;
using DSIS.Graph.Abstract;
using DSIS.IntegerCoordinates;
using DSIS.IntegerCoordinates.Tests;
using NUnit.Framework;

namespace DSIS.Graph.Tests
{
  public abstract class ComponentGraphTestBase<T, Q, G>
    where T : IIntegerCoordinateSystem<Q>
    where Q : IIntegerCoordinate
    where G : IGraphWithStrongComponent<Q>
  {
    protected G myGraph;
    protected IGraphStrongComponents<Q> myComponents = null;
    private T mySystem;
    private int myNodeId;

    public void ComputeComponents()
    {
      myComponents = myGraph.ComputeStrongComponents(NullProgressInfo.INSTANCE);
    }

    [SetUp]
    public virtual void SetUp()
    {
      mySystem = IntegerCoordinateSystemFactory.CreateCoordinateSystem<T,Q>(new MockSystemSpace(Dimension, 0, 1, 1000));
      myGraph = CreateGraph(mySystem);
      myNodeId = 0;
    }

    protected virtual int Dimension { get { return 1;} }
    protected abstract G CreateGraph(T system);

    [TearDown]
    public virtual void TearDown()
    {
      mySystem = default(T);
      myGraph = default(G);
    }

    protected INode<Q> CreateNode()
    {
      return myGraph.AddNode(CreateCoordinate());
    }
    
    protected Q CreateCoordinate()
    {
      return CreateCoordinate(myNodeId++, mySystem);
    }

    protected Q CreateCoordinate(long nodeId)
    {
      return CreateCoordinate(nodeId, mySystem);
    }

    protected virtual Q CreateCoordinate(long nodeId, T t)
    {
      return t.Create(nodeId);
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
      INode<Q> n = null;
      INode<Q> n2 = null;
      for (int i = 0; i < length; i++)
      {
        INode<Q> n1;
        n1 = n2;
        n2 = myGraph.AddNode(CreateCoordinate(offset + (i + 1)*factor, mySystem));
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