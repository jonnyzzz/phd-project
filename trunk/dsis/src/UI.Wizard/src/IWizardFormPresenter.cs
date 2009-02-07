using DSIS.Utils;

namespace DSIS.UI.Wizard
{
  public interface IWizardFormPresenter
  {
    /// <summary>
    /// Shows wizard for a given wizard descriptor
    /// </summary>
    /// <typeparam name="T"></typeparam>
    /// <param name="wizard"></param>
    /// <returns>Dialog result and dialog is canceled</returns>
    Pair<Ref<T>, bool> ShowWizard<T>(IWizardPack<T> wizard);

    Pair<Ref<T>, bool> ShowWizard<T>(IWizardPackFactory<T> wizard);
  }
}