using DSIS.CellImageBuilder.Shared;
using DSIS.Core.Ioc;

namespace DSIS.CellImageBuilder.BoxAdaptiveMethod
{
  [ComponentImplementation]
  public class BoxAdaptiveMethodFactory : CellImageBuilderIntegerCoordinateFactory<BoxAdaptiveMethodSettings>
  {
    public BoxAdaptiveMethodFactory()
    {
      FactoryName = "Box Adaptive Method";
    }
  }
}