using System.Collections;
using System.Windows.Forms;
using EugenePetrenko.Gui2.Controls.TreeControl.MenuItems;
using EugenePetrenko.Gui2.Logging;

namespace EugenePetrenko.Gui2.Controls.TreeControl
{
    /// <summary>
    /// Summary description for ComputationNode.
    /// </summary>
    /// 

	public delegate void KeyPressed(KeyEventArgs key);

    public abstract class ComputationNode : TreeNode
    {
		public event KeyPressed OnKeyPressed;

        public abstract string NodeCaption { get; }
        protected abstract MenuItem[] GetMenuItems();

    	public ComputationNode()
    	{
    	}

    	private MenuItem[] cachedMenuItems = null;

        public MenuItem[] ContextMenuItems
        {
            get
            {
                if (this.IsSelected)
                {
                    return MergeWithDelimiter(GetMenuItems(), new DeselectMenuItem(this));
                }
                else
                {
                    if (cachedMenuItems == null)
                    {
                        cachedMenuItems = GetMenuItems();
                    }
                    return cachedMenuItems;
                }
            }
        }
						
		public void AddNodeChild(params ComputationNode[] node)
		{
			Logger.LogMessage("Adding Node");

			if (this.TreeView != null)
			{
				this.TreeView.BeginUpdate();
			}

			this.Nodes.AddRange(node);
			if (this.TreeView != null && node.Length != 0)
			{
				this.Expand();
				node[0].EnsureVisible();
			}

			if (this.TreeView != null)
			{
				this.TreeView.EndUpdate();
			}
		}

        public void Update()
        {
            this.Text = this.NodeCaption;
        }

		public void FireKeyPressed(KeyEventArgs key)
		{
			if (OnKeyPressed != null)
			{
				OnKeyPressed(key);
			}
		}

        #region helpers

        protected MenuItem[] Merge(MenuItem[] first, params MenuItem[] second)
        {
            ArrayList items = new ArrayList();
            items.AddRange(first);
            items.AddRange(second);
            return (MenuItem[]) items.ToArray(typeof (MenuItem));
        }

        protected MenuItem[] MergeWithDelimiter(MenuItem[] first, params MenuItem[] second)
        {
            if (first.Length > 0)
            {
                return Merge(Merge(first, new DelimiterMenuItem()), second);
            }
            else
            {
                return second;
            }
        }

        #endregion
    }
}