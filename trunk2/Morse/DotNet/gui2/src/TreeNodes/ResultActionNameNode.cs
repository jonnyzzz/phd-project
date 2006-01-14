using System;
using System.Windows.Forms;
using EugenePetrenko.Gui2.Application.Forms;
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
		private MenuItem item;

		public ResultActionNameNode(string name)
		{
			Logger.LogMessage("Result Action: {0}", name);
			this.name = name;
			
			this.item = new RenameMenuItem(this);
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
				item};
		}

		protected void SetCaption(string caption)
		{
			this.name = caption;
			Update();			
		}

		class RenameMenuItem : TreeMenuItem
		{
			private readonly ResultActionNameNode action;

			public RenameMenuItem(ResultActionNameNode action) : base("Rename")
			{
				this.action = action;

			}

			protected override void EventClick()
			{
				using( UserComment cmt = new UserComment(action.NodeCaption)) 
				{
					if (cmt.ShowDialog(Runner.Runner.Instance.ComputationForm) == DialogResult.OK)
						action.SetCaption(cmt.UserCommentText);
				}
			}
		}

		private void ResultActionNameNode_OnKeyPressed(KeyEventArgs key)
		{
			if (key.KeyCode == Keys.F2)
				item.PerformClick();
		}
	}
}
