using DSIS.Graph;
using DSIS.IntegerCoordinates;
using DSIS.Utils;

namespace DSIS.SimpleRunner
{
  public abstract class AbstractImageBuilderListener<T,Q> : IAbstractImageBuilderListener<T,Q>
    where T : IIntegerCoordinateSystem<Q>
    where Q : IIntegerCoordinate<Q>
  {
    public virtual VoidDelegate ComputationStartedC(T system, AbstractImageBuilderContext<Q> cx, bool isUnsimmetric)
    {
      ComputationStarted(system, cx, isUnsimmetric);
      return delegate { };
    }

    public virtual void ComputationStarted(T system, AbstractImageBuilderContext<Q> cx, bool isUnsimmetric)
    {      
    }

    public virtual void OnStepStarted(T system, AbstractImageBuilderContext<Q> cx, long[] subdivide)
    {
    }

    public virtual void GraphConstructed(IGraph<Q> graph, T system, AbstractImageBuilderContext<Q> cx)
    {
    }

    public virtual void GraphComponentsConstructed(IGraphStrongComponents<Q> comps, IGraph<Q> graph, T system,
                                                   AbstractImageBuilderContext<Q> cx)
    {
    }

    public virtual void OnStepFinished(IGraphStrongComponents<Q> comps, IGraph<Q> graph, T system,
                                       AbstractImageBuilderContext<Q> cx)
    {
    }

    public virtual void ComputationFinished(IGraphStrongComponents<Q> comps, IGraph<Q> graph, T system,
                                            AbstractImageBuilderContext<Q> cx)
    {
    }
  }
}