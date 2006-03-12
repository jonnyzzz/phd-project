using System.Windows.Forms;
using EugenePetrenko.Gui2.Application.TreeNodes.MenuItems;
using EugenePetrenko.Gui2.Controls.TreeControl;
using EugenePetrenko.Gui2.Kernell2.Container;
using EugenePetrenko.Gui2.Kernell2.Node;

namespace EugenePetrenko.Gui2.Application.TreeNodes
{
    /// <summary>
    /// Summary description for Node.
    /// </summary>
    public class Node : ComputationNode
    {
        private KernelNode kernelNode;
        private int iterations;		

        public Node(KernelNode kernelNode, int iterations)
        {
            this.kernelNode = kernelNode;
            this.iterations = iterations;    
			Update();
        }

        public int Iterations
        {
            get { return iterations; }
        }

		
        public override string NodeCaption
        {
            get { return string.Format("{0}, iterations={1}", kernelNode.Caption, Iterations); }
        }

        private MenuItem[] cachedMenuItems = null;

        protected MenuItem[] GetMenuItemsActions()
        {
            if (cachedMenuItems == null)
            {
                cachedMenuItems = MenuItemFactory.CreateMenuItems(this, Core.Instance.NextActionFactory.GetActions());
            }
            return cachedMenuItems;
        }

        protected override MenuItem[] GetMenuItems()
        {
            Group group = Group.GetGroup(this);
            if (group.Contains(this))
            {
                return MergeWithDelimiter(GetMenuItemsActions(), new DelegatedMenuItem("Create Group", new Click(CreateGroup)));
            }
            else
            {
                return GetMenuItemsActions();
            }
        }

        public void CreateGroup()
        {
            Group group = Group.GetGroup(this);
            ComputationNode node = Parent as ComputationNode;
            if (node != null)
            {
                Node groupNode = group.CreateNode();
                node.AddNodeChild(groupNode);
                group.DeCheckAndRemoveAll();
                groupNode.TreeView.SelectedNode = groupNode;
            }
            else
            {
                MessageBox.Show("Unable to add an Group");
            }
        }

        public KernelNode KernelNode
        {
            get { return kernelNode; }
        }

		public void AddResultChild(Node[] nodes, string caption)
		{
			ResultActionNameNode node = new ResultActionNameNode(caption);
			node.AddNodeChild(nodes);
			this.AddNodeChild(node);
		}
        
        public ResultSet ResultSet
        {
            get { return KernelNode.Results; }
        }

        public void SelectionChanging()
        {
            Group group = Group.GetGroup(this);
            if (this.Checked)
            {
                group.RemoveNode(this);
            }
            else
            {
                group.AddNode(this);
            }
        }
    }
}