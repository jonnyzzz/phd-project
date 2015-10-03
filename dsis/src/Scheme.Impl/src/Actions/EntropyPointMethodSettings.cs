using DSIS.CellImageBuilder.PointMethod;
using DSIS.Scheme.Ctx;
using DSIS.Utils;

namespace DSIS.Scheme.Impl.Actions
{
  [Used]
  public class EntropyPointMethodSettings : IntegerCoordinateSystemActionBase3
  {
    protected override void Apply<T, Q>(Context input, Context output)
    {
      Keys.SubdivisionKey.Set(output, 2L.Fill(Dimension));
      Keys.CellImageBuilderKey.Set(output, new PointMethodSettings { Points = 3, UseOverlapping = false });
    }
  }
}