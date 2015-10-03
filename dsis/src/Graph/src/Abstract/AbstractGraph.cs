using System;
using System.Collections.Generic;
using DSIS.Core.Coordinates;
using DSIS.Graph.Abstract.NodeSets;
using DSIS.Utils;
using JetBrains.Annotations;
using System.Linq;

namespace DSIS.Graph.Abstract
{
  public abstract class AbstractGraph<TInh, TCell, TNode> : IGraph<TCell, TNode>, IGraph<TCell>
    where TCell : ICellCoordinate
    where TNode : Node<TNode, TCell>
    where TInh : AbstractGraph<TInh, TCell, TNode>, IGraphExtension<TNode, TCell>
  {
    private readonly IGraphExtension<TNode, TCell> myExt;
    private readonly INodeSet<TNode, TCell> myNodes;
    private readonly NodeFlags myNodeFlags = new NodeFlags();
    private readonly IGraphDataHolder<bool, TNode> myIsLoop;

    private readonly ICellCoordinateSystem<TCell> myCoordinateSystem;
    private int myNodesCount;
    private int myEdgesCount;
    private object myGraphDataHolder;

    protected AbstractGraph(ICellCoordinateSystem<TCell> coordinateSystem)
    {
      myExt = (TInh) this;
      myCoordinateSystem = coordinateSystem;
      myNodesCount = 0;
      myEdgesCount = 0;
      myNodes = new GraphNodeHashList<TNode, TCell>(Primes.Nearest(500 * 1000));
      myIsLoop = CreateNodeFlagsHolder("IS_LOOP");
    }

    public abstract IEqualityComparer<TNode> Comparer { get; }

    void IGraph<TCell>.AddEdgeToNode(INode<TCell> fromNode, INode<TCell> toNode)
    {
      var from = (TNode) fromNode;
      var to = (TNode) toNode;

      AddEdgeToNode(from, to);
    }

    public IEnumerable<TCell> NodesCoordinates
    {
      get { return Nodes.Select(x => x.Coordinate); }
    }

    public void AddEdgeToNode(TNode from, TNode to)
    {
      if (from.AddEdgeTo(to))
      {
        myEdgesCount++;
        
        if (ReferenceEquals(from, to)) 
          myIsLoop.SetData(from, true);

        myExt.EdgeAdded(from, to);
      }
    }

    INode<TCell> IGraph<TCell>.AddNode(TCell coordinate)
    {
      return AddNode(coordinate);
    }

    [NotNull]
    public TNode AddNode(TCell coordinate)
    {
      bool wasAdded;
      var node = myNodes.AddIfNotReplace(coordinate, myExt, out wasAdded);

      if (wasAdded)
      {
        myNodesCount++;        
        myExt.NodeAdded(node);
      }
      return node;
    }

    public bool Contains(TCell coordinate)
    {
      return myNodes.Contains(coordinate);
    }

    protected abstract TInh CreateGraph(ICellCoordinateSystem<TCell> system);

    public IReadonlyGraph<TCell> Project(ICellCoordinateSystemProjector<TCell> projector)
    {
      var toSystem = projector.ToSystem;
      var graph = CreateGraph(toSystem);

      foreach (var node in this.NodesInternal)
      {
        var proj = projector.Project(node.Coordinate);
        if (toSystem.IsNull(proj))
          continue;

        var gNode = graph.AddNode(proj);
        
        foreach (var edge in this.GetEdgesInternal(node))
        {
          var eProj = projector.Project(edge.Coordinate);
          if (toSystem.IsNull(eProj))
            continue;

          var gToNode = graph.AddNode(eProj);

          graph.AddEdgeToNode(gNode, gToNode);
        }
      }
      return graph;
    }

    public void DoGeneric(IGraphWith with)
    {
      with.With(this);
    }

    public void DoGeneric(IGraphWith<TCell> with)
    {
      with.With(this);
    }

    public void DoGeneric(IReadonlyGraphWith with)
    {
      with.With(this);
    }

    public void DoGeneric(IReadonlyGraphWith<TCell> with)
    {
      with.With(this);
    }

    public TNode Find(TCell node)
    {
      return myNodes.Find(node);
    }

    public bool IsSelfLoop(TCell node)
    {
      var find = myNodes.Find(node);
      return find != null && IsSelfLoop(find);
    }

    public bool IsSelfLoop(TNode node)
    {
      return myIsLoop.GetData(node);
    }

    public ICellCoordinateSystem<TCell> CoordinateSystem
    {
      get { return myCoordinateSystem; }
    }

    public int EdgesCount
    {
      get { return myEdgesCount; }
    }

    public IEnumerable<INode<TCell>> GetEdges(INode<TCell> forNode)
    {
      return ((TNode) forNode).Edges;
    }

    public IEnumerable<INode<TCell>> Nodes
    {
      get { return myNodes.Values; }
    }

    public int NodesCount
    {
      get { return myNodesCount; }
    }

    public IEnumerable<TNode> NodesInternal
    {
      get { return myNodes.Values; }
    }

    public IEnumerable<TNode> GetEdgesInternal(TNode forNode)
    {
      return forNode.EdgesInternal;
    }

    public override string ToString()
    {
      return string.Format("Graph [Nodes: {0}, Edges: {1}]", NodesCount, EdgesCount);
    }

    public IGraphDataHolder<TData, TNode> CreateDataHolder<TData>(Func<TNode,TData> def)
    {
      if (myGraphDataHolder != null)
      {
        throw new ArgumentException("GraphHolder is allocated. " + myGraphDataHolder);
      }
      var holder = new GraphDataHolder<TData, TNode, TCell, TInh>(this, def);
      myGraphDataHolder = holder;
      return holder;
    }

    public IGraphDataHolder<bool, TNode> CreateNodeFlagsHolder(string key)
    {
      var flag = myNodeFlags.CreateFlag(key);
      var holder = new FlagsNodeHolder<TInh, TNode, TCell>(this, myNodeFlags, flag);
      if (flag.IsReusing)
        holder.CleanAll();

      return holder;
    }

    public IGraphDataHolder<uint, TNode> GetComponentIdHolder()
    {
      return new AbstractGraphComponentIdHolder<TInh, TNode, TCell>(this);
    }

    public void DisposeDataHolder<TData>(IGraphDataHolder<TData, TNode> holder)
    {
      if (!Equals(myGraphDataHolder, holder))
      {
        throw new ArgumentException("Wrong data holder object to dispose");
      }
      myGraphDataHolder = null;
    }
  }
}