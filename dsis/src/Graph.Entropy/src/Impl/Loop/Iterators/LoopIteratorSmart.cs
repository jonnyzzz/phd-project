using System.Collections.Generic;
using DSIS.Core.Coordinates;
using DSIS.Graph.Entropy.Impl.Loop.Search;

namespace DSIS.Graph.Entropy.Impl.Loop.Iterators
{
  public class LoopIteratorSmart<T,N> : LoopIteratorBase<T,N>, ILoopIteratorCallback<T,N> 
    where T : ICellCoordinate
    where N : class, INode<T>
  {
    private readonly IGraphWeightSearch<T,N> mySearch;
    private readonly HashSet<N> myNodes;

    public LoopIteratorSmart(ILoopIteratorCallback<T,N> callback, IReadonlyGraphStrongComponents<T,N> components, IStrongComponentInfo component, IGraphWeightSearch<T,N> search) : 
      base(callback, components, component)
    {
      myNodes = new HashSet<N>(COMPARER);
      mySearch = search;
    }

    public override void WidthSearch()
    {      
      foreach (N node in myAccessor.GetNodes())
      {
        if (myNodes.Contains(node))
          continue;
        
        mySearch.WidthSearch(this, node);
      }
    }

    public void OnLoopFound(IEnumerable<N> loop, int length)
    {
      myNodes.UnionWith(loop);
      myCallback.OnLoopFound(loop, length);
    }
  }
}