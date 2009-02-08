using DSIS.Utils;

namespace DSIS.UI.Wizard
{
  public abstract class StateWizard : IWizardPack
  {
    public string Title { get; protected set; }

    public IWizardPage FirstPage { get; protected set; }

    public virtual bool IsLastPage(IWizardPage page)
    {
      return ((IWizardPageWithState)page).IsLastPage;
    }

    public IWizardPage Next(IWizardPage page)
    {
      return ((IWizardPageWithState) page).NextPage;
    }

    public Ref<string> ValidateLazy(IWizardPage page)
    {
      return Ref.Null<string>();
    }

    public virtual void OnFinish()
    {
    }

    public virtual void OnCancel()
    {
    }

    public void PageShown(IWizardPage page)
    {      
    }
  }
}