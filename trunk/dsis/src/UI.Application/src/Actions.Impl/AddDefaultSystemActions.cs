using System;
using DSIS.Core.Ioc;
using DSIS.Scheme.Ctx;
using DSIS.Scheme.Objects.Systemx;
using DSIS.UI.UI;
using DSIS.Utils;

namespace DSIS.UI.Application.Actions.Impl
{
  [ActionHandler(Startable = true)]
  public class AddDefaultSystemActions : IStartableComponent
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
      ActionHandlerBeanProcessor _)
    {
      myPresentation = presentation;
      myApp = app;
      myFactory = factory;
      myPredefinedSystems = predefinedSystems;
    }

    public void Start()
    {
      var list = myPredefinedSystems.Sort((x, y) => x.Name.CompareTo(y.Name));
      foreach (var sys in list)
      {
        sys.With(x =>
                   {
                     var id = "File.PredefinedSystem." + x.Name + Guid.NewGuid();
                     myPresentation.AddActionDescriptor(id, ACTION_PARENT, x.Name, "", x.Name);
                     myPresentation.RegisterHandler(
                       new PredefinedActionHandler(
                         () =>
                         myApp.Document =
                         myFactory.CreateNewDocument(x.Name, x.Function, x.Space),
                         id));
                   });
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