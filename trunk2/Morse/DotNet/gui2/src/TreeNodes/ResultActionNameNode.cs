using System;
using System.Windows.Forms;
using EugenePetrenko.Gui2.Application.Forms;
using EugenePetrenko.Gui2.Application.TreeNodes.MenuItems;
using EugenePetrenko.Gui2.Controls.TreeControl;
using EugenePetrenko.Gui2.Logging;

namespace EugenePetrenko.Gui2.Application.TreeNodes
{
	/// <summary>
	/// Summary description for ResultActionNameNode.
	/// </summary>
	public class ResultActionNameNode : ComputationNode
	{
		private string name;

		public ResultActionNameNode(string name)
		{
			Logger.LogMessage("Result Action: {0}", name);
			this.name = name;
			
			Update();			

			this.Expand();
			this.OnKeyPressed += new KeyPressed(ResultActionNameNode_OnKeyPressed);
		}

		public override string NodeCaption
		{
			get { return name; }
		}

		protected override MenuItem[] GetMenuItems()
		{			
			return new MenuItem[] {
									  new DelegatedMenuItem("Rename", new Click(OnRemame)),
									  new DelegatedMenuItem("Create Group From Childs", new Click(OnCreateGroup))
				};
		}

		private void OnCreateGroup()
		{
			Group group = Group.GetGroup(this);
			group.DeCheckAndRemoveAll();

			Node node = null;
			try
			{
				foreach (TreeNode treeNode in Nodes)
				{
					if (treeNode is Node)
					{
						node = (Node) treeNode;
						node.Checked = true;
					}
				}
				if (node != null)
				{
					node.CreateGroup();
				}
			}
			catch (GroupException e)
			{
				MessageBox.Show(Runner.Runner.Instance.ComputationForm, e.Message);
				group.DeCheckAndRemoveAll();
			}
		}

		private void OnRemame()
		{
			using( UserCommentForm cmt = new UserCommentForm(NodeCaption)) 
			{
				if (cmt.ShowDialog(Runner.Runner.Instance.ComputationForm) == DialogResult.OK)
					SetCaption(cmt.UserCommentText);
			}
		}
		
		private void ResultActionNameNode_OnKeyPressed(KeyEventArgs key)
		{
			if (key.KeyCode == Keys.F2)
				OnRemame();
		}

		private void SetCaption(string caption)
		{
			this.name = caption;
			Update();			
		}
		
	}
}
