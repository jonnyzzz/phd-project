using System.Collections.Generic;

namespace DSIS.UI.Wizard
{
  public class JoinedWizardPack //: IWizardPack
  {
    //TODO:  Implelent me
    private readonly List<IWizardPack> myWizards;

    public JoinedWizardPack(List<IWizardPack> wizards)
    {
      myWizards = wizards;
    }

    public string Title
    {
      get { throw new System.NotImplementedException(); }
    }

    public IWizardPage FirstPage
    {
      get { return myWizards[0].FirstPage; }
    }

    public bool IsLastPage(IWizardPage page)
    {
      throw new System.NotImplementedException();
    }

    public IWizardPage Next(IWizardPage page)
    {
      throw new System.NotImplementedException();
    }

    public void OnFinish()
    {
      throw new System.NotImplementedException();
    }

    public void OnCancel()
    {
      throw new System.NotImplementedException();
    }
  }
}