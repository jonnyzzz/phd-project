using System;
using System.Collections.Generic;
using System.IO;
using DSIS.Core.Coordinates;
using DSIS.Utils;

namespace DSIS.Graph.Abstract
{
  public abstract class AbstractGraph<TInh, TCell, TNode> : IGraph<TCell, TNode>
    where TCell : ICellCoordinate
    where TNode : Node<TNode, TCell>
    where TInh : AbstractGraph<TInh, TCell, TNode>, IGraphExtension<TNode, TCell>
  {
    private readonly IGraphExtension<TNode, TCell> myExt;
    private readonly INodeSet<TNode, TCell> myNodes;
    private readonly NodeFlags myNodeFlags = new NodeFlags();
    private readonly IGraphDataHoler<bool, TNode> myIsLoop;

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
      myNodes = new GraphNodeHashList<TNode, TCell>(Primes.Nearest(65536));
      myIsLoop = CreateNodeFlagsHolder("IS_LOOP");
    }

    public void AddEdgeToNode(INode<TCell> fromNode, INode<TCell> toNode)
    {
      File.AppendAllText(@"c:\graph.txt", string.Format("{0}\t->\t{1}\r\n", fromNode, toNode));

      var from = (TNode) fromNode;
      var to = (TNode) toNode;

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

    public bool Contains(TNode coordinate)
    {
      //todo:
      return myNodes.Contains(coordinate.Coordinate);
    }

    protected abstract TInh CreateGraph(ICellCoordinateSystem<TCell> system);

    IGraph<TCell> IGraph<TCell>.Project(ICellCoordinateSystemProjector<TCell> projector)
    {
      return Project(projector);
    }

    public IGraph<TCell, TNode> Project(ICellCoordinateSystemProjector<TCell> projector)
    {
      return this.Project(projector, CreateGraph);
    }

    public void DoGeneric(IGraphWith<TCell> with)
    {
      with.With(this);
    }

    public INode<TCell> Find(TCell node)
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

    public virtual void Dump(TextWriter tw)
    {
      tw.WriteLine(this);
      var ids = new Dictionary<TNode, int>();
      int lastId = 0;
      foreach (TNode node in myNodes.Values)
      {
        int id;
        if (!ids.TryGetValue(node, out id))
        {
          id = ++lastId;
          ids[node] = id;
        }

        tw.Write("  {0} -> {{ ", id);

        foreach (TNode pair in node.Edges)
        {
          int id2;
          if (!ids.TryGetValue(pair, out id2))
          {
            id2 = ++lastId;
            ids[pair] = id2;
          }

          tw.Write("{0}, ", id2);
        }

        tw.WriteLine(" }}");
      }
      tw.WriteLine("Finished!\r\n");
    }

    public string Dump()
    {
      var sw = new StringWriter();
      Dump(sw);
      return sw.ToString();
    }

    public void DoGeneric(IGraphWith with)
    {
      with.With(this);
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
      get { return myNodes.ValuesUpcasted; }
    }

    public int NodesCount
    {
      get { return myNodesCount; }
    }

    public IEnumerable<TNode> NodesInternal
    {
      get { return myNodes.Values; }
    }

    public IEnumerable<TNode> GetEdgesInternal(INode<TCell> forNode)
    {
      return ((TNode) forNode).EdgesInternal;
    }

    public override string ToString()
    {
      return string.Format("Graph [Nodes: {0}, Edges: {1}]", NodesCount, EdgesCount);
    }

    public IGraphDataHoler<TData, TNode> CreateDataHolder<TData>(Converter<TNode,TData> def)
    {
      if (myGraphDataHolder != null)
      {
        throw new ArgumentException("GraphHolder is allocated. " + myGraphDataHolder);
      }
      var holder = new GraphDataHolder<TData, TNode, TCell, TInh>(this, def);
      myGraphDataHolder = holder;
      return holder;
    }

    public IGraphDataHoler<bool, TNode> CreateNodeFlagsHolder(string key)
    {
      var flag = myNodeFlags.CreateFlag(key);
      var holder = new FlagsNodeHolder<TInh, TNode, TCell>(this, myNodeFlags, flag);
      if (flag.IsReusing)
        holder.CleanAll();

      return holder;
    }

    public void DisposeDataHolder<TData>(IGraphDataHoler<TData, TNode> holder)
    {
      if (!Equals(myGraphDataHolder, holder))
      {
        throw new ArgumentException("Wrong data holder object to dispose");
      }
      myGraphDataHolder = null;
    }

    IGraphDataHoler<TData, INode<TCell>> IGraph<TCell>.CreateDataHolder<TData>(Converter<INode<TCell>, TData> def)
    {
      return new GraphDataHolderProxy<TData, TCell, TNode>(CreateDataHolder(x=>def(x)));
    }
  }
}