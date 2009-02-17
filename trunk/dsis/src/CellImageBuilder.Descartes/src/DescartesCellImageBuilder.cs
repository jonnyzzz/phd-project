using System;
using System.Linq;
using DSIS.CellImageBuilder.Shared;
using DSIS.Core.Builders;
using DSIS.Core.System;
using DSIS.IntegerCoordinates;
using DSIS.IntegerCoordinates.Generated;
using DSIS.Utils;

namespace DSIS.CellImageBuilder.Descartes
{
  public class DescartesCellImageBuilder<Q> : IntegerCoordinateMethodBase<Q, DescartesSettings>, ICellImageBuilder<Q>
    where Q : IIntegerCoordinate
  {
    private Pair<int, int> myRange;
    private ICellImageBuilderIntegerCoordinatesSettings mySettings;

    private readonly GeneratedIntegerCoordinateFactory myIcsFactory;

    protected override void Bind(DescartesSettings settings, CellImageBuilderContext<Q> context)
    {
      var systemInfo = context.Function as ISplittableSystemInfo;

      if (systemInfo == null)
      {
        throw new Exception("Failed to create Decartes method for non-splittable system function");
      }
    }

    private void InitializePointMethod(int from, int to, ICellImageBuilderSettings settings, CellImageBuilderContext<Q> ctx, ISplittableSystemInfo splitSystem)
    {
      var info = splitSystem.ForRange(from, to);
      var sp = new RangeSystemSpace(ctx.System.SystemSpace, from, to);
      var ics = myIcsFactory.Create(sp, sp.Slice(ctx.System.Subdivision));

      var builder = new CellConnectionBuilder<Q>();
/*
      var localContext = new CellImageBuilderContext<Q>(
        info,
        settings,
        ics,
        builder
        );
*/
    }
  
    public override void BuildImage(Q coord)
    {
      throw new System.NotImplementedException();
    }

    public override ICellImageBuilder<Q> Clone()
    {
      return new DescartesCellImageBuilder<Q>();
    }
  }
}