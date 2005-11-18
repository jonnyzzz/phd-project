using System.Windows.Forms;
using EugenePetrenko.Gui2.Actions.Actions;
using EugenePetrenko.Gui2.Actions.Filters;
using EugenePetrenko.Gui2.Application.TreeNodes.MenuItems;
using EugenePetrenko.Gui2.Controls.TreeControl;
using EugenePetrenko.Gui2.Kernell2.Node;
using EugenePetrenko.Gui2.Logging;

namespace EugenePetrenko.Gui2.Application.TreeNodes
{
    /// <summary>
    /// Summary description for Node.
    /// </summary>
    public class Node : ComputationNode
    {
        private KernelNode kernelNode;
        private int iterations;

        public Node(KernelNode kernelNode, int iterations) : base()
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
                cachedMenuItems = MenuItemFactory.CreateMenuItems(this, Filter.FilterActions(kernelNode.GetNextActions()));
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
            else if (this.Nodes.Count > 0)
            {
                return MergeWithDelimiter(GetMenuItemsActions(), new DelegatedMenuItem("Group all childs", new Click(CreateGroupClick)));
            }
            else
            {
                return GetMenuItemsActions();
            }
        }


        private void CreateGroupClick()
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

        private void CreateGroup()
        {
            Group group = Group.GetGroup(this);
            Node node = Parent as Node;
            if (node != null)
            {
                Node groupNode = group.CreateNode();
                node.AddNodeChild(groupNode);
                group.DeCheckAndRemoveAll();
                groupNode.TreeView.SelectedNode = groupNode;
            }
            else
            {
                MessageBox.Show("Unable to add an Group for such a strange case");
            }
        }


        public KernelNode KernelNode
        {
            get { return kernelNode; }
        }

        public Action[] GetActions()
        {
            return Filter.FilterActions(kernelNode.GetNextActions());
        }

        public Action[] GetActionAfter(Action[] chain)
        {
            return Filter.FilterActions(kernelNode.GetNextActionsAfter(Filter.ToActionWrapper(chain)));
        }

        public void AddNodeChild(Node node)
        {
            Logger.LogMessage("Adding Node");

            this.Nodes.Add(node);
            if (this.TreeView != null)
            {
                this.Expand();
                node.EnsureVisible();
            }
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