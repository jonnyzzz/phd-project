using DSIS.CellImageBuilder.Shared;
using EugenePetrenko.Shared.Core.Ioc.Api;

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