using System.Windows.Forms;
using EugenePetrenko.Core.FormGenerator.Layout;
using EugenePetrenko.Shared.Core.Ioc.Api;

namespace EugenePetrenko.Core.FormGenerator.Dialog
{
  [ComponentImplementation]
  public class DialogFactoryImpl : IDialogFactory
  {
    [Autowire]
    private IScrollableLayout myScroll { get; set; }

    public Form CreateDialog(IDialogModel model)
    {
      return new DialogForm(model, myScroll);
    }
  }
}