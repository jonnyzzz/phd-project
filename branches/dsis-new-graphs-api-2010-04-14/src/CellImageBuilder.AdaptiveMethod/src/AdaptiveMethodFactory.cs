using DSIS.CellImageBuilder.Shared;
using DSIS.Core.Ioc;

namespace DSIS.CellImageBuilder.AdaptiveMethod
{
  [ComponentImplementation]
  public class AdaptiveMethodFactory : CellImageBuilderIntegerCoordinateFactory<AdaptiveMethodSettings>
  {
    public AdaptiveMethodFactory()
    {
      FactoryName = "Adaptive Method";
    }
  }
}