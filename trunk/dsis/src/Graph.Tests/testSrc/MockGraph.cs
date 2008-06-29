using System;
using System.Collections.Generic;
using System.IO;
using DSIS.Core.Coordinates;
using DSIS.Core.System.Impl;
using DSIS.Graph.Tests;

namespace DSIS.Graph.Tests
{
  public class MockGraph<T> : IGraph<T> where T : ICellCoordinate
  {
    private readonly ICellCoordinateSystem<T> myCoordinates;

    public MockGraph(ICellCoordinateSystem<T> coordinates)
    {
      myCoordinates = coordinates;
    }

    public void AddEdgeToNode(INode<T> fromNode, INode<T> toNode)
    {
    }

    public INode<T> AddNode(T coordinate)
    {
      return new MockNode<T>(coordinate);
    }

    public bool Contains(T coordinate)
    {
      throw new NotImplementedException();
    }

    public IGraph<T> Project(ICellCoordinateSystemProjector<T> projector)
    {
      throw new NotImplementedException();
    }

    public bool HasArcToItself(T node)
    {
      throw new NotImplementedException();
    }

    public IGraph<T> CreateEmptyGraph()
    {
      throw new NotImplementedException();
    }

    public ICellCoordinateSystem<T> CoordinateSystem
    {
      get { return myCoordinates; }
    }

    public void Dump(TextWriter tw)
    {
    }

    public string Dump()
    {
      return "Mock Graph. No info";
    }

    public int EdgesCount
    {
      get { throw new NotImplementedException(); }
    }

    public IEnumerable<INode<T>> GetEdges(INode<T> forNode)
    {
      throw new NotImplementedException();
    }

    public IEnumerable<INode<T>> Nodes
    {
      get { throw new NotImplementedException(); }
    }

    public int NodesCount
    {
      get { throw new NotImplementedException(); }
    }
  }
}