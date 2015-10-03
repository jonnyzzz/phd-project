using System;
using DSIS.CellImageBuilder.Shared;
using DSIS.Scheme.Ctx;

namespace DSIS.Scheme.Impl.Actions
{
  public class BuildSymbolicImageAction : BuildSymbolicImageActionBase
  {
    protected override void GetChecks<T, Q>(T system, Action<ContextMissmatchCheck> addCheck)
    {
      base.GetChecks<T,Q>(system, addCheck);
      addCheck(Create(Keys.CellImageBuilderKey));
      addCheck(Create(Keys.SubdivisionKey));
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