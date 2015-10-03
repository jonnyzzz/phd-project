using DSIS.UI.Wizard;

namespace DSIS.UI.FunctionDialog
{
  public interface IWizardPageWithStateFactory
  {
    IWizardPageWithState Create();
  }
}