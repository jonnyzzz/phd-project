using System.Windows.Forms;
using DSIS.Scheme.Ctx;
using DSIS.Spring.Attributes;

namespace DSIS.UI.Application.Actions.Impl
{
  [SpringBean]
  public class AboutBoxActionHandler : ActionHandlerBase
  {
    public AboutBoxActionHandler()
      : base("Help.About")
    {
    }

    public override bool Do(Context ctx)
    {
      MessageBox.Show("DSIS by Eugene Petrenko. Copyright 2006-2008");
      return true;
    }
  }
}