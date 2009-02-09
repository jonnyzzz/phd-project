using System;
using System.Collections.Generic;
using DSIS.Core.Coordinates;
using DSIS.Graph.Entropy.Impl.Loop;
using DSIS.Graph.Entropy.Impl.Loop.Iterators;
using DSIS.Graph.Entropy.Impl.Loop.Search;
using DSIS.IntegerCoordinates.Impl;
using DSIS.Utils;
using NUnit.Framework;
using System.Linq;

namespace DSIS.Graph.Entropy.Tests
{
  [TestFixture]
  public class LoopIteratorsPerfomance : PerfomanceTestBase
  {
    [Test]
    public void Test_AllEdges_100()
    {
      DoWithFullGraph(100, delegate(IGraph<IntegerCoordinate> graph, IGraphStrongComponents<IntegerCoordinate> comps)
                             {
                               var callback = new MockLoopIteratorCallback<IntegerCoordinate>();
                               IStrongComponentInfo component = comps.Components.First();

                               return new AllEngesOnALoopGraphSearch<IntegerCoordinate>(callback, comps, component);
                             }, new TimeSpan(0,0,20));
    }    
    
    [Test]
    public void Test_AllNodes_100()
    {
      DoWithFullGraph(100, delegate(IGraph<IntegerCoordinate> graph, IGraphStrongComponents<IntegerCoordinate> comps)
                             {
                               var callback = new MockLoopIteratorCallback<IntegerCoordinate>();
                               IStrongComponentInfo component = comps.Components.First();

                               return new AllNodesOnALoopGraphSearch<IntegerCoordinate>(callback, comps, component);
                             }, new TimeSpan(0,0,9));
    }
    
    [Test]
    public void Test_Weight_100()
    {
      DoWithFullGraph(100, delegate(IGraph<IntegerCoordinate> graph, IGraphStrongComponents<IntegerCoordinate> comps)
                             {
                               var callback = new MockLoopIteratorCallback<IntegerCoordinate>();
                               IStrongComponentInfo component = comps.Components.First();

                               return new LoopIteratorFirst<IntegerCoordinate>(callback, comps, component, new GraphWeightSearch<IntegerCoordinate>(comps, component));
                             }, new TimeSpan(0,0,9));
    }
  }

  public class MockLoopIteratorCallback<T> : ILoopIteratorCallback<T> 
    where T : ICellCoordinate
  {
    public void OnLoopFound(IEnumerable<INode<T>> loop, int length)
    {
    }
  }
}