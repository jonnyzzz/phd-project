using DSIS.CellImageBuilder.Shared;
using EugenePetrenko.Shared.Core.Ioc.Api;

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