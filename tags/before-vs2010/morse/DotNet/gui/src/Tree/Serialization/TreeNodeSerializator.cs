using System;
using System.Collections;
using System.IO;
using gui.Logger;
using gui.Resource;
using gui.Tree.Node;
using MorseKernelATL;

namespace gui.Tree.Serialization
{
	/// <summary>
	/// Summary description for TreeNodeSerializator.
	/// </summary>
	public class TreeNodeSerializator
	{
		private string path;
		private string filename;
		private int id = 0;
		private Hashtable KernelNodeToID = new Hashtable();
		
		public TreeNodeSerializator(string path, string filename)
		{
			this.path = path;
			this.filename = filename;
		}


		protected int FindID(IKernelNode node) 
		{
			object o = KernelNodeToID[node];
			if (o == null)
			{				
				o = KernelNodeToID[node] = (++id).ToString();
			}
			return int.Parse(o.ToString());
		}

		public TreeNodeSerializer SerializeTree(ComputationNode root)
		{
			return RecursiveSearch(root);
		}

		private TreeNodeSerializer RecursiveSearch(ComputationNode root)
		{
			TreeNodeSerializer serializer = VisitNode(root);

			foreach (ComputationNode computationNode in root.Nodes)
			{
				serializer.AddChild(RecursiveSearch(computationNode));
			}
			return serializer;
		}

		private TreeNodeSerializer VisitNode(ComputationNode node)
		{			
			IKernelNode kernelNode = node.Node;
			if (kernelNode != null)
			{
				TreeNodeSerializer serializedNode = TreeNodeSerializer.CreateSerializer(GenerateFileName(), FindID(kernelNode));
				ISerializer serializer = new CSerializerClass();
				serializer.SaveKernelNode(new SerializerOutput(serializedNode, this), kernelNode);

				return serializedNode;
			} Log.Assert(this, false, "Serialization not supported");
			
			return new TreeNodeSerializer();
		}

		public ComputationTree ComputationTree(TreeNodeSerializer root, string filename)
		{
			return null;
		}

		protected string GenerateFileName()
		{
			string file = string.Format(Resource.Resources.Instance.FileCreateTemplate, filename, id);
			while (File.Exists(path + file)) file += ".1";
			return file;
		}


		private class SerializerOutput : ISerializerOutputData
		{
			private TreeNodeSerializer serializer;
			private TreeNodeSerializator serializator;

			public SerializerOutput(TreeNodeSerializer serializer, TreeNodeSerializator serializator)
			{
				this.serializer = serializer;
				this.serializator = serializator;
			}

			public string FileName()
			{
				return serializator.path +  serializer.FileName;
			}

			public int SaveWithID(IKernelNode node)
			{
				return serializator.FindID(node);
			}
		}
	
	}
}
