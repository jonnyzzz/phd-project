using System.Drawing;
using System.Windows.Forms;

namespace guiControls.TreeControl
{
	public delegate void MouseOver(ComputationNode node);
	public delegate void SelectionChanged(ComputationNode node);

	/// <summary>
	/// Summary description for ComputationTree.
	/// </summary>
	public class ComputationTree : System.Windows.Forms.UserControl
	{
		private System.Windows.Forms.TreeView tree;
		private System.Windows.Forms.ContextMenu contextMenu;
		/// <summary> 
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.Container components = null;

		public ComputationTree()
		{
			// This call is required by the Windows.Forms Form Designer.
			InitializeComponent();

			// TODO: Add any initialization after the InitializeComponent call

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
			this.contextMenu = new System.Windows.Forms.ContextMenu();
			this.SuspendLayout();
			// 
			// tree
			// 
			this.tree.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.tree.Dock = System.Windows.Forms.DockStyle.Fill;
			this.tree.ImageIndex = -1;
			this.tree.Location = new System.Drawing.Point(0, 0);
			this.tree.Name = "tree";
			this.tree.SelectedImageIndex = -1;
			this.tree.Size = new System.Drawing.Size(150, 150);
			this.tree.TabIndex = 0;
			this.tree.MouseDown += new System.Windows.Forms.MouseEventHandler(this.tree_MouseDown);
			this.tree.AfterSelect += new System.Windows.Forms.TreeViewEventHandler(this.tree_AfterSelect);
			this.tree.MouseMove += new System.Windows.Forms.MouseEventHandler(this.tree_MouseMove);
			// 
			// ComputationTree
			// 
			this.Controls.Add(this.tree);
			this.Name = "ComputationTree";
			this.ResumeLayout(false);

		}
		#endregion

		public void Clear()
		{
			tree.Nodes.Clear();
		}

		private ComputationNode root = null;

		private void tree_AfterSelect(object sender, System.Windows.Forms.TreeViewEventArgs e)
		{
			OnSelectionChanged(e.Node as ComputationNode);
		}

		private ComputationNode cachedMouseNode = null;
		private void tree_MouseMove(object sender, System.Windows.Forms.MouseEventArgs e)
		{
			ComputationNode node = tree.GetNodeAt(e.X, e.Y) as ComputationNode;
			if (node != cachedMouseNode)
			{
				cachedMouseNode = node;
				OnMouseOver(node);
			}
		}


		private void tree_MouseDown(object sender, System.Windows.Forms.MouseEventArgs e)
		{
			TreeNode anode = tree.GetNodeAt(e.X, e.Y);
			if (anode is ComputationNode)
			{
				ComputationNode node = (ComputationNode)anode;
				contextMenu.MenuItems.Clear();
				contextMenu.MenuItems.AddRange(node.ContextMenuItems);
				contextMenu.Show(this, new Point(e.X, e.Y));
			}
		}

		public ComputationNode Root
		{
			get
			{
				return root;
			}
			set
			{
				root = value;
				Clear();
				if (root != null) 
				{
					tree.Nodes.Add(root);
				}
			}
		}

		public event MouseOver OnMouseOver;
		public event SelectionChanged OnSelectionChanged;
	}
}
