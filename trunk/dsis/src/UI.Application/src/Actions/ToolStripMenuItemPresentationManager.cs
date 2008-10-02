using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using DSIS.Scheme.Ctx;
using DSIS.Spring;

namespace DSIS.UI.Application.Actions
{
  [UsedBySpring]
  public class ToolStripMenuItemPresentationManager : BuildingActionPresentationManager<ToolStripItem>, IMainMenuFactory
  {
    public ToolStripMenuItemPresentationManager(IActionPresentationManager presentation) : base(presentation)
    {
    }

    protected override ToolStripItem CreateItem(IActionDescriptor descriptor, IActionHandler handler)
    {
      if (descriptor is ActionDescriptor)
        return new ToolStripMenuItem(
          ((ActionDescriptor)descriptor).Title, 
          null, 
          delegate { handler.Do(new Context()); }
          );
      else if (descriptor is SeparatorDescriptor)
      {
        return new ToolStripSeparator();        
      }
      return null;
    }

    protected override void SetChildren(ToolStripItem node, IEnumerable<ToolStripItem> children)
    {
      ((ToolStripDropDownItem)node).DropDownItems.AddRange(children.ToArray());
    }
  }
}