namespace DSIS.UI.Wizard
{
  public interface IWizardPack<T>
  {
    IWizardPack Controller { get; }
    T GetResult();
  }
}