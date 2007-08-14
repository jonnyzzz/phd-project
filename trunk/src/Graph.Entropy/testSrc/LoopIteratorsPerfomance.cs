using System;
using System.Collections.Generic;
using DSIS.Core.Coordinates;
using DSIS.Graph.Abstract;
using DSIS.Graph.Entropy.Impl;
using DSIS.IntegerCoordinates.Impl;
using NUnit.Framework;

namespace DSIS.Graph.Entropy
{
  [TestFixture]
  public class LoopIteratorsPerfomance : PerfomanceTestBase
  {
    [Test]
    public void Test_AllEdges_100()
    {
      DoWithFullGraph(100, delegate(IGraph<IntegerCoordinate> graph, IGraphStrongComponents<IntegerCoordinate> comps)
                            {
                              MockLoopIteratorCallback<IntegerCoordinate> callback = new MockLoopIteratorCallback<IntegerCoordinate>();
                              IStrongComponentInfo component = GetFirst(comps.Components);

                              return new AllEngesOnALoopGraphSearch<IntegerCoordinate>(callback, comps, component);
                            }, new TimeSpan(0,0,20));
    }    
    
    [Test]
    public void Test_AllNodes_100()
    {
      DoWithFullGraph(100, delegate(IGraph<IntegerCoordinate> graph, IGraphStrongComponents<IntegerCoordinate> comps)
                            {
                              MockLoopIteratorCallback<IntegerCoordinate> callback = new MockLoopIteratorCallback<IntegerCoordinate>();
                              IStrongComponentInfo component = GetFirst(comps.Components);

                              return new AllNodesOnALoopGraphSearch<IntegerCoordinate>(callback, comps, component);
                            }, new TimeSpan(0,0,9));
    }
    
    [Test]
    public void Test_Weight_100()
    {
      DoWithFullGraph(100, delegate(IGraph<IntegerCoordinate> graph, IGraphStrongComponents<IntegerCoordinate> comps)
                            {
                              MockLoopIteratorCallback<IntegerCoordinate> callback = new MockLoopIteratorCallback<IntegerCoordinate>();
                              IStrongComponentInfo component = GetFirst(comps.Components);

                              return new GraphWeightSearch<IntegerCoordinate>(callback, comps, component);
                            }, new TimeSpan(0,0,9));
    }
  }


  public class MockLoopIteratorCallback<T> : ILoopIteratorCallback<T> 
    where T : ICellCoordinate<T>
  {
    public void OnLoopFound(IList<INode<T>> loop)
    {
    }
  }
}