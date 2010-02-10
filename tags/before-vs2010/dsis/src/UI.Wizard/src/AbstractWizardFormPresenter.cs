using System;
using System.Windows.Forms;
using DSIS.Core.Ioc;
using DSIS.UI.UI;
using DSIS.Utils;
using log4net;

namespace DSIS.UI.Wizard
{
  public abstract class AbstractWizardFormPresenter : IWizardFormPresenter
  {
    private static readonly ILog LOG = LogManager.GetLogger(typeof(WizardFormPresenter));

    [Autowire]
    private IApplicationClass App { get; set; }

    public Pair<Ref<T>, bool> ShowWizard<T>(IWizardPack<T> wizard)
    {
      using (var form = CreateWizardForm(wizard))
      {
        return App.ShowDialog(x =>
                                {
                                  var result = form.ShowDialog(x);
                                  if (result == DialogResult.OK)
                                  {
                                    try
                                    {
                                      return new Pair<Ref<T>, bool>(wizard.GetResult().ToRef(), true);
                                    }
                                    catch (Exception e)
                                    {
                                      LOG.ErrorFormat("Failed to call GetReulst on {0}({1})", wizard.Controller.Title, wizard.GetType());
                                      LOG.Error(e);
                                    }
                                  }

                                  return new Pair<Ref<T>, bool>(Ref.Null<T>(), false);
                                });
      }
    }

    protected abstract Form CreateWizardForm<T>(IWizardPack<T> wizard);

    public Pair<Ref<T>, bool> ShowWizard<T>(IWizardPackFactory<T> wizard)
    {
      using (var wz = wizard.CreateWizard())
      {
        return ShowWizard(wz);
      }
    }

    public T ShowWizardOrNull<T>(IWizardPack<T> wizard) where T : class
    {
      var result = ShowWizard(wizard);

      if (!result.Second)
        return null;
      if (!result.First.HasValue)
        return null;
      return result.First.Value;
    }
  }
}