using System;
using System.Windows.Forms;

namespace guiControls.TreeControl
{
	/// <summary>
	/// Summary description for ComputationNode.
	/// </summary>
	public abstract class ComputationNode : TreeNode
	{
		public abstract string NodeCaption { get; }
		public abstract MenuItem[] ContextMenuItems { get; }		
	}
}
 