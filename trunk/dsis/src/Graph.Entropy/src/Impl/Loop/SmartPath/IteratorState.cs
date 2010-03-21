using System.Collections.Generic;
using DSIS.Core.Coordinates;
using DSIS.Utils;

namespace DSIS.Graph.Entropy.Impl.Loop.SmartPath
{
  public class IteratorState<T> : INodeState<T> 
    where T : ICellCoordinate
  {
    private readonly IEnumerator<INode<T>> myNodes;

    public IteratorState(IEnumerator<INode<T>> nodes)
    {
      myNodes = nodes;
    }

    public INodeState<T> GetNextNode(IGraph<T> thisGraph, INode<T> startNode, INode<T> thisNode, out INode<T> result, IGraphDataHoler<INodeState<T>, INode<T>> holder)
    {      
      while (myNodes.MoveNext())
      {
        if (SmartPathBuilder<T>.IsNodeOpened(result = myNodes.Current, holder) || ReferenceEquals(startNode, result))
        {
          return this;
        }
      }

      INodeState<T> state = new SearchState<T>(new InfiniteEnumerable<INode<T>>(((IReadonlyGraphDeprecated<T>)thisGraph).GetEdges(thisNode)));
      return state.GetNextNode(thisGraph, startNode, thisNode, out result, holder);      
    }
  }
}