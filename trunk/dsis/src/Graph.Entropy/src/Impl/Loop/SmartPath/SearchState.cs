using System.Collections.Generic;
using DSIS.Core.Coordinates;

namespace DSIS.Graph.Entropy.Impl.Loop.SmartPath
{
  public class SearchState<T,TNode> : INodeState<T, TNode>
    where T : ICellCoordinate
    where TNode : class, INode<T>
  {
    private readonly IEnumerator<TNode> myNodes;

    public SearchState(IEnumerable<TNode> nodes)
    {
      myNodes = nodes.GetEnumerator();
    }

    public INodeState<T,TNode> GetNextNode(IReadonlyGraph<T,TNode> thisGraph, TNode startNode, TNode thisNode, out TNode result, IGraphDataHoler<INodeState<T,TNode>, TNode> holder)
    {
      myNodes.MoveNext();
      var next = myNodes.Current;

      //todo: I cannt remember what is done here!
      //result = ReferenceEquals(startNode, next) ? next : SmartPathBuilder<T>.GetNextNode(thisGraph, startNode, next, holder);

      result = next;
      return this;
    }
  }
}