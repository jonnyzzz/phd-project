using System;
using System.Windows.Forms;
using DSIS.Scheme.Ctx;
using DSIS.Spring.Attributes;

namespace DSIS.UI.Application.Actions.Impl
{
  [SpringBean, ActionHandler]
  public class AboutBoxActionHandler : ActionHandlerBase
  {
    public AboutBoxActionHandler()
      : base("Help.About")
    {
    }

    public override bool Do(Context ctx)
    {
      MessageBox.Show(string.Format("DSIS by Eugene Petrenko. Copyright 2006-{0}", Math.Max(2009, DateTime.Now.Year)));
      return true;
    }
  }
}