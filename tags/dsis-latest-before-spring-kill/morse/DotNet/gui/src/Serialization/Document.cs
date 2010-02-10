using System;
using System.IO;
using System.Xml;
using System.Xml.Serialization;
using gui.Logger;
using gui.Tree.Node;
using gui.Tree.Serialization;
using MorseKernelATL;

namespace gui.Serialization
{
	/// <summary>
	/// Summary description for Document.
	/// </summary>
	[Serializable]
	public class Document
	{
		public Document()
		{
		}

		[XmlElement("TreeRoot", typeof(TreeNodeSerializer))]
		private TreeNodeSerializer root = null;

		[XmlElement("Equation", typeof(string))]
		private string systemSource = null;


		public TreeNodeSerializer Root
		{
			get { return root; }
			set { root = value; }
		}

		public string SystemSource
		{
			get { return systemSource; }
			set { systemSource = value; }
		}

		public void BuildRootFromComputationNode(ComputationNode root, string filename, string path)
		{
			TreeNodeSerializator serializator = new TreeNodeSerializator(path, filename);
			Root = serializator.SerializeTree(root);
		}

        public ComputationNode BuildComputationNodeTree(string path)
        {
        	TreeNodeDeserializator deserializator = new TreeNodeDeserializator(path);
			return deserializator.DeSerialize(Root);
        }

		public CFunction CreateSystemFunction()
		{
			CFunction function = new CFunctionClass();
			function.FunctionWrongInput += new IFunctionEvents_FunctionWrongInputEventHandler(function_FunctionWrongInput);
			function.SystemSource = SystemSource;
			function.FunctionWrongInput -= new IFunctionEvents_FunctionWrongInputEventHandler(function_FunctionWrongInput);
			return function;
		}

		private void function_FunctionWrongInput(string description)
		{
			Log.LogException(this, new Exception("Failed to create SystemFunction"), "Load failed" );
		}

		private static XmlSerializer CreateSerializer()
		{
			return new XmlSerializer(typeof(Document), new Type[] { typeof(TreeNodeSerializer)});
		}

		public static Document LoadDocument(TextReader reader)
		{			
			XmlSerializer serializer = CreateSerializer();
			Document doc = serializer.Deserialize(reader) as Document;

			Log.Assert(typeof(Document), doc != null, "Document class has failed to load");

			return doc;
		}

		public static void SaveDocument(Document document, TextWriter writer)
		{
			XmlSerializer serializer = CreateSerializer();
			serializer.Serialize(writer, document);
		}

		
	}
}
