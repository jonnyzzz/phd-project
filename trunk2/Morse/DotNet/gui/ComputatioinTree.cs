using System;
using System.Drawing;
using System.Windows.Forms;
using MorseKernelATL;

namespace gui
{
	public delegate void ContextMenuBeforeOpenEvent(ComputationNode node);
	public delegate void MouseMoveComponentEvent(ComputationNode node);

	/// <summary>
	/// Summary description for ComputatioinTree.
	/// </summary>
	public class ComputatioinTree : System.Windows.Forms.UserControl
	{
		public event ContextMenuBeforeOpenEvent NodeMenuBeforeOpen;
		public event MouseMoveComponentEvent MouseMoveNode;        

		private System.Windows.Forms.TreeView tree;
		/// <summary> 
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.Container components = null;

		public ComputatioinTree()
		{
			// This call is required by the Windows.Forms Form Designer.
			InitializeComponent();

			if (!this.DesignMode) 
			{
				tree.Top = 0;
				tree.Left = 0;
			} 
			this.Resize += new EventHandler(ComputatioinTree_Resize);
			tree.MouseDown += new MouseEventHandler(tree_MouseDown);
			tree.MouseMove += new MouseEventHandler(tree_MouseMove);
			tree.AfterCheck += new TreeViewEventHandler(tree_AfterCheck);

		}

		/// <summary> 
		/// Clean up any resources being used.
		/// </summary>
		protected override void Dispose( bool disposing )
		{
			if( disposing )
			{
				if(components != null)
				{
					components.Dispose();
				}
			}
			base.Dispose( disposing );			
		}

		#region Component Designer generated code
		/// <summary> 
		/// Required method for Designer support - do not modify 
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent()
		{
			this.tree = new System.Windows.Forms.TreeView();
			this.SuspendLayout();
			// 
			// tree
			// 
			this.tree.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.tree.CheckBoxes = true;
			this.tree.ImageIndex = -1;
			this.tree.ImeMode = System.Windows.Forms.ImeMode.NoControl;
			this.tree.Location = new System.Drawing.Point(32, 24);
			this.tree.Name = "tree";
			this.tree.SelectedImageIndex = -1;
			this.tree.Size = new System.Drawing.Size(80, 64);
			this.tree.TabIndex = 0;
			// 
			// ComputatioinTree
			// 
			this.BackColor = System.Drawing.SystemColors.Highlight;
			this.Controls.Add(this.tree);
			this.Name = "ComputatioinTree";
			this.Size = new System.Drawing.Size(144, 112);
			this.ResumeLayout(false);

		}
		#endregion

		private void ComputatioinTree_Resize(object sender, EventArgs e)
		{
			tree.Size = this.Size;
		}
		
		/// /////////////////////////////////////////////////////////////////////
		#region functiononality

		public ComputationNode Root
		{			
			set
			{
				tree.Nodes.Clear();
				tree.Nodes.Add(value);
			}
            get
            {
                return tree.Nodes.GetEnumerator().Current as ComputationNode;
            }
		}

		public void DeselectAll()
		{
			foreach (ComputationNode computationNode in tree.Nodes)
			{
				DeselectAll(computationNode);
			}
		}

		private void DeselectAll(ComputationNode root)
		{
			if (root == null) return;

			root.Checked = false;
			foreach (ComputationNode computationNode in root.Nodes)
			{
				DeselectAll(computationNode);
			}
		}
		#endregion

		#region context menu ...

		//context menu show
		private void tree_MouseDown(object sender, MouseEventArgs e)
		{
			TreeNode treeNode = tree.GetNodeAt(e.X, e.Y);
			if (e.Button == MouseButtons.Right && treeNode is ComputationNode)
			{
				ComputationNode node = treeNode as ComputationNode;
				if (NodeMenuBeforeOpen != null)
				{
					NodeMenuBeforeOpen(node);
				}
				tree.SelectedNode = node;
				tree.Refresh();
				ContextMenu cm = new ContextMenu(node.MenuItems);
				cm.Show(this, new Point(e.X, e.Y));
			}
		}
		#endregion

		#region mouse -> node
		private ComputationNode activeNode = null;
		private void tree_MouseMove(object sender, MouseEventArgs e)
		{
			TreeNode treeNode = tree.GetNodeAt(e.X, e.Y);
			if (treeNode is ComputationNode)
			{
				ComputationNode node = treeNode as ComputationNode;

				if (node != activeNode)
				{
					activeNode = node;

					if (MouseMoveNode != null)
					{
						MouseMoveNode(node);
					}
				}
			}

		}
		#endregion

		private void tree_AfterCheck(object sender, TreeViewEventArgs e)
		{
			if (e.Node is ComputationNode)
				ComputationNode.OnAfterCheckClick(e.Node as ComputationNode);
		}


        public ComputationNode findNodeByKernelNode(IKernelNode node)
        {
            return ComputationNode.fromIKernelNode(node);
        }
	}
}