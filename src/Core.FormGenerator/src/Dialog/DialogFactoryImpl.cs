using System.Windows.Forms;
using EugenePetrenko.Shared.Core.Ioc.Api;

namespace EugenePetrenko.Core.FormGenerator.Dialog
{
  [ComponentImplementation]
  public class DialogFactoryImpl : IDialogFactory
  {
    public Form CreateDialog(IDialogModel model)
    {
      return new DialogForm(model);
    }
  }
}