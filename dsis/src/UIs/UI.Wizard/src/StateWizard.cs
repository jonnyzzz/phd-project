using System;

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

    public bool IsBackAllowed(IWizardPage page)
    {
      return true;
    }

    public IWizardPage Next(IWizardPage page)
    {
      return ((IWizardPageWithState) page).NextPage;
    }

    public ValidationResult ValidateLazy(IWizardPage page)
    {
      return ValidationResult.Ok;
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