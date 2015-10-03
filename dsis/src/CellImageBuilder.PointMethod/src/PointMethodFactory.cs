using DSIS.CellImageBuilder.Shared;
using DSIS.Scheme.Objects.Systemx;

namespace DSIS.CellImageBuilder.PointMethod
{
  [CellImageBuilderComponent]
  public class PointMethodFactory : CellImageBuilderIntegerCoordinateFactory<PointMethodSettings>
  {
    public PointMethodFactory()
    {
      FactoryName = "Point Method";
    }
  }
}