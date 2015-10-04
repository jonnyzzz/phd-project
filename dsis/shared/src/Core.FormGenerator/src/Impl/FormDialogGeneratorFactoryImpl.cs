using System.Windows.Forms;
using EugenePetrenko.Core.FormGenerator.Api;
using EugenePetrenko.Core.FormGenerator.Dialog;
using EugenePetrenko.Core.FormGenerator.ErrorProvider;
using EugenePetrenko.Shared.Core.Ioc.Api;

namespace EugenePetrenko.Core.FormGenerator.Impl
{
  [ComponentImplementation]
  public class FormDialogGeneratorFactoryImpl : IFormDialogGeneratorFactory
  {
    [Autowire]
    private IFormGeneratorFactory myGen { get; set; }

    [Autowire]
    private IDialogFactory myDialog { get; set; }

    public Form CreateDialog(object data)
    {
      var form = myGen.CreateForm(data);
      var model = new DialogModel(form);
      return myDialog.CreateDialog(model);
    }

    private class DialogModel : IDialogModel
    {
      private readonly Control myControl;

      public DialogModel(Control control)
      {
        myControl = control;
      }

      public Control Control
      {
        get { return myControl; }
      }

      public bool Ok()
      {
        var ok = myControl as IErrorProvider<bool>;
        if (ok != null && !ok.ValidateData())
        {
          MessageBox.Show(myControl, "Ошибка заполнения формы");
          return false;
        }
        return true;
      }

      public bool Cancel()
      {
        return true;
      }
    }
  }
}