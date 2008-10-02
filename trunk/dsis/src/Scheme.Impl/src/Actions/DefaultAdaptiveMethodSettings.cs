using DSIS.CellImageBuilder.AdaptiveMethod;

namespace DSIS.Scheme.Impl.Actions
{
  public class DefaultAdaptiveMethodSettings : SetMethod2
  {
    public DefaultAdaptiveMethodSettings() : base(AdaptiveMethodSettings.Default, 2)
    {
    }
  }
}