using System.Collections.Generic;
using DSIS.Utils;

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

    public string Title { get; set;}

    public IWizardPage FirstPage
    {
      get { return myWizards.GetFirst().FirstPage; }
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