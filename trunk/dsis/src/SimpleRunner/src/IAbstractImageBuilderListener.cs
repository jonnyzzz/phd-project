using DSIS.Core.Builders;
using DSIS.Core.System;
using DSIS.Graph;
using DSIS.IntegerCoordinates;
using DSIS.Utils;

namespace DSIS.SimpleRunner
{
  public interface IAbstractImageBuilderListener<T,Q>
    where T : IIntegerCoordinateSystem<Q>
    where Q : IIntegerCoordinate
  {
    VoidDelegate ComputationStartedC(T system, AbstractImageBuilderContext<Q> cx, bool isUnsimmetric);
    VoidDelegate OnStepStartedC(T system, AbstractImageBuilderContext<Q> cx, long[] subdivide);
    VoidDelegate GraphConstructedC(IGraph<Q> graph, T system, AbstractImageBuilderContext<Q> cx);
    VoidDelegate GraphComponentsConstructedC(IReadonlyGraphStrongComponents<Q> comps, IGraph<Q> graph, T system, AbstractImageBuilderContext<Q> cx);
    VoidDelegate OnStepFinishedC(IReadonlyGraphStrongComponents<Q> comps, IGraph<Q> graph, T system, AbstractImageBuilderContext<Q> cx);
    VoidDelegate ComputationFinishedC(IReadonlyGraphStrongComponents<Q> comps, IGraph<Q> graph, T system, AbstractImageBuilderContext<Q> cx);
  }

  public struct AbstractImageBuilderContext<Q> where Q : IIntegerCoordinate
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