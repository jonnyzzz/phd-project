using System.Windows.Forms;

namespace EugenePetrenko.Core.FormGenerator.Dialog
{
  public interface IDialogModel
  {
    Control Control { get; }
    bool Ok();
    bool Cancel();
  }
}