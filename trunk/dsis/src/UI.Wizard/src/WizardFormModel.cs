using System.Collections.Generic;
using System.Windows.Forms;
using DSIS.Utils;

namespace DSIS.UI.Wizard
{
  public class WizardFormModel
  {
    private readonly List<WizardPage> myPages = new List<WizardPage>();

    private class WizardPage
    {
      public readonly IWizardPage myPage;
      public readonly Control myControl;
      public readonly WizardPage Prev;

      private List<WizardPage> myNextPages;
      
      public IEnumerable<WizardPage> NextPages()
      {
        return myNextPages ?? (myNextPages = new List<WizardPage>(myPage.NextPages.Map(x => new WizardPage(x, this))));
      }

      public WizardPage(IWizardPage page, WizardPage prev)
      {
        myPage = page;
        Prev = prev;
        myControl = page.CreateControl();
      }
    }
  }
}