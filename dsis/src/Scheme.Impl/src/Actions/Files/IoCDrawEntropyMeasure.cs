using DSIS.Core.Ioc;

namespace DSIS.Scheme.Impl.Actions.Files
{
  [ComponentImplementation]
  public class IoCDrawEntropyMeasure : IoCDrawHelper<IoCDrawEntropyMeasureWithBaseAction>
  {
    public IoCDrawEntropyMeasure(IoCDrawEntropyMeasureWithBaseAction action) : base(action)
    {
    }
  }
}