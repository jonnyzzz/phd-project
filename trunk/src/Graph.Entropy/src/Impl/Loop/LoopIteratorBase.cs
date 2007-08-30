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

    protected LoopIteratorBase(ILoopIteratorCallback<T> callback, IGraphStrongComponents<T> components,
                               IStrongComponentInfo component)
    {
      myCallback = callback;
      myComponents = components;
      myComponent = component;
    }

    public abstract void WidthSearch();
  }
}