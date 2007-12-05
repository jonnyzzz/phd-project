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

namespace DSIS.Scheme.Impl.Actions
{
  public class BuildSymbolicImageAction : IntegerCoordinateSystemActionBase2
  {
    protected override ICollection<ContextMissmatchCheck> Check<T, Q>(T system, Context ctx)
    {
      return ColBase(base.Check<T, Q>(system, ctx), Create(Keys.SystemInfoKey),
                 Create(Keys.CellImageBuilderKey),
                 Create(Keys.CellsEnumerationKey<Q>()),
                 Create(Keys.SubdivisionKey));
    }

    protected override void Apply<T, Q>(T system, Context input, Context output)
    {
      ISystemInfo info = Keys.SystemInfoKey.Get(input);
      ICellImageBuilderIntegerCoordinatesSettings bld = Keys.CellImageBuilderKey.Get(input);
      long[] subdivision = Keys.SubdivisionKey.Get(input);

      ICellCoordinateSystemConverter<Q, Q> subdivide = system.Subdivide(subdivision);
      ICellCoordinateSystem<Q> toSystem = subdivide.ToSystem;

      TarjanGraph<Q> graph = new TarjanGraph<Q>(toSystem);

      CellImageBuilderContext<Q> cellSettings = new CellImageBuilderContext<Q>(
        info, bld, system, new GraphCellImageBuilder<Q>(graph));

      CellProcessorContext<Q, Q> ctx = new CellProcessorContext<Q, Q>(
        Keys.CellsEnumerationKey<Q>().Get(input),
        subdivide,
        bld.Create<T, Q>(),
        cellSettings
        );

      ICellProcessor<Q, Q> proc = new SymbolicImageConstructionProcess<Q, Q>();
      proc.Bind(ctx);

      proc.Execute(NullProgressInfo.INSTANCE);

      Keys.Graph<Q>().Set(output, graph);
      Keys.IntegerCoordinateSystemInfo.Set(output, (IIntegerCoordinateSystemInfo)toSystem);
    }   
  }
}