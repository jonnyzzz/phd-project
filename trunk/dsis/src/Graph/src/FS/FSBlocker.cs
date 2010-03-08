using System;
using System.Collections.Generic;
using System.Linq;
using DSIS.Core.Coordinates;
using DSIS.Utils;

namespace DSIS.Graph.FS
{
  public class FSReadonlyGraph<TCell> : IReadonlyGraph<TCell, FSReadonlyNode<TCell>>
    where TCell : ICellCoordinate
  {
    private readonly SimpleNodeReader<TCell> myReader;
    private readonly ICellCoordinateSystem<TCell> mySystem;

    public FSReadonlyGraph(SimpleNodeReader<TCell> reader, ICellCoordinateSystem<TCell> system, int nodesCount, int edgesCount)
    {
      myReader = reader;
      mySystem = system;
      NodesCount = nodesCount;
      EdgesCount = edgesCount;
    }

    public int NodesCount { get; private set;}

    public int EdgesCount { get; private set;}

    INode<TCell> IReadonlyGraphDeprecated<TCell>.Find(TCell node)
    {
      return Find(node);
    }

    public void DoGeneric(IReadonlyGraphWith with)
    {
      with.With(this);
    }

    public void DoGeneric(IReadonlyGraphWith<TCell> with)
    {
      with.With(this);
    }

    public IEnumerable<INode<TCell>> GetEdges(INode<TCell> forNode)
    {
      return GetEdgesInternal((FSReadonlyNode<TCell>) forNode);
    }

    public IGraphDataHoler<TData, INode<TCell>> CreateDataHolder<TData>(Converter<INode<TCell>, TData> def)
    {
      throw new NotImplementedException();
    }

    public ICellCoordinateSystem<TCell> CoordinateSystem
    {
      get { return mySystem; }
    }

    public IEnumerable<INode<TCell>> Nodes
    {
      get { return NodesInternal; }
    }

    public IReadonlyGraph<TCell> Project(ICellCoordinateSystemProjector<TCell> projector)
    {
      // 1. allocate temp graph
      // 2. process all nodes in the graph 
      // 3. use graph builder to create new graph
      // 4. return the result
      throw new NotImplementedException();
    }

    public bool Contains(TCell coordinate)
    {
      return Find(coordinate) != null;
    }

    public bool IsSelfLoop(TCell node)
    {
      return Find(node).Safe(false, IsSelfLoop);
    }

    public FSReadonlyNode<TCell> Find(TCell node)
    {
      //TODO: Implement index based search
      throw new NotImplementedException();
    }

    public IEnumerable<FSReadonlyNode<TCell>> NodesInternal
    {
      get { return myReader.ReadAllNodes(); }
    }

    public IEnumerable<FSReadonlyNode<TCell>> GetEdgesInternal(FSReadonlyNode<TCell> forNode)
    {
      //TODO: Consider lazy node or something but Find 
      return myReader.ReadEdges(forNode.Entry).Select(Find);
    }

    public IGraphDataHoler<TData, FSReadonlyNode<TCell>> CreateDataHolder<TData>(Converter<FSReadonlyNode<TCell>, TData> def)
    {
      throw new NotImplementedException();
    }

    public IGraphDataHoler<bool, FSReadonlyNode<TCell>> CreateNodeFlagsHolder(string key)
    {
      throw new NotImplementedException();
    }

    public bool IsSelfLoop(FSReadonlyNode<TCell> node)
    {
      return node.IsSelfLoop;
    }
  }
}