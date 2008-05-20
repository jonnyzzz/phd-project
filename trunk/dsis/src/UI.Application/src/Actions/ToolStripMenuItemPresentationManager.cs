using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using DSIS.Scheme.Ctx;
using DSIS.Spring;

namespace DSIS.UI.Application.Actions
{
  [UsedBySpring]
  public class ToolStripMenuItemPresentationManager : BuildingActionPresentationManager<ToolStripMenuItem>, IMainMenuFactory
  {
    public ToolStripMenuItemPresentationManager(IActionPresentationManager presentation) : base(presentation)
    {
    }

    protected override ToolStripMenuItem CreateItem(ActionDescriptor descriptor, IActionHandler handler)
    {
      return new ToolStripMenuItem(descriptor.Title, null, delegate { handler.Do(new Context()); });
    }

    protected override void SetChildren(ToolStripMenuItem node, IEnumerable<ToolStripMenuItem> children)
    {
      node.DropDownItems.AddRange(children.ToArray());
    }
  }
}