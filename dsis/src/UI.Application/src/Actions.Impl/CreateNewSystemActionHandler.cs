using DSIS.Core.Ioc;
using DSIS.Core.System;
using DSIS.Scheme.Ctx;
using DSIS.UI.FunctionDialog;
using DSIS.UI.UI;
using DSIS.UI.Wizard;
using log4net;

namespace DSIS.UI.Application.Actions.Impl
{
  [ActionHandler]
  public class CreateNewSystemActionHandler : ActionHandlerBase
  {
    private readonly ILog LOG = LogManager.GetLogger(typeof (CreateNewSystemActionHandler));

    [Autowire]
    private IApplicationDocumentFactory myFactory { get; set; }

    [Autowire]
    private IApplicationClass myApp { get; set; }

    [Autowire]
    private SelectSystemInfoProviderWizardFactory SystemInfoProviderWizardFactory { get; set; }

    [Autowire]
    private IWizardFormPresenter Presenter { get; set; }

    [Autowire]
    private ContiniousSystemParametersWizardFactory ContiniousWizardFactory { get; set; }

    [Autowire]
    private SelectSystemSpaceWizardFactory SpaceWizardFactory { get; set; }

    [Autowire]
    private SelectDocumentTitleWizardFactory TitleFactory { get; set; }

    public CreateNewSystemActionHandler()
      : base("System.Create", "File.Create")
    {
    }

    public override bool Do(Context ctx)
    {
      LOG.InfoFormat("Show create system dialod");

      var factory = Presenter.ShowWizard(SystemInfoProviderWizardFactory);
      if (!factory.Second)
        return true;

      LOG.InfoFormat("Selected {0} factory provider", factory.First.Value.Name);

      var info = Presenter.ShowWizard(factory.First.Value.CreateWizard());
      if (!info.Second)
        return true;

      var systemInfo = info.First.Value;
      LOG.InfoFormat("Selected {0}[{1}] system", systemInfo.PresentableName, systemInfo.Type);
      if (systemInfo.Type == SystemType.Continious)
      {
        LOG.Info("Call continious solver wizard");
        info = Presenter.ShowWizard(ContiniousWizardFactory.CreateWizard(systemInfo));
        
        if (!info.Second)
        {
          return true;
        }

        systemInfo = info.First.Value;
      }

      if (systemInfo.Type != SystemType.Discrete)
      {
        LOG.ErrorFormat("Failed to create document from non-descrete system. {0}, {1}", systemInfo, systemInfo.GetType());
        return true;
      }

      LOG.InfoFormat("Show system space selector for {0} (dimension={1})", systemInfo, systemInfo.Dimension);
      var space = Presenter.ShowWizard(SpaceWizardFactory.CreateWizard(systemInfo));
      if (!space.Second)
        return true;

      var systemSpace = space.First.Value;

      var title = Presenter.ShowWizard(TitleFactory.Create(systemInfo, systemSpace));
      if (!title.Second)
        return true;
      

      myApp.Document = myFactory.CreateNewDocument(title.First.Value, systemInfo, systemSpace);      
      return true;
    }
  }
}