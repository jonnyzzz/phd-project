using EugenePetrenko.Shared.Core.Ioc.Api;

namespace DSIS.Scheme.Impl.Actions.Files
{
  [ComponentImplementation]
  public class IoCDrawSimbolicImage : IoCDrawHelper<IocDrawSimbolicImageAction>
  {
    public IoCDrawSimbolicImage(IocDrawSimbolicImageAction action) : base(action)
    {
    }
  }
}