using System.Collections.Generic;
using DSIS.Core.Coordinates;

namespace DSIS.Graph.Entropy.Impl.Loop.SmartPath
{
  public class SearchState<T> : INodeState<T>
    where T : ICellCoordinate
  {
    private readonly IEnumerator<INode<T>> myNodes;

    public SearchState(IEnumerable<INode<T>> nodes)
    {
      myNodes = nodes.GetEnumerator();
    }

    public INodeState<T> GetNextNode(IGraph<T> thisGraph, INode<T> startNode, INode<T> thisNode, out INode<T> result, IGraphDataHoler<INodeState<T>, INode<T>> holder)
    {
      myNodes.MoveNext();
      INode<T> next = myNodes.Current;
      result = ReferenceEquals(startNode, next) ? next : SmartPathBuilder<T>.GetNextNode(thisGraph, startNode, next, holder);
      return this;
    }
  }
}