using DSIS.Core.Builders;
using DSIS.Core.Coordinates;
using DSIS.Core.System;
using DSIS.Graph;
using DSIS.IntegerCoordinates;

namespace DSIS.SimpleRunner
{
  public interface IAbstractImageBuilderListener<T,Q>
    where T : IIntegerCoordinateSystem<Q>
    where Q : IIntegerCoordinate<Q>
  {
    void ComputationStarted(T system, AbstractImageBuilderContext<Q> cx);
    void OnStepStarted(T system, AbstractImageBuilderContext<Q> cx);    
    void GraphConstructed(IGraph<Q> graph, T system, AbstractImageBuilderContext<Q> cx);
    void GraphComponentsConstructed(IGraphStrongComponents<Q> comps, IGraph<Q> graph, T system, AbstractImageBuilderContext<Q> cx);
    void OnStepFinished(IGraphStrongComponents<Q> comps, IGraph<Q> graph, T system, AbstractImageBuilderContext<Q> cx);    
    void ComputationFinished(IGraphStrongComponents<Q> comps, IGraph<Q> graph, T system, AbstractImageBuilderContext<Q> cx);
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