using System.Windows.Forms;

namespace DSIS.UI.Wizard
{
  /// <summary>
  /// Represents page from Wizard.
  /// This interface is used as a key to dictionary. 
  /// </summary>
  public interface IWizardPage
  {
    /// <summary>
    /// Title to be show in the head banner of the Wizzard form
    /// </summary>
    string Title { get; }

    /// <summary>
    /// Control instance to be shown in the Wizzard for body.
    /// All calls should return the same values.
    /// </summary>
    Control Control { get; }

    /// <summary>
    /// Validates internal state of the control to check if it is possible to move
    /// to the next control in queue
    /// </summary>
    /// <returns></returns>
    bool Validate();

    /// <summary>
    /// Notifies that control is shown
    /// </summary>
    void ControlShown();

    /// <summary>
    /// Notifies that the page is hidden. User is able to get back to the page,
    /// thus control will be reused and <b>ControlShown</b>  method will be called.
    /// </summary>
    void ControlHidden();
  }

  public interface IWizardPageWithState : IWizardPage
  {
    IWizardPageWithState NextPage { get;  }
  }
}
