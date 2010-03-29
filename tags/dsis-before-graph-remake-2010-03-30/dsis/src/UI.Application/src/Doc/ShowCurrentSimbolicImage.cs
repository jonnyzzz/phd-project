using DSIS.Core.Ioc;
using DSIS.Scheme.Impl.Actions.Files;
using DSIS.UI.Application.Progress;
using DSIS.UI.UI;

namespace DSIS.UI.Application.Doc
{
  [DocumentComponent]
  public class ShowCurrentSimbolicImage : ShowCurrentImageBase<IoCDrawSimbolicImage>
  {
    public ShowCurrentSimbolicImage(IApplicationDocument doc, IoCDrawSimbolicImage action, IActionExecution exec, ITypeInstantiator typeInstantiator, IInvocator invocator) 
      : base(doc, action, exec, typeInstantiator, invocator)
    {
    }

    public override string ControlTitle
    {
      get { return "Symbolic Image"; }
    }

    public override string SortOrder
    {
      get { return "000a"; }
    }
  }
}