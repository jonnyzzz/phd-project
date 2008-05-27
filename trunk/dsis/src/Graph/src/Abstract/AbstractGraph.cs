using System.Collections.Generic;
using System.IO;
using DSIS.Core.Coordinates;
using DSIS.Utils;

namespace DSIS.Graph.Abstract
{
  public abstract class AbstractGraph<TInh, TCell, TNode> : IGraph<TCell>
    where TCell : ICellCoordinate
    where TNode : Node<TNode, TCell>
    where TInh : AbstractGraph<TInh, TCell, TNode>, IGraphExtension<TNode, TCell>
  {
    private readonly IGraphExtension<TNode, TCell> myExt;
    private readonly GraphNodeHashList<TNode, TCell> myNodes;

    private readonly ICellCoordinateSystem<TCell> myCoordinateSystem;
    private int myNodesCount;
    private int myEdgesCount;

    public AbstractGraph(ICellCoordinateSystem<TCell> coordinateSystem)
    {
      myExt = (TInh) this;
      myCoordinateSystem = coordinateSystem;
      myNodesCount = 0;
      myEdgesCount = 0;
      myNodes = new GraphNodeHashList<TNode, TCell>(Primes.Nearest(65536));
    }

    public void AddEdgeToNode(INode<TCell> fromNode, INode<TCell> toNode)
    {
      var from = (TNode) fromNode;
      var to = (TNode) toNode;

      if (from.AddEdgeTo(to))
      {
        myEdgesCount++;
        myExt.EdgeAdded(from, to);
      }
    }

    public INode<TCell> AddNode(TCell coordinate)
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
    
    public IGraph<TCell> Project(ICellCoordinateSystemProjector<TCell> projector)
    {
      TInh graph = CreateGraph(projector.ToSystem);

      foreach (INode<TCell> node in Nodes)
      {
        TCell proj = projector.Project(node.Coordinate);
        if (!Equals(proj, null))
        {
          INode<TCell> gNode = graph.AddNode(proj);
          if (gNode != null)
          {
            foreach (INode<TCell> edge in GetEdges(node))
            {
              TCell eProj = projector.Project(edge.Coordinate);
              if (!Equals(eProj, null))
              {
                INode<TCell> gToNode = graph.AddNode(eProj);
                if (gToNode != null)
                {
                  graph.AddEdgeToNode(gNode, gToNode);
                }
              }
            }
          }
        }
      }
      return graph;
    }

    public bool HasArcToItself(TCell node)
    {
      return myExt.HasArcToItself(myNodes.Find(node));
    }

    public ICellCoordinateSystem<TCell> CoordinateSystem
    {
      get { return myCoordinateSystem; }
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

    public int EdgesCount
    {
      get { return myEdgesCount; }
    }

    public IEnumerable<INode<TCell>> GetEdges(INode<TCell> forNode)
    {
      TNode node = (TNode) forNode;
      return node.Edges;
    }

    public IEnumerable<INode<TCell>> Nodes
    {
      get { return myNodes.ValuesUpcasted; }
    }

    public int NodesCount
    {
      get { return myNodesCount; }
    }

    internal IEnumerable<TNode> NodesInternal
    {
      get { return myNodes.Values; }
    }

    protected static IEnumerable<TNode> GetEdgesInternal(INode<TCell> forNode)
    {
      TNode node = (TNode) forNode;
      return node.EdgesInternal;
    }

    public override string ToString()
    {
      return string.Format("Graph [Nodes: {0}, Edges: {1}]", NodesCount, EdgesCount);
    }
  }
}