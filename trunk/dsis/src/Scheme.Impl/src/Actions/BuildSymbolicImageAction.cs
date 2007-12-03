using DSIS.CellImageBuilder.Shared;
using DSIS.Core.Builders;
using DSIS.Core.Coordinates;
using DSIS.Core.Processor;
using DSIS.Core.System;
using DSIS.Graph.Abstract;
using DSIS.Graph.Adapter;
using DSIS.IntegerCoordinates;
using DSIS.Scheme.Ctx;

namespace DSIS.Scheme.Impl.Actions
{
  public class BuildSymbolicImageAction : IntegerCoordinateSystemActionBase
  {
    protected override With Create(Context @in, Context @out)
    {
      return new With2(@in, @out);
    }

    protected override Check Create(Context @in)
    {
      return new Check2(@in);
    }

    protected class Check2 : Check
    {
      public Check2(Context context) : base(context)
      {
      }

      public override void Do<T, Q>(T system)
      {
        base.Do<T, Q>(system);
        Result.Add(Create(Keys.SystemInfoKey));
        Result.Add(Create(Keys.CellImageBuilderKey));
        Result.Add(Create(Keys.CellsEnumerationKey<Q>()));
        Result.Add(Create(Keys.SubdivisionKey));
        Result.Add(Create(Keys.ProgressInfoKey));
      }
    }

    protected class With2 : With
    {
      public With2(Context context, Context outputContext) : base(context, outputContext)
      {
      }

      public override void Do<T, Q>(T system)
      {
        ISystemInfo info = Keys.SystemInfoKey.Get(myContext);
        ICellImageBuilderIntegerCoordinatesSettings bld = Keys.CellImageBuilderKey.Get(myContext);
        long[] subdivision = Keys.SubdivisionKey.Get(myContext);

        ICellCoordinateSystemConverter<Q, Q> subdivide = system.Subdivide(subdivision);
        ICellCoordinateSystem<Q> toSystem = subdivide.ToSystem;

        TarjanGraph<Q> graph = new TarjanGraph<Q>(toSystem);

        CellImageBuilderContext<Q> cellSettings = new CellImageBuilderContext<Q>(
          info, bld, system, new GraphCellImageBuilder<Q>(graph));

        CellProcessorContext<Q, Q> ctx = new CellProcessorContext<Q, Q>(
          Keys.CellsEnumerationKey<Q>().Get(myContext),
          subdivide,
          bld.Create<T, Q>(),
          cellSettings
          );

        ICellProcessor<Q, Q> proc = new SymbolicImageConstructionProcess<Q, Q>();
        proc.Bind(ctx);

        proc.Execute(Keys.ProgressInfoKey.Get(myContext));

        Keys.Graph<Q>().Set(myOutputContext, graph);
        Keys.IntegerCoordinateSystemInfo.Set(myOutputContext, (IIntegerCoordinateSystemInfo)toSystem);
      }
    }
  }
}