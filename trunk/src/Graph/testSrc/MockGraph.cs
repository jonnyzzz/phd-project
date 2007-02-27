using System;
using System.Collections.Generic;
using System.IO;
using DSIS.Core.Coordinates;

namespace DSIS.Graph
{
  public class MockGraph<T> : IGraph<T> where T : ICellCoordinate<T>
  {
    private readonly ICellCoordinateSystem<T> myCoordinates;

    public MockGraph(ICellCoordinateSystem<T> coordinates)
    {
      myCoordinates = coordinates;
    }

    public ICellCoordinateSystem<T> CoordinateSystem
    {
      get { return myCoordinates; }
    }

    public IEnumerable<INode<T>> Nodes
    {
      get { throw new NotImplementedException(); }
    }

    public int NodesCount
    {
      get { throw new NotImplementedException(); }
    }

    public int EdgesCount
    {
      get { throw new NotImplementedException(); }
    }

    public IEnumerable<INode<T>> GetEdges(INode<T> forNode)
    {
      throw new NotImplementedException();
    }

    public void AddEdgeToNode(INode<T> fromNode, INode<T> toNode)
    {      
    }

    public INode<T> AddNode(T coordinate)
    {
      return new MockNode<T>(coordinate);
    }

    public void Dump(TextWriter tw)
    {      
    }

    public string Dump()
    {
      return "Mock Graph. No info";        
    }
  }
}