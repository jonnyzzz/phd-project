using DSIS.CellImageBuilder.PointMethod;
using DSIS.Scheme.Ctx;
using DSIS.Utils;

namespace DSIS.Scheme.Impl.Actions
{
  [Used]
  public class DefaultPointMethodSettings : IntegerCoordinateSystemActionBase2Ex
  {
    protected override void Apply<T, Q>(T system, Context input, Context output)
    {
      Keys.SubdivisionKey.Set(output, 2L.Fill(system.Dimension));
      Keys.CellImageBuilderKey.Set(output, new PointMethodSettings{Points=3, UseOverlapping = false});
    }
  }
}