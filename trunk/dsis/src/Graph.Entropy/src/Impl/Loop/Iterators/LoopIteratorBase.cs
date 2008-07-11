using System;
using DSIS.Core.Coordinates;
using DSIS.Graph.Entropy.Impl.Loop.Iterators;

namespace DSIS.Graph.Entropy.Impl.Loop.Iterators
{
  public abstract class LoopIteratorBase<T> : ContextBase<T>, ILoopIterator
    where T : ICellCoordinate
  {
    protected readonly ILoopIteratorCallback<T> myCallback;
        
    protected LoopIteratorBase(ILoopIteratorCallback<T> callback, IGraphStrongComponents<T> components,
                               IStrongComponentInfo component) : base(components, component)
    {
      if (component == null)
        throw new ArgumentException("Null", "component");

      myCallback = callback;      
    }

    public abstract void WidthSearch();
  }
}