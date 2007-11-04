using System;
using DSIS.Core.Coordinates;
using DSIS.Graph.Abstract;
using DSIS.Graph.Entropy.Impl.Loop;

namespace DSIS.Graph.Entropy.Impl.Loop
{
  public abstract class LoopIteratorBase<T> : ContextBase<T>, ILoopIterator<T>
    where T : ICellCoordinate<T>
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