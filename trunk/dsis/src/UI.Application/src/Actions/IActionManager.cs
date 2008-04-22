using System;
using System.Collections.Generic;
using System.Windows.Forms;
using Context=DSIS.Scheme.Ctx.Context;

namespace DSIS.UI.Application.Actions
{
  public interface IUIAction
  {
    bool Enabled(Context ctx);
    void Do(Context ctx);    
  }

  public interface IActionManager
  {
    void RegisterAction(IUIAction action);
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
    IActionPresentation CreatePresentation(IUIAction action);
  }

  [AttributeUsage(AttributeTargets.Struct|AttributeTargets.Class)]
  public class MenuItemActionAttribute : Attribute
  {
    public string Name { get; set; }    
  }
  

  public class ActionManager : IActionManager
  {
    private readonly List<IUIAction> myActions = new List<IUIAction>();

    public void RegisterAction(IUIAction action)
    {
      myActions.Add(action);
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
