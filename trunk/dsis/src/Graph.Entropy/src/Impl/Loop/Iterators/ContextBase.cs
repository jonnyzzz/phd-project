using DSIS.Core.Coordinates;
using DSIS.Graph.Abstract;

namespace DSIS.Graph.Entropy.Impl.Loop.Iterators
{
  public abstract class ContextBase<T> where T : ICellCoordinate<T>
  {
    protected readonly IGraphStrongComponents<T> myComponents;
    protected readonly IStrongComponentInfo myComponent;
    protected readonly IStrongComponentInfo[] myComponentInfos;

    protected ContextBase(IGraphStrongComponents<T> components, IStrongComponentInfo component)
    {
      myComponents = components;
      myComponent = component;
      myComponentInfos = new IStrongComponentInfo[] { myComponent };
    }
  }
}