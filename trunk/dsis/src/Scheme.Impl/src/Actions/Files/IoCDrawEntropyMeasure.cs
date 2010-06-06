
using EugenePetrenko.Shared.Core.Ioc.Api;

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