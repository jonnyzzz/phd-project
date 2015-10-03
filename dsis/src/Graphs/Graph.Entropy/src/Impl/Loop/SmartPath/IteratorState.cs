using System.Collections.Generic;
using DSIS.Core.Coordinates;
using DSIS.Utils;

namespace DSIS.Graph.Entropy.Impl.Loop.SmartPath
{
  public class IteratorState<T, TNode> : INodeState<T, TNode> 
    where T : ICellCoordinate
    where TNode : class, INode<T>
  {
    private readonly IEnumerator<TNode> myNodes;

    public IteratorState(IEnumerator<TNode> nodes)
    {
      myNodes = nodes;
    }

    public INodeState<T, TNode> GetNextNode(IReadonlyGraph<T,TNode> thisGraph, TNode startNode, TNode thisNode, out TNode result, IGraphDataHolder<INodeState<T,TNode>, TNode> holder)
    {      
      while (myNodes.MoveNext())
      {
        if (SmartPathBuilder<T>.IsNodeOpened(result = myNodes.Current, holder) || ReferenceEquals(startNode, result))
        {
          return this;
        }
      }

      var edgesInternal = thisGraph.GetEdgesInternal(thisNode);
      INodeState<T,TNode> state = new SearchState<T,TNode>(new InfiniteEnumerable<TNode>(edgesInternal));
      return state.GetNextNode(thisGraph, startNode, thisNode, out result, holder);      
    }
  }
}