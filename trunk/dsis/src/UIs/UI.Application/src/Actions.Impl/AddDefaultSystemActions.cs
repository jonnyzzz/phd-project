using System;
using DSIS.Scheme.Ctx;
using DSIS.Scheme.Objects.Systemx;
using DSIS.UI.UI;
using DSIS.Utils;

namespace DSIS.UI.Application.Actions.Impl
{
  [ActionHandler(Startable = true)]
  public class AddDefaultSystemActions //: IStartableComponent
  {
    private const string ACTION_PARENT = "File.PredefinedSystems";

    private readonly IActionPresentationManager myPresentation;
    private readonly IApplicationDocumentFactory myFactory;
    private readonly IApplicationClass myApp;
    private readonly ISystemInfoPredefinedFactory[] myPredefinedSystems;

    public AddDefaultSystemActions(
      IActionPresentationManager presentation,
      ISystemInfoPredefinedFactory[] predefinedSystems, 
      IApplicationDocumentFactory factory,
      IApplicationClass app,
      ActionHandlerBeanProcessor _,
      IMainForm mainForm)
    {
      myPresentation = presentation;
      myApp = app;
      myFactory = factory;
      myPredefinedSystems = predefinedSystems;

      mainForm.BeforeFormCreated += delegate { Start(); };
    }

    private void Start()
    {
      var list = myPredefinedSystems.Sort((x, y) => x.Name.CompareTo(y.Name));
      foreach (var _sys in list)
      {
        var sys = _sys;
        var id = "File.PredefinedSystem." + sys.Name + Guid.NewGuid();
        myPresentation.AddActionDescriptor(id, ACTION_PARENT, sys.Name, "", sys.Name);
        myPresentation.RegisterHandler(
          new PredefinedActionHandler(
            () =>
            myApp.Document =
            myFactory.CreateNewDocument(sys.Name, sys.Function, sys.Space),
            id));
      }
    }

    private class PredefinedActionHandler : ActionHandlerBase
    {
      private readonly Action myAction;

      public PredefinedActionHandler(Action action, params string[] actionId) : base(actionId)
      {
        myAction = action;
      }

      public override bool Enabled(Context ctx)
      {
        return true;
      }

      public override bool Do(Context ctx)
      {
        myAction();
        return true;
      }
    }
  }
}