using System;
using System.Collections;
using gui.Tree.Node;
using gui.Tree.Serialization;
using MorseKernelATL;

namespace gui.Tree.Serialization
{
	/// <summary>
	/// Summary description for TreeNodeDeserializator.
	/// </summary>
	public class TreeNodeDeserializator
	{
		string path;
		public TreeNodeDeserializator(string path)
		{
			this.path = path;
		}

		private TreeNodeSerializer root;
		public ComputationNode DeSerialize(TreeNodeSerializer root)
		{
			this.root = root;
			buildTasksList();

			while (hasTasks()) DoNextTask();

			return CreateTree();
		}

		private ComputationNode CreateTree()
		{
			TaskNode rootTaskNode = TreeNodeSerializerToTaskNode[root] as TaskNode;
			ComputationNode rootNode = ComputationNode.createComputationNode(rootTaskNode.KernelNode);
			foreach (TreeNodeSerializer nodeSerializer in root.Childs)
			{
				CreateTree(rootNode, nodeSerializer);		
			}
			return rootNode;
		}

		private void CreateTree(ComputationNode parent, TreeNodeSerializer node)
		{
			TaskNode taskNode = TreeNodeSerializerToTaskNode[node] as TaskNode;
			ComputationNode computationNode = parent.newNode(taskNode.KernelNode);

			foreach (TreeNodeSerializer nodeSerializer in node.Childs)
			{
				CreateTree(computationNode, nodeSerializer);
			}
		}

		private class TaskNode
		{
			private bool inUse = false;

			public bool InUse
			{
				get { return inUse; }
				set { inUse = value; }
			}

			private IKernelNode kernelNode = null;
			private TreeNodeSerializer treeNodeSerializer;
			private TaskNode parentNode = null;

			public TaskNode ParentNode
			{
				get { return parentNode; }
				set { parentNode = value; }
			}

			public IKernelNode KernelNode
			{
				get { return kernelNode; }
				set { kernelNode = value; }
			}

			public bool IsCompete
			{
				get
				{
					return kernelNode != null;
				}
			}

			public TreeNodeSerializer TreeNodeSerializer
			{
				get { return treeNodeSerializer; }
			}

			public TaskNode(TreeNodeSerializer treeNodeSerializer)
			{
				this.treeNodeSerializer = treeNodeSerializer;
			}
		}

		private TaskNode[] tasksList;
		private Hashtable TreeNodeSerializerToTaskNode = new Hashtable();
		private void buildTasksList()
		{
			ArrayList list = new ArrayList();
			buildTasksList(root, list);
			tasksList = (TaskNode[])list.ToArray(typeof(TaskNode));
		}

		private void buildTasksList(TreeNodeSerializer root, ArrayList list)
		{
			TaskNode node = new TaskNode(root);
			list.Add(node);
			TreeNodeSerializerToTaskNode.Add(root, node);

			foreach (TreeNodeSerializer nodeSerializer in root.Childs)
			{
				buildTasksList(nodeSerializer, list);
			}
		}

		private bool hasTasks()
		{
			foreach (TaskNode taskNode in tasksList)
			{
				if (taskNode.InUse || !taskNode.IsCompete) return true;
			}
			return false;
		}

		private TaskNode getNextTask()
		{
			foreach (TaskNode taskNode in tasksList)
			{
				if (!taskNode.InUse && !taskNode.IsCompete) return taskNode;
			}
			return null;
		}
		
		private void DoNextTask()
		{
			if (hasTasks())
			{
				PerformTask(getNextTask());
			}
		}

		private IKernelNode FindByID(int id)
		{
			foreach (TaskNode taskNode in tasksList)
			{
				if (taskNode.IsCompete && taskNode.TreeNodeSerializer.ID == id)
				{
					return taskNode.KernelNode;
				}
			}
			return null;
		}

		private void PerformTask(TaskNode node)
		{
			if (node.InUse) return;

			ISerializer serializer = new CSerializerClass();

			node.KernelNode = serializer.LoadKernelNode(new SerializerInput(node.TreeNodeSerializer, this), Runner.Kernel);
		}

		private class SerializerInput : ISerializerInputData
		{
			private TreeNodeSerializer serializer;
			private TreeNodeDeserializator deserializator;

			public SerializerInput(TreeNodeSerializer serializer, TreeNodeDeserializator deserializator)
			{
				this.serializer = serializer;
				this.deserializator = deserializator;
			}

			public string FileName()
			{
				return deserializator.path + serializer.FileName;
			}

			public IKernelNode LoadByID(int id)
			{
				IKernelNode node;
				while ((node = deserializator.FindByID(id)) == null)
				{
					deserializator.DoNextTask();		
				}
				return node;
			}
		}
	}
}
