using System;
using System.Collections;
using System.IO;
using System.Windows.Forms;
using gui.Logger;
using gui.Resource;
using gui.Tree.Node.Action;
using gui.Tree.Node.Factory;
using gui.Tree.Node.Menu;
using gui.Tree.Serialization;
using MorseKernelATL;

namespace gui.Tree.Node
{
	/// <summary>
	/// Summary description for ComputationNode.
	/// </summary>
	/// 
	public abstract class ComputationNode : TreeNode
	{
		protected abstract ComputationNodeMenuItem[] getMenuItems();

		private ComputationNodePlural currentGroup = null;

		public virtual ComputationNodePlural CurrentGroup
		{
			get { return currentGroup; }
			set { currentGroup = value; }
		}

		#region Class Members...

		public ComputationNode() : base()
		{
			this.Checked = false;
			this.node = null;
		}

		public ComputationNode(IKernelNode node) : this()
		{
			table.Add(node, this);
			this.node = node;
		}

		private IKernelNode node;

		public IKernelNode Node
		{
			get { return node; }
		}

		public void newNode(IKernelNode node)
		{
			Nodes.Add(ComputationNode.createComputationNode(node));
			Expand();
		}

		public TreeNodeSerializer toSerializableTree(string filename, string path)
		{
			return toSerializableTree(filename, path, 0, 0);
		}

		protected string GenerateFileName(string filename, string path, int child, int level)
		{
			string file = string.Format(Resources.Instance.FileCreateTemplate, filename, level, child);
			while (File.Exists(path + file)) file += ".1";
			return file;
		}

		

		protected virtual TreeNodeSerializer toSerializableTree(string filename, string path, int child, int level)
		{
			string file = GenerateFileName(filename,  path, child, level);
			if (this.Node != null) 
			{
				KernelNodeSerializer.SerializeKernelNode(path + file, this.Node);
			} else Log.Assert(this, false, "");

			TreeNodeSerializer serializer = new TreeNodeSerializer();
			serializer.FileName = file;
			serializer.FromDll = true;
			
			foreach (ComputationNode node in Nodes)
			{
				serializer.AddChild(node.toSerializableTree(filename, path, child++, level+1));
			}
			return serializer;
		}

		#region Menu

		public ComputationNodeMenuItem[] MenuItems
		{
			get
			{
				ComputationNodeMenuItem[] items = getMenuItems();
				if (IsSelected)
				{
					items = merge(items,
					              new ComputationNodeMenuItem[]
					              	{
					              		//ComputationNodeMenuFactory.DelimeterItem(),
					              		ComputationNodeMenuFactory.DeselectItem(this.TreeView)
					              	});
				}

				if (CurrentGroup != null)
				{
					items = merge(items, new ComputationNodeMenuItem[]
						{
							ComputationNodeMenuFactory.DelimeterItem()
						});
					items = merge(items,
					              addPrefix(currentGroup.getMenuItems(), "Group: "));
				}

				if (items.Length == 0)
				{
					items = new ComputationNodeMenuItem[]
						{
							ComputationNodeMenuFactory.Empty()
						};
				}
				return items;
			}
		}

		protected ComputationNodeMenuItem[] merge(ComputationNodeMenuItem[] a, ComputationNodeMenuItem[] b)
		{
			ComputationNodeMenuItem[] c = new ComputationNodeMenuItem[a.Length + b.Length];
			int cn = 0;
			for (int i = 0; i < a.Length; c[cn++] = a[i++]) ;
			cn = a.Length;
			for (int i = 0; i < b.Length; c[cn++] = b[i++]) ;
			return c;
		}

		protected ComputationNodeMenuItem[] addPrefix(ComputationNodeMenuItem[] a, string prefix)
		{
			ComputationNodeMenuItem[] ret = new ComputationNodeMenuItem[a.Length];
			for (int i = 0; i < a.Length; i++)
			{
				if (a[i].Text == "-")
				{
					ret[i] = ComputationNodeMenuFactory.getMenuRenameAdapter(a[i], a[i].Text);
				}
				else
				{
					ret[i] = ComputationNodeMenuFactory.getMenuRenameAdapter(a[i], prefix + a[i].Text);
				}
			}
			return ret;
		}


		protected ComputationNodeMenuItem[] fromActions(IEnumerable actions)
		{
			ArrayList nodes = new ArrayList();
			ComputationNodeMenuItem[] items;
			foreach (ComputationNodeAction action in actions)
			{
				items = action.getMenuItems();
				if (items.Length > 0)
				{
					nodes.AddRange(items);
					nodes.Add(ComputationNodeMenuFactory.DelimeterItem());
				}

			}

			ComputationNodeMenuItem[] itms = new ComputationNodeMenuItem[nodes.Count];
			for (int i = 0; i < nodes.Count; itms[i] = (ComputationNodeMenuItem) nodes[i++]) ;
			return itms;
		}
		#endregion
		#endregion

		#region Static Features

		public static ComputationNode createComputationNode(IKernelNode node)
		{
			ComputationNode cnode = new ComputationNodeSingular(node);
			return cnode;
		}

		public static ComputationNode createComputationNodeForGroup(IKernelNode node, ComputationNode addin)
		{
			return new ComputationNodeSingular(node);
		}

		public static void OnAfterCheckClick(ComputationNode node)
		{
			node.OnAfterCheck();
		}

		private void OnAfterCheck()
		{
			Console.Out.WriteLine("Node: {0}\n", this.Checked);
			if (this.Checked)
			{
				if (this.currentGroup == null)
				{
					this.CurrentGroup = ComputationNodePlural.getCurrentGroup();
				}
				this.CurrentGroup.addNode(this);
			}
			else
			{
				if (this.CurrentGroup != null)
				{
					this.CurrentGroup.removeNode(this);
				}
			}

			if (this.CurrentGroup.Length == 0)
			{
				this.CurrentGroup = null;
			}
		}

		#endregion

		private static Hashtable table = new Hashtable();

		public static ComputationNode fromIKernelNode(IKernelNode node)
		{
			return table[node] as ComputationNode;
		}

		public static void ClearGroup()
		{
			ComputationNodePlural.getCurrentGroup().dehighlightChildrens();
		}

		public static ComputationNode FromTreeNodeSerializer(TreeNodeSerializer serializer, string path)
		{
			if (serializer.FromDll)
			{
				IKernelNode node = KernelNodeSerializer.DeSerializeKernelNode(path + serializer.FileName);
				return ComputationNode.createComputationNode(node);				
			}
			return null;
		}
	}
}