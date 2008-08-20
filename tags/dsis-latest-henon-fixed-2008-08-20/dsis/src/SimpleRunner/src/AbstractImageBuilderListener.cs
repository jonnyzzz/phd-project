using DSIS.Graph;
using DSIS.IntegerCoordinates;
using DSIS.Utils;

namespace DSIS.SimpleRunner
{
  public abstract class AbstractImageBuilderListener<T,Q> : IAbstractImageBuilderListener<T,Q>
    where T : IIntegerCoordinateSystem<Q>
    where Q : IIntegerCoordinate
  {

    private static void Void()
    {
      
    }


    public virtual VoidDelegate ComputationStartedC(T system, AbstractImageBuilderContext<Q> cx, bool isUnsimmetric)
    {
      ComputationStarted(system, cx, isUnsimmetric);
      return Void;
    }
    
    public virtual VoidDelegate OnStepStartedC(T system, AbstractImageBuilderContext<Q> cx, long[] subdivide)
    {
      OnStepStarted(system, cx, subdivide);
      return Void;
    }

    public virtual VoidDelegate GraphConstructedC(IGraph<Q> graph, T system, AbstractImageBuilderContext<Q> cx)
    {
      GraphConstructed(graph, system, cx);
      return Void;
    }

    public virtual VoidDelegate GraphComponentsConstructedC(IGraphStrongComponents<Q> comps, IGraph<Q> graph, T system,
                                                    AbstractImageBuilderContext<Q> cx)
    {
      GraphComponentsConstructed(comps, graph, system, cx);
      return Void;
    }

    public virtual VoidDelegate OnStepFinishedC(IGraphStrongComponents<Q> comps, IGraph<Q> graph, T system,
                                        AbstractImageBuilderContext<Q> cx)
    {
      OnStepFinished(comps, graph, system, cx);
      return Void;
    }

    public virtual VoidDelegate ComputationFinishedC(IGraphStrongComponents<Q> comps, IGraph<Q> graph, T system,
                                             AbstractImageBuilderContext<Q> cx)
    {
      ComputationFinished(comps, graph, system, cx);
      return Void;
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