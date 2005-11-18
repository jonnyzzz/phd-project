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
            ConstraintCheck(node);

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


        protected void ConstraintCheck(Node aNode)
        {
            if (aNode.ResultSet.Count != 1) throw new GroupException("Incorrect node type. Such node can not be added to that group");

            foreach (Node node in nodes)
            {
                if (node.Parent != aNode.Parent) throw new GroupException("Group can only be built from nodes recieved from one result");
                if (!ResultSet.HasEqualsGraph(node.ResultSet, aNode.ResultSet)) throw new GroupException("Unable to add this node due to uncomparable type");
            }
        }

        public ResultSet[] ResultSets
        {
            get
            {
                ArrayList list = new ArrayList();
                foreach (Node node in nodes)
                {
                    list.Add(node.ResultSet);
                }
                return (ResultSet[]) list.ToArray(typeof (ResultSet));
            }
        }

        public ResultSet CreateResultSet()
        {
            return ResultSet.FromResultSets(ResultSets);
        }

        public Node CreateNode()
        {
            //TODO:!!!
            return new Node(new KernelNode(CreateResultSet()), ((Node) nodes[0]).Iterations);
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