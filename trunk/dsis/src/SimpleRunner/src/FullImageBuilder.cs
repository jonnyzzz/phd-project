using System;
using System.Collections.Generic;
using DSIS.CellImageBuilder.BoxMethod;
using DSIS.CellImageBuilder.PointMethod;
using DSIS.Core.Builders;
using DSIS.Core.Processor;
using DSIS.Core.System;
using DSIS.Graph;
using DSIS.Graph.Abstract;
using DSIS.IntegerCoordinates;
using DSIS.Utils;

namespace DSIS.SimpleRunner
{
  public abstract class FullImageBuilder<T, Q> : AbstractImageBuilder<T, Q>
    where T : IIntegerCoordinateSystem<Q>
    where Q : IIntegerCoordinate
  {
    private readonly long myStepLimit;
    private readonly long myCellsLimit;

    protected FullImageBuilder(long stepLimit, long cellsLimit)
    {
      myStepLimit = stepLimit;
      myCellsLimit = cellsLimit;      
    }

    protected override ICollection<Pair<ICellImageBuilder<Q>, ICellImageBuilderSettings>> GetMethods()
    {
      return new Pair<ICellImageBuilder<Q>, ICellImageBuilderSettings>[]
        {
//          new Pair<ICellImageBuilder<Q>, ICellImageBuilderSettings>(
//            new AdaptiveMethod<T, Q>(), AdaptiveMethodSettings.DEFAULT),
          new Pair<ICellImageBuilder<Q>, ICellImageBuilderSettings>(
            new PointMethod<T, Q>(), new PointMethodSettings(new int[] {3, 3})),
//          new Pair<ICellImageBuilder<Q>, ICellImageBuilderSettings>(
//            new PointMethod<T, Q>(), new PointMethodSettings(new int[] {3, 3}, 0.1)),
          new Pair<ICellImageBuilder<Q>, ICellImageBuilderSettings>(
            new BoxMethod<T, Q>(), BoxMethodSettings.Default),
//          new Pair<ICellImageBuilder<Q>, ICellImageBuilderSettings>(
//            new BoxAdaptiveMethod<T,Q>(), BoxAdaptiveMethodSettings.Default),
        };  
    }

    protected override bool PerformStep(ICellProcessorContext<Q,Q> ctx, AbstractImageBuilderContext<Q> cx, long stepCount)
    {
      long limit = UseUnsimmetric ? myStepLimit * ctx.CellImageBuilderContext.Function.Dimension : myStepLimit;

      return (myCellsLimit < 0 || ctx.Cells.Count < myCellsLimit) && 
             (myStepLimit < 0 || stepCount < limit);
    }

    protected override IGraphWithStrongComponent<Q> CreateGraph(T system)
    {
      return new TarjanGraph<Q>(system);
    }

    protected override T CreateCoordinateSystem(ISystemInfo info)
    {
      throw new Exception("Refactoring required. ISystemSpace!");
      /*
      if (typeof(T) == typeof(IntegerCoordinateSystem))
        return (T)(object)new IntegerCoordinateSystem(info.SystemSpace);
      if (typeof(T) == typeof(IntegerCoordinateSystem2d))
        return (T)(object)new IntegerCoordinateSystem2d(info.SystemSpace);
      throw new ArgumentException("Unknnown type T");
       */
    }            
  }
}