using DSIS.Spring.Service;
using DSIS.UI.UI;
using DSIS.UI.Wizard;

namespace DSIS.UI.FunctionDialog
{
  public interface ISystemFunctionSelectionWizardInt
  {
    IApplicationDocument Document { get; set; }
    IApplicationDocumentFactory Factory { get; }
  }

  public class SystemFunctionSelectionWizard : StateWizard, ISystemFunctionSelectionWizardInt
  {
    private IApplicationDocument myDocument;
    private readonly IApplicationDocumentFactory myFactory;

    public SystemFunctionSelectionWizard(IServiceProvider prov)
    {
      Title = "Define system function";
      FirstPage = new SelectSystemWizardPage(prov, this);
      myFactory = new ApplicationDocumentFactory();
    }

    public IApplicationDocument Document
    {
      get { return myDocument; }
    }

    IApplicationDocument ISystemFunctionSelectionWizardInt.Document
    {
      get { return Document; }
      set { myDocument = value; }
    }

    public IApplicationDocumentFactory Factory
    {
      get { return myFactory; }
    }
  }
}