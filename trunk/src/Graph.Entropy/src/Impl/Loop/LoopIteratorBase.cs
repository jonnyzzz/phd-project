using System;
using DSIS.Core.Coordinates;
using DSIS.Graph.Abstract;
using DSIS.Graph.Entropy.Impl.Loop;

namespace DSIS.Graph.Entropy.Impl.Loop
{
  public abstract class LoopIteratorBase<T> : ILoopIterator<T>
    where T : ICellCoordinate<T>
  {
    protected readonly ILoopIteratorCallback<T> myCallback;
    protected readonly IGraphStrongComponents<T> myComponents;
    protected readonly IStrongComponentInfo myComponent;
    protected readonly IStrongComponentInfo[] myComponentInfos;

    protected LoopIteratorBase(ILoopIteratorCallback<T> callback, IGraphStrongComponents<T> components,
                               IStrongComponentInfo component)
    {
      if (component == null)
        throw new ArgumentException("Null", "component");

      myCallback = callback;
      myComponents = components;
      myComponent = component;
      myComponentInfos = new IStrongComponentInfo[] {myComponent};
    }

    public abstract void WidthSearch();
  }
}