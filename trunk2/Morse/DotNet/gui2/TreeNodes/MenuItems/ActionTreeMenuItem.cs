using System;
using System.Drawing;
using System.Windows.Forms;
using gui2.ActionPerformer;
using guiActions.Actions;
using guiKernel2.Actions;
using guiKernel2.ActionFactory;
using guiKernel2.Container;

namespace gui2.TreeNodes
{
	/// <summary>
	/// Summary description for ActionTreeMenuItem.
	/// </summary>
	public class ActionTreeMenuItem : TreeMenuItem
	{
		private Action action;
		private Action[] actionPath;
		private Node node;

		public ActionTreeMenuItem(Node node, Action action, params Action[] beforeActions) : base(action.ActionName)
		{
			this.action = action;
			this.node = node;

			this.MenuItems.Clear();
			actionPath = Merge(beforeActions, action);
			this.MenuItems.AddRange(
				MenuItemFactory.CreateMenuItems(
				node, 
				node.GetActionAfer(actionPath),
				actionPath
				));

			this.OwnerDraw = true;
			this.DrawItem += new DrawItemEventHandler(DrawCustomMenuItem);
			this.MeasureItem +=new MeasureItemEventHandler(MeasureCustomItem);
		}


		#region Drawing Features
		private readonly Font defaultFont = new Font("Arial", 8);
		private void DrawCustomMenuItem(object sender, DrawItemEventArgs e)
		{
			e.DrawBackground();
			e.DrawFocusRectangle();
					
			Color fontColor;
			if (action.IsChainLeaf)
			{
				if ( (e.State & DrawItemState.Selected) == DrawItemState.Selected)
				{
					fontColor = Color.Yellow;
				} 
				else 
				{
					fontColor = Color.Blue;
				}
			} else
			{
				if ( (e.State & DrawItemState.Selected) == DrawItemState.Selected)
				{
					fontColor = Color.White;
				} 
				else 
				{
					fontColor = Color.Black;
				}
			}

            Brush brush = new SolidBrush(fontColor);

			Font font = GetFont();

			StringFormat format = new StringFormat();
			format.Alignment = StringAlignment.Near;
			format.LineAlignment = StringAlignment.Center;
			int xOffset = 15;
			Rectangle bounds = new Rectangle(e.Bounds.X + xOffset, e.Bounds.Y, e.Bounds.Width - xOffset, e.Bounds.Height);
			e.Graphics.DrawString(Text, font, brush, bounds, format);			
		}

		private Font GetFont()
		{
			Font font;
			if (action.IsChainLeaf)
			{
				font = new Font(defaultFont, FontStyle.Bold | FontStyle.Underline);	
			} else
			{
				font = defaultFont;
			}
			return font;
		}

		private void MeasureCustomItem(object sender, MeasureItemEventArgs e)
		{
			Size size = e.Graphics.MeasureString(Text,GetFont()).ToSize();
			e.ItemHeight = size.Height + 5;
			e.ItemWidth = size.Width + 15;
		}
		#endregion
		
		protected override void EventClick()
		{
			if (action.IsChainLeaf)
			{
				Logger.Logger.LogMessage("Event Click");
				Runner.Runner.Instance.ComputationForm.AcceptActionChain(node, actionPath);
			}
		}

		
	}
}
