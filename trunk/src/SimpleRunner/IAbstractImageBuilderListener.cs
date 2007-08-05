using DSIS.Core.Builders;
using DSIS.Core.Coordinates;
using DSIS.Core.System;
using DSIS.Graph;
using DSIS.IntegerCoordinates;
using DSIS.Utils;

namespace DSIS.SimpleRunner
{
  public interface IAbstractImageBuilderListener<T,Q>
    where T : IIntegerCoordinateSystem<Q>
    where Q : IIntegerCoordinate<Q>
  {
    VoidDelegate ComputationStartedC(T system, AbstractImageBuilderContext<Q> cx, bool isUnsimmetric);
    VoidDelegate OnStepStartedC(T system, AbstractImageBuilderContext<Q> cx, long[] subdivide);
    VoidDelegate GraphConstructedC(IGraph<Q> graph, T system, AbstractImageBuilderContext<Q> cx);
    VoidDelegate GraphComponentsConstructedC(IGraphStrongComponents<Q> comps, IGraph<Q> graph, T system, AbstractImageBuilderContext<Q> cx);
    VoidDelegate OnStepFinishedC(IGraphStrongComponents<Q> comps, IGraph<Q> graph, T system, AbstractImageBuilderContext<Q> cx);
    VoidDelegate ComputationFinishedC(IGraphStrongComponents<Q> comps, IGraph<Q> graph, T system, AbstractImageBuilderContext<Q> cx);
  }

  public struct AbstractImageBuilderContext<Q> where Q : IIntegerCoordinate<Q>
  {
    public readonly ISystemInfo Info;
    public readonly ICellImageBuilder<Q> Builder;
    public readonly ICellImageBuilderSettings Settings;

    public AbstractImageBuilderContext(ISystemInfo info, ICellImageBuilder<Q> builder, ICellImageBuilderSettings settings)
    {
      Info = info;
      Builder = builder;
      Settings = settings;
    }
  }

  public interface IProvideExtendedListener
  {
    void AddListener(object o);
    void RemoveListener(object o);
  }
}