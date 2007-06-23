using System;
using System.Collections.Generic;
using DSIS.CellImageBuilder;
using DSIS.CellImageBuilder.AdaptiveMethod;
using DSIS.CellImageBuilder.BoxMethod;
using DSIS.CellImageBuilders.PointMethod;
using DSIS.Core.Builders;
using DSIS.Core.Coordinates;
using DSIS.Core.Processor;
using DSIS.Core.System;
using DSIS.Core.Util;
using DSIS.Graph;
using DSIS.Graph.Abstract;
using DSIS.IntegerCoordinates;
using DSIS.IntegerCoordinates.Generated;
using DSIS.IntegerCoordinates.Impl;

namespace DSIS.SimpleRunner
{
  public abstract class FullImageBuilder<T, Q> : AbstractImageBuilder<T, Q>
    where T : IIntegerCoordinateSystem<Q>
    where Q : IIntegerCoordinate<Q>
  {
    private readonly long myStepLimit;
    private readonly long myCellsLimit;

    protected FullImageBuilder(long stepLimit, long cellsLimit)
    {
      myStepLimit = stepLimit;
      myCellsLimit = cellsLimit;

      AddListener(new ComputeEntropyListener<T,Q>());
    }

    protected override ICollection<Pair<ICellImageBuilder<Q>, ICellImageBuilderSettings>> GetMethods()
    {
      return new Pair<ICellImageBuilder<Q>, ICellImageBuilderSettings>[]
        {
          new Pair<ICellImageBuilder<Q>, ICellImageBuilderSettings>(
            new AdaptiveMethod<T, Q>(), AdaptiveMethodSettings.DEFAULT),
          new Pair<ICellImageBuilder<Q>, ICellImageBuilderSettings>(
            new PointMethod<T, Q>(), new PointMethodSettings(new int[] {3, 3})),
          new Pair<ICellImageBuilder<Q>, ICellImageBuilderSettings>(
            new PointMethod<T, Q>(), new PointMethodSettings(new int[] {3, 3}, 0.1)),
          new Pair<ICellImageBuilder<Q>, ICellImageBuilderSettings>(
            new BoxMethod<T, Q>(), BoxMethodSettings.Default),
        };
    }

    protected override bool PerformStep(CellProcessorContext<Q, Q> ctx, AbstractImageBuilderContext<Q> cx, long stepCount)
    {
      return (myCellsLimit < 0 || ctx.Cells.Count < myCellsLimit) && 
              (myStepLimit < 0 || stepCount < myStepLimit);
    }

    protected override IGraphWithStrongComponent<Q> CreateGraph(T system)
    {
      return new TarjanGraph<Q>(system);
    }

    protected virtual T CreateCoordinateSystem(ISystemInfo info)
    {
      if (typeof(T) == typeof(IntegerCoordinateSystem))
        return (T)(object)new IntegerCoordinateSystem(info.SystemSpace);
      if (typeof(T) == typeof(IntegerCoordinateSystem2d))
        return (T)(object)new IntegerCoordinateSystem2d(info.SystemSpace);
      throw new ArgumentException("Unknnown type T");
    }

    protected abstract ISystemInfo CreateSystemInfo();
    
    protected sealed override Pair<ISystemInfo, T> CreateInfos()
    {
      ISystemInfo info = CreateSystemInfo();
      return new Pair<ISystemInfo, T>(info, CreateCoordinateSystem(info));
    }
  }
}