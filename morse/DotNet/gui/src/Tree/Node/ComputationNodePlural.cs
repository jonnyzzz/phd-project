using System;
using System.Collections;
using System.Windows.Forms;
using gui.Tree.Node.Factory;
using gui.Tree.Node.Menu;
using MorseKernelATL;

namespace gui.Tree.Node
{
	/// <summary>
	/// Summary description for ComputationNodePlural.
	/// </summary>
	public class ComputationNodePlural
	{
		private ArrayList nodes = new ArrayList();

		public ComputationNodePlural() : base()
		{
		}

		public ComputationNodeMenuItem[] getMenuItems()
		{
			if (nodes.Count == 0)
				return new ComputationNodeMenuItem[] {};
			else return new ComputationNodeMenuItem[]
				{
					ComputationNodeMenuFactory.getMenuCreateGroupNode(
						new ComputationNodeMenuFactory.UniversalMenuItemClick(onCreateNode)
						)
				};
		}

		public int Length
		{
			get
			{
				return nodes.Count;
			}
		}

		private void onCreateNode()
		{
			ComputationNodeSingular node = (nodes[0] as ComputationNodeSingular);
			IKernelNode kernelNode = null;
			if (node.Node is CSymbolicImageGraph)
			{
				CSymbolicImageGroup gr = Runner.Kernel.CreateSymbolicImageGroup() as CSymbolicImageGroup;
				foreach (ComputationNodeSingular nodeSingular in nodes)
				{
					gr.addNode(nodeSingular.Node as CSymbolicImageGraph);
				}
				kernelNode = gr;
			}
			else if (node.Node is CProjectiveBundleGraph)
			{
				CProjectiveBundleGroup gr = Runner.Kernel.CreateProjectiveBundleGroup() as CProjectiveBundleGroup;
				foreach (ComputationNodeSingular nodeSingular in nodes)
				{
					gr.addNode(nodeSingular.Node as CProjectiveBundleGraph);
				}
				kernelNode = gr;
			}
			else
			{
				throw new Exception("Strange!!!state!!!exception!!!");
			}

			TreeNode parent = (node.Parent == null)? node: node.Parent;
			ComputationNode result = ComputationNode.createComputationNode(kernelNode);
			parent.Nodes.Add(result);

			result.EnsureVisible();

			this.dehighlightChildrens();
		}

		public bool hasGroupableTypes(IKernelNode node)
		{
			return (node is CSymbolicImageGraph ||
				node is CProjectiveBundleGraph);
		}

		private void showError()
		{
			MessageBox.Show("Unable to add node to group", "Group Error");
		}

		private bool CanAdd(ComputationNodeSingular node)
		{
			foreach (ComputationNodeSingular computationNode in nodes)
			{
				if (node.Parent != computationNode.Parent) return false;
				if (!hasGroupableTypes(node.Node)) return false;
			}

			return true;
		}

		public bool addNode(ComputationNode mnode)
		{
			if (!(mnode is ComputationNodeSingular)) return false;

			ComputationNodeSingular node = mnode as ComputationNodeSingular;

			if (!CanAdd(node))
			{
				showError();
				node.Checked = false;
				return false;
			}
			nodes.Add(node);
			return true;
		}

		public void removeNode(ComputationNode node)
		{
			nodes.Remove(node);
		}

		public void highlightChildrens()
		{
			foreach (ComputationNode computationNode in nodes)
			{
				computationNode.Checked = true;
			}
		}

		public void dehighlightChildrens()
		{
			object[] objs = nodes.ToArray();
			foreach (ComputationNode computationNode in objs)
			{
				computationNode.Checked = false;
			}
		}

		#region static functions

		private static ComputationNodePlural group = null;

		public static ComputationNodePlural getCurrentGroup()
		{
			if (group == null)
			{
				group = new ComputationNodePlural();
			}
			return group;
		}

		#endregion
	}
}