using System;
using System.Collections;
using System.Xml.Serialization;

namespace gui.Tree.Serialization
{
	/// <summary>
	/// Summary description for TreeNodeSerializer.
	/// </summary>
	[Serializable]
	public class TreeNodeSerializer
	{
		public TreeNodeSerializer()
		{
		}

		public static TreeNodeSerializer CreateSerializer(string filename, int id, params TreeNodeSerializer[] childs)
		{
			TreeNodeSerializer serializer = new TreeNodeSerializer();
			serializer.FileName = filename;
			serializer.ID = id;
			serializer.Childs = childs;
			return serializer;
		}

		private string fileName = "";
		private int id;
		private ArrayList childs = new ArrayList();		

		[XmlElement("FileName", typeof(string))]
		public string FileName
		{
			get { return fileName; }
			set { fileName = value; }
		}

		[XmlArray("Childs")]
		[XmlArrayItem("Child", typeof(TreeNodeSerializer))]
		public TreeNodeSerializer[] Childs
		{
			get { return (TreeNodeSerializer[])childs.ToArray(typeof(TreeNodeSerializer)); }
			set { childs.Clear(); childs.AddRange(value); }
		}		

		public void AddChild(TreeNodeSerializer node)
		{
			childs.Add(node);
		}

		[XmlElement("refnumber", typeof(int))]
		public int ID
		{
			get { return id; }
			set { id = value; }
		}
	}
}
