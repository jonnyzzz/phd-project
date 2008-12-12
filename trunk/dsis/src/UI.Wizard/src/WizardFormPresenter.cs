using System.Windows.Forms;
using DSIS.Core.Ioc;
using DSIS.UI.UI;
using DSIS.Utils;

namespace DSIS.UI.Wizard
{
  [ComponentImplementation]
  public class WizardFormPresenter : IWizardFormPresenter
  {
    [Autowire]
    private IApplicationClass App { get; set; }

    public Pair<Ref<T>, bool> ShowWizard<T>(IWizardPack<T> wizard)
    {
      using(var form = new WizardForm(wizard.Controller))
      {
        return App.ShowDialog(x =>
                                {
                                  var result = form.ShowDialog(x);
                                  if (result == DialogResult.OK)
                                  {
                                    return new Pair<Ref<T>, bool>(wizard.GetResult().ToRef(), true);
                                  }
                                  else
                                  {
                                    return new Pair<Ref<T>, bool>(Ref.Null<T>(), false);
                                  }
                                });        
      }
    }
  }
}