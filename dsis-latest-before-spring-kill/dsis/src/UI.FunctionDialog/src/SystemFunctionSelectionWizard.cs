using DSIS.Core.System;
using DSIS.Scheme.Objects.Systemx;
using DSIS.Spring.Service;
using DSIS.UI.Wizard;
using DSIS.UI.Wizard.FormsGenerator;

namespace DSIS.UI.FunctionDialog
{
  public class SystemFunctionSelectionWizard : StateWizard, ISystemFunctionSelectionWizardInt
  {
    public ISystemInfoFactory SystemFactory { get; set; }
    public IContiniousFunctionSolverFactory ContiniousFactory { get; set; }
    public IContiniousSolverParameters ContiniousParameters { get; set; }
    public ISystemInfoParameters SystemParameters { get; set; }
    public SpaceModel Space { get; set; }

    public IFormGeneratorWizardPageFactory FormGeneratorWizardPageFactory { get; private set; }

    public ISystemInfo CreateInfo()
    {
      if (SystemFactory == null)
      {
        return null;
      }

      var info = SystemFactory.Create(SystemParameters);

      if (SystemFactory.Type == SystemType.Continious)
      {
        if (ContiniousFactory == null)
          return null;

        info = ContiniousFactory.Create(info, ContiniousParameters);
      }

      return info;
    }

    public ISystemSpace CreateSpace()
    {
      return Space == null ? null : Space.Create();
    }

    public SystemFunctionSelectionWizard(IServiceProvider prov)
    {
      Title = "Define system function";
      FirstPage = new SelectSystemWizardPage(prov, this);
      FormGeneratorWizardPageFactory = prov.GetService<IFormGeneratorWizardPageFactory>();
    }
  }
}