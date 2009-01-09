using DSIS.Core.Ioc;
using DSIS.Core.System;
using DSIS.UI.FunctionDialog;
using DSIS.UI.Wizard;

namespace DSIS.UI.Application.Actions.Impl
{
  [SystemFunctionComponent]
  public class SelectDocumentTitleWizardFactory
  {
    [Autowire]
    private IComponentContainer Container { get; set; }

    public IWizardPack<string> Create(ISystemInfo info, ISystemSpace space)
    {
      var c = Container.SubContainer<SelectDocumentTitleComponent>();

      c.RegisterComponent(new SelectDocumentTitle.DocumentTitle{Title = info.PresentableName});

      c.Start();

      return c.GetComponent<SelectDocumentTitle>();
    }
  }
}