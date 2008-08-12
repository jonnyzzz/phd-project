using System.Collections.Generic;
using DSIS.CellImageBuilder.Shared;
using DSIS.Scheme.Ctx;

namespace DSIS.Scheme.Impl.Actions
{
  public class BuildSymbolicImageAction : BuildSymbolicImageActionBase
  {
    protected override ICollection<ContextMissmatchCheck> Check<T, Q>(T system, Context ctx)
    {
      return ColBase(base.Check<T, Q>(system, ctx),
                 Create(Keys.CellImageBuilderKey),
                 Create(Keys.SubdivisionKey));
    }

    protected override ICellImageBuilderIntegerCoordinatesSettings GetCellImageBuilderSettings(Context input)
    {
      return Keys.CellImageBuilderKey.Get(input);
    }

    protected override long[] GetSubdivision(Context input)
    {
      return Keys.SubdivisionKey.Get(input);
    }
  }
}