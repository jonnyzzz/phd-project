using System;
using System.Collections;
using System.Drawing;
using System.Windows.Forms;
using guiActions.Actions;


namespace gui2.TreeNodes
{
	/// <summary>
	/// Summary description for TreeMenuItem.
	/// </summary>
	/// 

	public abstract class TreeMenuItem : MenuItem
	{
		private readonly bool isLeaf;


		public TreeMenuItem(string caption) : this(caption, false)
		{
			
		}

		public TreeMenuItem(string caption, bool isLeaf) : base(caption)
		{
			this.isLeaf = isLeaf;
			this.Click +=new EventHandler(TreeMenuItem_Click);
			this.DrawItem += new DrawItemEventHandler(DrawCustomMenuItem);
			this.MeasureItem +=new MeasureItemEventHandler(MeasureCustomItem);
		}

		protected abstract void EventClick();
		private void TreeMenuItem_Click(object sender, EventArgs e)
		{
			EventClick();
		}



		protected Action[] Merge(Action action, params Action[] actions)
		{
			return Merge(new Action[]{action}, actions );
		}

		protected Action[] Merge(Action[] actions1, params Action[] actions2)
		{
			ArrayList arrayList = new ArrayList();
			arrayList.AddRange(actions1);
			arrayList.AddRange(actions2);
			return (Action[])arrayList.ToArray(typeof(Action));
		}


		#region Drawing Features
		private readonly Font defaultFont = new Font("Arial", 8);
		private void DrawCustomMenuItem(object sender, DrawItemEventArgs e)
		{
			e.DrawBackground();
			e.DrawFocusRectangle();
					
			Color fontColor;
			if (isLeaf)
			{
				if ( (e.State & DrawItemState.Selected) == DrawItemState.Selected)
				{
					fontColor = Color.Yellow;
				} 
				else 
				{
					fontColor = Color.Blue;
				}
			} 
			else
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
			if (isLeaf)
			{
				font = new Font(defaultFont, FontStyle.Bold | FontStyle.Underline);	
			} 
			else
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
	}
}
