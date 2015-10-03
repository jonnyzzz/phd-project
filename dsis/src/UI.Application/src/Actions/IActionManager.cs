using System;
using System.Collections.Generic;
using System.Windows.Forms;
using Context=DSIS.Scheme.Ctx.Context;

namespace DSIS.UI.Application.Actions
{
  public interface IActionManager
  {
    void RegisterAction(string actionId, string parentActionId, IActionHandler actionHandler);
  }

  public interface IContextProvider
  {
    void AddToContext(Context ctx);
  }

  public interface IActionPresentation
  {
    bool Enabled { get; set; }
  }

  public interface IActionPresentationFactory
  {
    IActionPresentation CreatePresentation(IActionHandler actionHandler);
  }

  [AttributeUsage(AttributeTargets.Struct|AttributeTargets.Class)]
  public class MenuItemActionAttribute : Attribute
  {
    public string Name { get; set; }    
  }
  

  public class ActionManager //: IActionManager
  {
    private readonly List<IActionHandler> myActions = new List<IActionHandler>();

    public void RegisterAction(IActionHandler actionHandler)
    {
      myActions.Add(actionHandler);
    }

    private void BuildFocusContext(Control control, Context context)
    {
      if (control == null)
        return;

      var prov = control as IContextProvider;
      if (prov != null)
      {
        prov.AddToContext(context);
      }
      BuildFocusContext(control.Parent, context);
    }    
  }
}
