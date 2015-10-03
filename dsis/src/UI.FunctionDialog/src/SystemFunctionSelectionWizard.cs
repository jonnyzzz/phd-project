using System.Windows.Forms;
using DSIS.Core.System;
using DSIS.Scheme.Objects.Systemx;
using DSIS.Spring.Service;
using DSIS.UI.UI;
using DSIS.UI.Wizard;

namespace DSIS.UI.FunctionDialog
{
  public interface ISystemFunctionSelectionWizardInt
  {
    ISystemInfoFactory SystemFactory{ get; set; }
    IContiniousFunctionSolverFactory ContiniousFactory { get; set; }
    IContiniousSolverParameters ContiniousParameters { get; set; }
    ISystemInfoParameters SystemParameters { get; set; }
    SpaceModel Space { get; set; }

    ISystemInfo CreateInfo();
    ISystemSpace CreateSpace();
  }

  public class SystemFunctionSelectionWizard : StateWizard, ISystemFunctionSelectionWizardInt
  {
    private IApplicationDocument myDocument;
    private readonly IApplicationDocumentFactory myFactory;

    public ISystemInfoFactory SystemFactory { get; set; }
    public IContiniousFunctionSolverFactory ContiniousFactory { get; set; }
    public IContiniousSolverParameters ContiniousParameters { get; set; }
    public ISystemInfoParameters SystemParameters { get; set; }
    public SpaceModel Space { get; set; }

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
      myFactory = new ApplicationDocumentFactory();
      FirstPage = new SelectSystemWizardPage(prov, this);
    }

    public override void OnFinish()
    {
      base.OnFinish();
      MessageBox.Show("Finished!");
    }
  }
}