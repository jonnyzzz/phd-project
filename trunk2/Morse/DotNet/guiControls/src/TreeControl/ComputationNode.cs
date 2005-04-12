using System;
using System.Collections;
using System.Windows.Forms;
using guiControls.TreeControl.MenuItems;

namespace guiControls.TreeControl
{
	/// <summary>
	/// Summary description for ComputationNode.
	/// </summary>
	public abstract class ComputationNode : TreeNode
	{
		public abstract string NodeCaption { get; }
		
		protected abstract MenuItem[] GetMenuItems();
        
		public MenuItem[] ContextMenuItems { 
			get
			{
				if (this.IsSelected)
				{
					return MergeWithDelimiter(GetMenuItems(), new DeselectMenuItem(this));
				} else
				{
					return GetMenuItems();
				}
			} 
		}


		public ComputationNode() : base()
		{
			
		}
		
		public void Update() 
		{
			this.Text = this.NodeCaption;
		}


		#region helpers

		protected MenuItem[] Merge(MenuItem[] first, params MenuItem[] second)
		{
			ArrayList items = new ArrayList();
			items.AddRange(first);
			items.AddRange(second);
			return (MenuItem[])items.ToArray(typeof(MenuItem)); 
		}

		protected MenuItem[] MergeWithDelimiter(MenuItem[] first, params MenuItem[] second)
		{
			if (first.Length > 0)
			{
				return Merge(Merge(first, new DelimiterMenuItem()), second);
			} else
			{
				return second;
			}
		}

		#endregion
	}
}
 