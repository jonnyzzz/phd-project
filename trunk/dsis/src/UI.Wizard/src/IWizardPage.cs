using System.Collections.Generic;
using System.Windows.Forms;

namespace DSIS.UI.Wizard
{
  public interface IWizardPage
  {
    string Title { get; }

    IWizardPage PrevPage { get; }
    IEnumerable<IWizardPage> NextPages { get; }

    Control Control { get; }
    bool Validate();
  }

  public interface IWizardPack
  {
    IWizardPage FirstPage { get; }

    bool IsLastPage(IWizardPage page);
    IEnumerable<IWizardPage> Next(IWizardPage page);    
  }
}
