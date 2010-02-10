using System.Collections.Generic;
using DSIS.CellImageBuilder.Shared;
using DSIS.Scheme.Ctx;
using DSIS.Utils;

namespace DSIS.Scheme.Impl.Actions
{
  public class SetMethod : ActionBase
  {
    private readonly ICellImageBuilderIntegerCoordinatesSettings mySettings;
    private readonly long[] mySubdivision;

    public SetMethod(ICellImageBuilderIntegerCoordinatesSettings settings, long[] subdivision)
    {
      mySettings = settings;
      mySubdivision = subdivision;
    }

    public override ICollection<ContextMissmatch> Compatible(Context ctx)
    {
      return EmptyArray<ContextMissmatch>.Instance;
    }

    protected override void Apply(Context ctx, Context result)
    {
      Keys.SubdivisionKey.Set(result, mySubdivision);
      Keys.CellImageBuilderKey.Set(result, mySettings);
    }
  }
}
