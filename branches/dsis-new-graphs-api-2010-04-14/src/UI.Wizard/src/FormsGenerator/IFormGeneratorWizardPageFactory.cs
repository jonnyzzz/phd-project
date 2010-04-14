namespace DSIS.UI.Wizard.FormsGenerator
{
  public interface IFormGeneratorWizardPageFactory
  {
    IWizardPage CreatePage(string title, object obj);
  }
}