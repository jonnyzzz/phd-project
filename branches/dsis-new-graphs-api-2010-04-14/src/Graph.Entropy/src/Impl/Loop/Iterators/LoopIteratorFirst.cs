using System.Linq;
using DSIS.Core.Coordinates;
using DSIS.Graph.Entropy.Impl.Loop.Search;

namespace DSIS.Graph.Entropy.Impl.Loop.Iterators
{
  public class LoopIteratorFirst<T,N> : LoopIteratorBase<T,N>
    where T : ICellCoordinate
    where N : class, INode<T>
  {
    private readonly IGraphWeightSearch<T,N> mySearcher;

    public LoopIteratorFirst(ILoopIteratorCallback<T,N> callback, IReadonlyGraphStrongComponents<T,N> components,
                             IStrongComponentInfo component, IGraphWeightSearch<T,N> searcher) : base(callback, components, component)
    {
      mySearcher = searcher;
    }

    public override sealed void WidthSearch()
    {
      N first = myAccessor.GetNodes().First();
      if (first == null)
        return;

      mySearcher.WidthSearch(myCallback, first);
    }
  }
}