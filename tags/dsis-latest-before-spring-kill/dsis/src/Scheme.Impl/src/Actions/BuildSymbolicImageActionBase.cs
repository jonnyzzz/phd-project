using System;
using System.Collections.Generic;
using DSIS.CellImageBuilder.Shared;
using DSIS.Core.Builders;
using DSIS.Core.Coordinates;
using DSIS.Core.Processor;
using DSIS.Core.System;
using DSIS.Core.Util;
using DSIS.Graph.Abstract;
using DSIS.Graph.Adapter;
using DSIS.IntegerCoordinates;
using DSIS.Scheme.Ctx;
using DSIS.Scheme.Impl.Actions.Performance;
using DSIS.Utils;

namespace DSIS.Scheme.Impl.Actions
{
  public abstract class BuildSymbolicImageActionBase : IntegerCoordinateSystemActionBase3
  {
    protected abstract ICellImageBuilderIntegerCoordinatesSettings GetCellImageBuilderSettings(Context input);

    protected abstract long[] GetSubdivision(Context input);

    protected override ICollection<ContextMissmatchCheck> Check<T, Q>(Context ctx)
    {
      return ColBase(EmptyArray<ContextMissmatchCheck>.Instance, 
                     Create(Keys.SystemInfoKey),
                     Create(Keys.CellsEnumerationKey<Q>())
        );
    }

    protected override void Apply<T, Q>(Context input, Context output)
    {
      var bld = GetCellImageBuilderSettings(input);
      var subdivision = GetSubdivision(input);
      var cellsToBuildFrom = Keys.CellsEnumerationKey<Q>().Get(input);

      ISystemInfo info = Keys.SystemInfoKey.Get(input);

      ICellCoordinateSystemConverter<Q, Q> subdivide = cellsToBuildFrom.System.Subdivide(subdivision);
      ICellCoordinateSystem<Q> toSystem = subdivide.ToSystem;

      var graph = new TarjanGraph<Q>(toSystem);

      var cellSettings = new CellImageBuilderContext<Q>(
        info, bld, toSystem, new GraphCellImageBuilder<Q>(graph));
      
      var ctx = new CellProcessorContext<Q, Q>(
        cellsToBuildFrom,
        subdivide,
        bld.Create<Q>(),
        cellSettings
        );

      var proc = new SymbolicImageConstructionProcess<Q, Q>();
      proc.Bind(ctx);

      PerformanceSlot ps = PerformanceSlot.Get("BuildSI", SlotStore.Get(input));
      DateTime start = DateTime.Now;
      proc.Execute(NullProgressInfo.INSTANCE);
      ps.AddTimeSlot(DateTime.Now - start);

      Keys.Graph<Q>().Set(output, graph);
      Keys.IntegerCoordinateSystemInfo.Set(output, (IIntegerCoordinateSystem)toSystem);
    }
  }
}