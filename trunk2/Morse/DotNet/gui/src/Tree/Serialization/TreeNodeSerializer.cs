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

		private string fileName = "";
		private bool fromDLL = true;
		private ArrayList childs = new ArrayList();		

		[XmlElement("FileName", typeof(string))]
		public string FileName
		{
			get { return fileName; }
			set { fileName = value; }
		}

		[XmlElement("FromDLL", typeof(bool))]
		public bool FromDll
		{
			get { return fromDLL; }
			set { fromDLL = value; }
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
	}
}
