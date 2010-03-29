using DSIS.Core.Ioc;

namespace DSIS.Scheme.Impl.Actions.Files
{
  [ComponentImplementation]
  public class IoCDrawLineImage : IoCDrawHelper<IoCDrawLineAction>
  {
    public IoCDrawLineImage(IoCDrawLineAction action)
      : base(action)
    {
    }
  }
}