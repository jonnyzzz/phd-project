using System;
using System.Drawing;
using System.Windows.Forms;
using gui2.TreeNodes;
using guiActions.Actions;
using guiKernel2.ActionFactory;

namespace gui2.src.TreeNodes.MenuItems
{
	/// <summary>
	/// Summary description for DisabledActionMuniItem.
	/// </summary>
	public class DisabledActionMuniItem : TreeMenuItem
	{
	    private readonly string comment;

	    public DisabledActionMuniItem(IDisabledAction action) : base(action.Caption, false)
	    {
	        this.comment = action.Comment;
            this.Enabled = false;
            
            if (comment != null)
            {
                this.MenuItems.Add(new CommentMenuItem(comment) );
            }
	    }

	    public string Comment
	    {
	        get { return comment; }
	    }

	    protected override void EventClick()
	    {
	    }

	    protected override void DrawBackGround(DrawItemEventArgs e)
	    {            
	        e.Graphics.FillRectangle(new SolidBrush(Color.DarkSalmon), e.Bounds);
	    }
	}
}
