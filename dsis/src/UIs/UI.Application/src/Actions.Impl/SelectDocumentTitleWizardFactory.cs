using DSIS.Core.System;
using DSIS.UI.FunctionDialog;
using DSIS.UI.Wizard;
using EugenePetrenko.Shared.Core.Ioc.Api;

namespace DSIS.UI.Application.Actions.Impl
{
  [SystemFunctionComponent]
  public class SelectDocumentTitleWizardFactory
  {
    [Autowire]
    private ITypeInstantiator Container { get; set; }

    public IWizardPack<string> Create(ISystemInfo info, ISystemSpace space)
    {
      return Container.Instanciate<SelectDocumentTitle>(
        new SelectDocumentTitle.DocumentTitle {Title = info.PresentableName});
    }
  }
}