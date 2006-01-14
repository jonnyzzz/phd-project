using System.Collections;
using EugenePetrenko.Gui2.Kernell2.Node;

namespace EugenePetrenko.Gui2.Application.TreeNodes
{
    /// <summary>
    /// Summary description for GroupNode.
    /// </summary>
    public class Group
    {
        private ArrayList nodes = new ArrayList();

        public Group()
        {
        }

        /// <summary>
        /// Trys to add a node, if fails GroupException was thrown
        /// </summary>
        /// <param name="node"></param>
        public void AddNode(Node node)
        {
            nodes.Add(node);
        }

        public void RemoveNode(Node node)
        {
            nodes.Remove(node);
        }

        public bool Contains(Node node)
        {
            return nodes.Contains(node);
        }
        
        public Node CreateNode()
        {
        	NodeResultSet set = new NodeResultSet((Node[]) nodes.ToArray(typeof(Node)));
        	int iterations = ((Node) nodes[0]).Iterations;
        	return new Node(new KernelNode(set), iterations);
        }

        public void DeCheckAndRemoveAll()
        {
            ArrayList tempNodes = new ArrayList(nodes);
            foreach (Node node in tempNodes)
            {
                node.Checked = false;
                RemoveNode(node); //thats not necessary because of event activity
            }
        }


        private static Group instance = null;

        public static Group GetGroup(Node node)
        {
            if (instance == null)
            {
                instance = new Group();
            }
            return instance;
        }
    }
}