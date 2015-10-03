using System;
using DSIS.Core.Coordinates;

namespace DSIS.Graph.Entropy.Impl.Loop.Iterators
{
  public abstract class LoopIteratorBase<T, N> : ContextBase<T, N>, ILoopIterator
    where T : ICellCoordinate
    where N : class, INode<T>
  {
    protected readonly ILoopIteratorCallback<T, N> myCallback;
        
    protected LoopIteratorBase(ILoopIteratorCallback<T,N> callback, IReadonlyGraphStrongComponents<T,N> components,
                               IStrongComponentInfo component) : base(components, component)
    {
      if (component == null)
        throw new ArgumentException("Null", "component");

      myCallback = callback;      
    }

    public abstract void WidthSearch();
  }
}