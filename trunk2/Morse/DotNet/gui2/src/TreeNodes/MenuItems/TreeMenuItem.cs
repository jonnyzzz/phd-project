using System;
using System.Collections;
using System.Drawing;
using System.Windows.Forms;
using EugenePetrenko.Gui2.Actions.Actions;

namespace EugenePetrenko.Gui2.Application.TreeNodes
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
            this.OwnerDraw = true;
        }

        protected override void OnClick(EventArgs e)
        {
            base.OnClick(e);
            EventClick();
        }

        protected abstract void EventClick();

        protected Action[] Merge(Action action, params Action[] actions)
        {
            return Merge(new Action[] {action}, actions);
        }

        protected Action[] Merge(Action[] actions1, params Action[] actions2)
        {
            ArrayList arrayList = new ArrayList();
            arrayList.AddRange(actions1);
            arrayList.AddRange(actions2);
            return (Action[]) arrayList.ToArray(typeof (Action));
        }

        #region Drawing Features

        private readonly Font defaultFont = new Font("Arial", 8);

        protected override void OnDrawItem(DrawItemEventArgs e)
        {
            base.OnDrawItem(e);

            DrawBackGround(e);
            e.DrawFocusRectangle();

            Color fontColor;
            if (isLeaf)
            {
                if ((e.State & DrawItemState.Selected) == DrawItemState.Selected)
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
                if ((e.State & DrawItemState.Selected) == DrawItemState.Selected)
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

        protected virtual void DrawBackGround(DrawItemEventArgs e)
        {
            e.DrawBackground();
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

        protected override void OnMeasureItem(MeasureItemEventArgs e)
        {
            base.OnMeasureItem(e);

            Size size = e.Graphics.MeasureString(Text, GetFont()).ToSize();
            e.ItemHeight = size.Height + 5;
            e.ItemWidth = size.Width + 15;
        }

        #endregion
    }
}