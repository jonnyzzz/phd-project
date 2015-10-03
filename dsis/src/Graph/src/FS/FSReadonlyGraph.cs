using System;
using System.Collections.Generic;
using System.Linq;
using DSIS.Core.Coordinates;
using DSIS.Utils;

namespace DSIS.Graph.FS
{
  public class FSReadonlyGraph<TCell> : IReadonlyGraph<TCell, FSReadonlyNode<TCell>>, IReadonlyGraph<TCell>
    where TCell : ICellCoordinate
  {
    private readonly IFSNodeIndex<TCell> myNodeIndex;
    private readonly IFSGraphObjectManager myResources;
    private readonly SimpleNodeReader<TCell> myReader;
    private readonly ICellCoordinateSystem<TCell> mySystem;
    private readonly FSPersisterFactory myPersisters = new FSPersisterFactory();
    private readonly IGraphDataHolder<uint, FSReadonlyNode<TCell>> myComponentsHolder;
 
    public FSReadonlyGraph(IFSGraphObjectManager resources,SimpleNodeReader<TCell> reader, ICellCoordinateSystem<TCell> system, int nodesCount, int edgesCount, IFSNodeIndex<TCell> nodeIndex)
    {
      myResources = resources;
      myReader = reader;
      myNodeIndex = nodeIndex;
      mySystem = system;
      NodesCount = nodesCount;
      EdgesCount = edgesCount;
      var componentsStream = myResources.CreateDataHolderStream("components");
      var persister = myPersisters.CreatePersister<uint>();
      myComponentsHolder = new FSReadonlyGraphHolder<uint, TCell>(componentsStream, persister, false, n=>0, this);
    }

    public int NodesCount { get; private set;}

    public int EdgesCount { get; private set;}

    public IEqualityComparer<FSReadonlyNode<TCell>> Comparer
    {
      get { return new FSReadonlyNodeComparer<TCell>(); }
    }

    public void DoGeneric(IReadonlyGraphWith with)
    {
      with.With(this);
    }

    public void DoGeneric(IReadonlyGraphWith<TCell> with)
    {
      with.With(this);
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

    public IEnumerable<TCell> NodesCoordinates
    {
      get { return myNodeIndex.Entries.Select(myReader.ReadCell); }
    }

    private FSReadonlyNode<TCell> ReadNode(IndexEntry entry)
    {
      var node = myReader.ReadNode(entry);
      node.ComponentId = myComponentsHolder.GetData(node);
      return node;
    }

    public FSReadonlyNode<TCell> Find(TCell node)
    {
      var entry = myNodeIndex.FindNode(node);
      return entry == null ? null : ReadNode(entry.Value);
    }

    public IEnumerable<FSReadonlyNode<TCell>> NodesInternal
    {
      get { return myNodeIndex.Entries.Select(ReadNode); }
    }

    public IEnumerable<FSReadonlyNode<TCell>> GetEdgesInternal(FSReadonlyNode<TCell> forNode)
    {      
      //TODO: Create node from coordinate only. Make this node load lazyly
      //NOTE: Node without outgoing edges is not included in the graph
      return myReader.ReadEdges(forNode.Entry).Select(Find).Where(x=>x != null);
    }

    public IGraphDataHolder<uint, FSReadonlyNode<TCell>> GetComponentIdHolder()
    {
      return myComponentsHolder;
    }

    public IGraphDataHolder<TData, FSReadonlyNode<TCell>> CreateDataHolder<TData>(Converter<FSReadonlyNode<TCell>, TData> def)
    {
      var stream = myResources.CreateDataHolderStream("holder");
      var persist = myPersisters.CreatePersister<TData>();
      return new FSReadonlyGraphHolder<TData, TCell>(stream, persist, true, def, this);
    }

    public IGraphDataHolder<bool, FSReadonlyNode<TCell>> CreateNodeFlagsHolder(string key)
    {
      return new FSReadonlyBitSetHolder<FSReadonlyNode<TCell>, TCell>();
    }

    public bool IsSelfLoop(FSReadonlyNode<TCell> node)
    {
      return node.IsSelfLoop;
    }
  }
}