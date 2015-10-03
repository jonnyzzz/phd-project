using DSIS.CellImageBuilder.Shared;
using DSIS.Scheme.Ctx;
using DSIS.Utils;

namespace DSIS.Scheme.Impl.Actions
{
  public class SetMethod2 : IntegerCoordinateSystemActionBase3
  {
    private readonly ICellImageBuilderIntegerCoordinatesSettings mySettings;
    private readonly long mySubdivision;

    public SetMethod2(ICellImageBuilderIntegerCoordinatesSettings settings, long subdivision)
    {
      mySettings = settings;
      mySubdivision = subdivision;
    }

    protected override void Apply<T, Q>(Context input, Context output)
    {
      Keys.SubdivisionKey.Set(output, mySubdivision.Fill(Dimension));
      Keys.CellImageBuilderKey.Set(output, mySettings);
    }
  }
}