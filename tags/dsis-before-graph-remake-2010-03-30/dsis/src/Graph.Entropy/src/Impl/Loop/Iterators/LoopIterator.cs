using System.Collections.Generic;
using DSIS.Core.Coordinates;
using DSIS.Graph.Entropy.Impl.Loop.Search;
using DSIS.Utils;

namespace DSIS.Graph.Entropy.Impl.Loop.Iterators
{
  public class LoopIterator<T> : ContextBase<T>, IGraphWeightSearch<T> where T : ICellCoordinate
  {
    private static readonly IEqualityComparer<INode<T>> COMPARER = EqualityComparerFactory<INode<T>>.GetReferenceComparer();

    private readonly IGraph<T> myGraph;


    public LoopIterator(IGraph<T> graph, IGraphStrongComponents<T> components, IStrongComponentInfo component) : base(components, component)
    {
      myGraph = graph;
    }

    private class Impl<TNode> where TNode : class, INode<T>
    {
      private readonly IGraphStrongComponents<T> myComponents;
      private readonly IStrongComponentInfo myComponent;
      private readonly IReadonlyGraph<T, TNode> myGraph;
      private SearchTreeNode mySearchRoot;
      private readonly Queue<SearchTreeNode> myNodes = new Queue<SearchTreeNode>();
      private readonly HashSet<TNode> myVisitedNodes;

      public Impl(IReadonlyGraph<T, TNode> graph, IGraphStrongComponents<T> components, IStrongComponentInfo component)
      {        
        myGraph = graph;
        myComponent = component;
        myComponents = components;
        myVisitedNodes = new HashSet<TNode>(myGraph.Comparer);        
      }

      private static bool IsUpperInTree(SearchTreeNode root, TNode node, List<TNode> result)
      {
        long hash = COMPARER.GetHashCode(node);
        while (root != null)
        {
          result.Add(root.Node);
          if (hash == root.Hash && root.IsNode(node))
          {
            return true;
          }
          root = root.Parent;
        }
        return false;
      }

      private void WidthSearch(ILoopIteratorCallback<T> callback, SearchTreeNode node)
      {
        myVisitedNodes.Add(node.Node);

        foreach (TNode edge in myGraph.GetEdgesInternal(node.Node))
        {
          if (myComponent != myComponents.GetNodeComponent(edge))
            continue;

          var loop = new List<TNode>();
          if (myVisitedNodes.Contains(node.Node) && IsUpperInTree(node, edge, loop))
          {
            IEnumerable<TNode> enumerable = loop;
            callback.OnLoopFound(enumerable, loop.Count);
          }
          else
          {
            myNodes.Enqueue(new SearchTreeNode(node, edge));
          }
        }
      }

      public void WidthSearch(ILoopIteratorCallback<T> callback, TNode node)
      {
        mySearchRoot = new SearchTreeNode(null, node);

        myNodes.Enqueue(mySearchRoot);

        while (myNodes.Count > 0)
        {
          WidthSearch(callback, myNodes.Dequeue());
        }
      }

      private sealed class SearchTreeNode
      {
        public readonly SearchTreeNode Parent;
        public readonly TNode Node;
        public readonly int Hash;

        public SearchTreeNode(SearchTreeNode parent, TNode node)
        {
          Parent = parent;
          Node = node;
          Hash = COMPARER.GetHashCode(node);
        }

        public bool IsNode(INode<T> node)
        {
          return COMPARER.Equals(Node, node);
        }
      }
    }

    private class Proxy : IReadonlyGraphWith<T>
    {
      private readonly IGraphStrongComponents<T> myComponents;
      private readonly IStrongComponentInfo myComponent;
      private readonly ILoopIteratorCallback<T> myCallback;
      private readonly INode<T> myNode;

      public Proxy(IGraphStrongComponents<T> components, IStrongComponentInfo component, ILoopIteratorCallback<T> callback, INode<T> node)
      {
        myComponents = components;
        myComponent = component;
        myCallback = callback;
        myNode = node;
      }

      public void With<TNode>(IReadonlyGraph<T, TNode> graph) where TNode : class, INode<T>
      {
        new Impl<TNode>(graph, myComponents, myComponent).WidthSearch(myCallback, graph.Find(myNode.Coordinate));
      }
    }

    public void WidthSearch(ILoopIteratorCallback<T> callback, INode<T> node)
    {
      myGraph.DoGeneric(new Proxy(myComponents, myComponent, callback, node));
    }
  }  
}