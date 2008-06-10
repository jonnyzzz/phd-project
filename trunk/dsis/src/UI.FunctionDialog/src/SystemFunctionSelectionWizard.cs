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
    object ContiniousParameters { get; set; }
    object SystemParameters { get; set; }
    SpaceModel Space { get; set; }
  }

  public class SystemFunctionSelectionWizard : StateWizard, ISystemFunctionSelectionWizardInt
  {
    private IApplicationDocument myDocument;
    private readonly IApplicationDocumentFactory myFactory;

    public ISystemInfoFactory SystemFactory { get; set; }
    public IContiniousFunctionSolverFactory ContiniousFactory { get; set; }
    public object ContiniousParameters { get; set; }
    public object SystemParameters { get; set; }
    public SpaceModel Space { get; set; }

    public SystemFunctionSelectionWizard(IServiceProvider prov)
    {
      Title = "Define system function";
      myFactory = new ApplicationDocumentFactory();
      FirstPage = new SelectSystemWizardPage(prov, this);
    }
  }
}