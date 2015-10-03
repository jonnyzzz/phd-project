using DSIS.Core.Ioc;
using DSIS.Scheme.Impl.Actions.Files;
using DSIS.UI.Application.Progress;
using DSIS.UI.UI;

namespace DSIS.UI.Application.Doc
{
  [DocumentComponent]
  public class ShowCurrentLineImage : ShowCurrentImageBase<IoCDrawLineImage>
  {
    public ShowCurrentLineImage(IApplicationDocument doc, IoCDrawLineImage action, IActionExecution exec, ITypeInstantiator typeInstantiator, IInvocator invocator) 
      : base(doc, action, exec, typeInstantiator, invocator)
    {
    }

    public override string ControlTitle
    {
      get { return "Line Image"; }
    }

    public override string SortOrder
    {
      get { return "000z"; }
    }
  }
}