using System.Collections.Generic;
using DSIS.CellImageBuilder.Shared;
using DSIS.Scheme.Ctx;

namespace DSIS.Scheme.Impl.Actions.Console
{
  public class DumpMethodAction : IntegerCoordinateSystemActionBase2
  {
    protected override ICollection<ContextMissmatchCheck> Check<T, Q>(T system, Context ctx)
    {
      return ColBase(base.Check<T, Q>(system, ctx), Create(Keys.SubdivisionKey), Create(Keys.CellImageBuilderKey));
;
    }

    protected override void Apply<T, Q>(T system, Context input, Context output)
    {
      long[] longs = Keys.SubdivisionKey.Get(input);
      ICellImageBuilderIntegerCoordinatesSettings sets = Keys.CellImageBuilderKey.Get(input);

      System.Console.Out.WriteLine("Method: {0}", sets.Create<T,Q>().PresentableName);
    }
  }
}