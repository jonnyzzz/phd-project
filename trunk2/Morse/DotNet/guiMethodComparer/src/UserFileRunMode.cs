using System;
using System.Collections;
using System.Xml;
using EugenePetrenko.Gui2.Kernell2.Container;

namespace Eugene.Petrenko.Gui2.MethodComparer
{
	/// <summary>
	/// Summary description for UserFileRunMode.
	/// </summary>
	public class UserFileRunMode : IRunMode
	{
		private XmlDocument[] items;

		public UserFileRunMode(CommandLineParser cmd)
		{
			ArrayList itemsList = new ArrayList();
			foreach (string file in cmd.GetValues("file"))
			{
				XmlDocument doc = new XmlDocument();
				doc.Load(file);
				itemsList.Add(doc);
			}

			items = (XmlDocument[]) itemsList.ToArray(typeof(XmlDocument));
		}

		public XmlDocument[] Items
		{
			get { return items; }
		}
	}
}
