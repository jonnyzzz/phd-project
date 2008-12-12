using DSIS.Utils;

namespace DSIS.UI.Wizard
{
  public interface IWizardFormPresenter
  {
    /// <summary>
    /// 
    /// </summary>
    /// <typeparam name="T"></typeparam>
    /// <param name="wizard"></param>
    /// <returns>Dialog result and dialog is canceled</returns>
    Pair<Ref<T>, bool> ShowWizard<T>(IWizardPack<T> wizard);
  }
}