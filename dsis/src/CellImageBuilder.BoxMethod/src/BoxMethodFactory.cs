using DSIS.CellImageBuilder.Shared;
using DSIS.Scheme.Objects.Systemx;

namespace DSIS.CellImageBuilder.BoxMethod
{
  [CellImageBuilderComponent]
  public class BoxMethodFactory : CellImageBuilderIntegerCoordinateFactory<BoxMethodSettings>
  {
    public BoxMethodFactory()
    {
      FactoryName = "Box Method";
    }
  }
}