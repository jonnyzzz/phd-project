using System;
using System.Collections.Generic;
using DSIS.CellImageBuilder.Shared;
using DSIS.Scheme.Ctx;
using DSIS.Scheme.Impl.Actions.Files;
using DSIS.Utils;

namespace DSIS.Scheme.Impl.Actions.Console
{
  public class DumpMethodAction : IntegerCoordinateSystemActionBase2
  {
    protected override ICollection<ContextMissmatchCheck> Check<T, Q>(T system, Context ctx)
    {
      return ColBase(base.Check<T, Q>(system, ctx), Create(Keys.SubdivisionKey), Create(Keys.CellImageBuilderKey));
    }

    protected override void Apply<T, Q>(T system, Context input, Context output)
    {
      ICellImageBuilderIntegerCoordinatesSettings sets = Keys.CellImageBuilderKey.Get(input);

      Logger.Instance(input).Write("Method: {0}", sets.Create<T,Q>().PresentableName);
    }
  }
}