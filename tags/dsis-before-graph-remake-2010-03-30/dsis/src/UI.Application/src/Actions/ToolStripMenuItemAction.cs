using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using DSIS.Scheme.Ctx;

namespace DSIS.UI.Application.Actions
{
  public class ToolStripMenuItemAction : ToolStripMenuItem, IMenuItem<ToolStripItem>
  {
    private readonly ActionDescriptor myDescriptor;
    private readonly IActionHandler myHander;
    private readonly Func<Context> myContext;

    public ToolStripMenuItemAction(ActionDescriptor descriptor, IActionHandler hander, Func<Context> context)
    {
      myDescriptor = descriptor;
      myHander = hander;
      myContext = context;

      Text = descriptor.Title;
      Click += delegate { hander.Do(CreateContext()); };
      OwnerChanged += ToolStripMenuItemAction_OwnerChanged;
    }

    void ToolStripMenuItemAction_OwnerChanged(object sender, System.EventArgs e)
    {
      if (Owner != null)
        Owner.Text = "Owner of " + Text;
    }

    private Context CreateContext()
    {
      return myContext();
    }

    public ToolStripItem MainMenu
    {
      get { return this; }
    }

    public ICollection<IMenuItem<ToolStripItem>> Children
    {
      get { return Enumerable.ToArray(DropDownItems.OfType<IMenuItem<ToolStripItem>>()); }
    }

    public void Update()
    {
      Enabled = DropDownItems.Count > 0 || myHander.Enabled(CreateContext());
      foreach (var menu in DropDownItems.OfType<IMenuItem<ToolStripItem>>())
      {
        menu.Update();
      }
    }
  }
}