using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;

namespace EugenePetrenko.Gui2.Controls.TreeControl
{
  public delegate void MouseOver(ComputationNode node);

  public delegate void SelectionChanged(ComputationNode node);

  public delegate bool BeforeCheckChanged(ComputationNode node);

  /// <summary>
  /// Summary description for ComputationTree.
  /// </summary>
  public class ComputationTree : UserControl
  {
    private TreeView tree;
    private ContextMenu contextMenu;

    /// <summary> 
    /// Required designer variable.
    /// </summary>
    private Container components = null;

    public ComputationTree()
    {
      // This call is required by the Windows.Forms Form Designer.
      InitializeComponent();
      tree.BackColor = Color.White;

      if (!DesignMode)
      {
        tree.Nodes.Clear();
      }

      tree.BeforeCheck += new TreeViewCancelEventHandler(BeforeCheck);
      tree.KeyDown += new KeyEventHandler(tree_KeyDown);
    }

    /// <summary> 
    /// Clean up any resources being used.
    /// </summary>
    protected override void Dispose(bool disposing)
    {
      if (disposing)
      {
        if (components != null)
        {
          components.Dispose();
        }
      }
      base.Dispose(disposing);
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
      this.tree.CheckBoxes = true;
      this.tree.Dock = System.Windows.Forms.DockStyle.Fill;
      this.tree.ImageIndex = -1;
      this.tree.Location = new System.Drawing.Point(0, 0);
      this.tree.Name = "tree";
      this.tree.Nodes.AddRange(new System.Windows.Forms.TreeNode[]
                                 {
                                   new System.Windows.Forms.TreeNode("Node0")
                                 });
      this.tree.PathSeparator = "/";
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
    private ComputationNode myCurrentSelectedNode = null;

    private void tree_AfterSelect(object sender, TreeViewEventArgs e)
    {
      if (OnSelectionChanged != null)
      {
        if (e.Node != myCurrentSelectedNode)
        {
          myCurrentSelectedNode = e.Node as ComputationNode;
          OnSelectionChanged(myCurrentSelectedNode);
        }
      }
    }

    private ComputationNode cachedMouseNode = null;

    private void tree_MouseMove(object sender, MouseEventArgs e)
    {
      ComputationNode node = tree.GetNodeAt(e.X, e.Y) as ComputationNode;
      if (node != cachedMouseNode)
      {
        cachedMouseNode = node;
        if (OnMouseOver != null)
        {
          OnMouseOver(node);
        }
      }
    }


    private void tree_MouseDown(object sender, MouseEventArgs e)
    {
      TreeNode node = tree.GetNodeAt(e.X, e.Y);
      if (node is ComputationNode && e.Button == MouseButtons.Right)
      {
        ShowPopupMenu((ComputationNode) node, new Point(e.X, e.Y));
        tree.SelectedNode = node;
      }
    }

    private void tree_KeyDown(object sender, KeyEventArgs e)
    {
      ComputationNode node = tree.SelectedNode as ComputationNode;
      if (node != null)
      {
        node.FireKeyPressed(e);

        if (e.KeyCode == Keys.Apps)
          ShowPopupMenu(node, node.Bounds.Location);
      }

      if (e.KeyCode == Keys.Apps && SelectedNode != null)
      {
        ShowPopupMenu(SelectedNode, new Point(10, 10));
      }
    }


    private void ShowPopupMenu(ComputationNode node, Point pt)
    {
      contextMenu.MenuItems.Clear();
      contextMenu.MenuItems.AddRange(CreateMenuItemsList(node.ContextMenuItems));
      contextMenu.Show(this, pt);
    }

    private MenuItem[] CreateMenuItemsList(MenuItem[] input)
    {
      if (input.Length > 0)
      {
        return input;
      }
      else
      {
        return new MenuItem[] {new NoMenuItem()};
      }
    }

    public ComputationNode Root
    {
      get { return root; }
      set
      {
        tree.BeginUpdate();

        try
        {
          root = value;
          Clear();
          if (root != null)
          {
            tree.Nodes.Add(root);
          }
        }
        finally
        {
          tree.EndUpdate();
        }
      }
    }

    public event MouseOver OnMouseOver;
    public event SelectionChanged OnSelectionChanged;
    public event BeforeCheckChanged OnBeforeCheckChanged;

    private volatile bool insideBeforeCheck = false;

    public ComputationNode SelectedNode
    {
      get { return tree.SelectedNode as ComputationNode; }
    }

    public MenuItem[] SelectedNodeMenus
    {
      get
      {
        ComputationNode node = SelectedNode;
        if (node != null)
          return node.ContextMenuItems;
        return null;
      }
    }

    private void BeforeCheck(object sender, TreeViewCancelEventArgs e)
    {
      if (!insideBeforeCheck)
      {
        insideBeforeCheck = true;

        if (e.Node is ComputationNode && OnBeforeCheckChanged != null)
        {
          e.Cancel = OnBeforeCheckChanged(e.Node as ComputationNode);
        }

        insideBeforeCheck = false;
      }
    }
  }
}