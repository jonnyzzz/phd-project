using System;
using System.IO;
using System.Xml;
using System.Xml.Serialization;
using gui.Logger;
using gui.Tree.Node;
using gui.Tree.Serialization;

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
			Root = root.toSerializableTree(filename, path);
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
