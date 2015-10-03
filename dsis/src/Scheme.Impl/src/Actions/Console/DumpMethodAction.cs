using System.Collections.Generic;
using DSIS.CellImageBuilder.Shared;
using DSIS.Scheme.Ctx;
using DSIS.Scheme.Impl.Actions.Files;

namespace DSIS.Scheme.Impl.Actions.Console
{
  public class DumpMethodAction : IntegerCoordinateSystemActionBase3
  {
    protected override ICollection<ContextMissmatchCheck> Check<T, Q>(Context ctx)
    {
      return ColBase(base.Check<T, Q>(ctx), Create(Keys.SubdivisionKey), Create(Keys.CellImageBuilderKey));
    }

    protected override void Apply<T, Q>(Context input, Context output)
    {
      ICellImageBuilderIntegerCoordinatesSettings sets = Keys.CellImageBuilderKey.Get(input);

      Logger.Instance(input).Write("Method: {0}", sets.Create<Q>().PresentableName);
    }
  }
}