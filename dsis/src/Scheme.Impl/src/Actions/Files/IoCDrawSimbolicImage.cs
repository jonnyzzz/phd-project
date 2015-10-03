using DSIS.Core.Ioc;

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