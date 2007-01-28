using System.Collections.Generic;
using System.IO;
using DSIS.Core.Coordinates;
using DSIS.Graph.Util;
using DSIS.Util;

namespace DSIS.Graph.Abstract
{
  public abstract class AbstractGraph<TCell, TNode> : IGraph<TCell>
    where TCell : ICellCoordinate<TCell>
    where TNode : Node<TNode, TCell>
  {
    private ICellCoordinateSystem<TCell> myCoordinateSystem;
    private int myNodesCount;
    private int myEdgesCount;
    private readonly Hashset<TNode, INode<TCell>> myNodes;

    public AbstractGraph(ICellCoordinateSystem<TCell> coordinateSystem)
    {
      myCoordinateSystem = coordinateSystem;
      myNodesCount = 0;
      myEdgesCount = 0;
      myNodes = new Hashset<TNode, INode<TCell>>(NodeEqualityComparer<TNode, TCell>.INSTANCE);
    }

    #region Getters

    public ICellCoordinateSystem<TCell> CoordinateSystem
    {
      get { return myCoordinateSystem; }
    }

    public IEnumerable<INode<TCell>> Nodes
    {
      get { return myNodes.ValuesUpcasted; }
    }

    internal IEnumerable<TNode> NodesInternal
    {
      get { return myNodes.Values; }
    }

    public int NodesCount
    {
      get { return myNodesCount; }
    }

    public int EdgesCount
    {
      get { return myEdgesCount; }
    }

    #endregion

    public IEnumerable<INode<TCell>> GetEdges(INode<TCell> forNode)
    {
      TNode node = (TNode) forNode;
      return node.Edges;
    }

    protected static IEnumerable<TNode> GetEdgesInternal(INode<TCell> forNode)
    {
      TNode node = (TNode)forNode;
      return new ConvertEnumerator<INode<TCell>, TNode>(node.Edges);      
    }

    #region Add

    protected abstract TNode CreateNode(TCell coordinate);

    protected virtual void NodeAdded(TNode node)
    {
      myNodesCount++;
    }

    protected virtual void EdgeAdded(TNode from, TNode to)
    {
      myEdgesCount++;
    }

    public void AddEdgeToNode(INode<TCell> fromNode, INode<TCell> toNode)
    {
      TNode from = (TNode) fromNode;
      TNode to = (TNode) toNode;

      if (from.AddEdgeTo(to))
        EdgeAdded(from, to);
    }

    public INode<TCell> AddNode(TCell coordinate)
    {
      TNode node = CreateNode(coordinate);
      if (myNodes.AddIfNotReplace(ref node))
        NodeAdded(node);
      return node;
    }

    #endregion

    #region Dump

    public override string ToString()
    {
      return string.Format("Graph [Nodes: {0}, Edges: {1}]", NodesCount, EdgesCount);
    }

    public virtual void Dump(TextWriter tw)
    {
      tw.WriteLine(this);
      Dictionary<TNode, int> ids = new Dictionary<TNode, int>();
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
      StringWriter sw = new StringWriter();
      Dump(sw);
      return sw.ToString();
    }

    #endregion
  }
}