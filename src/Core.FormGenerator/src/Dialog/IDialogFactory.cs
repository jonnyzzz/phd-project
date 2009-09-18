using System.Windows.Forms;

namespace EugenePetrenko.Core.FormGenerator.Dialog
{
  public interface IDialogFactory
  {
    Form CreateDialog(IDialogModel model);
  }
}