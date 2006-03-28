using System.Collections;
using System.Xml;
using EugenePetrenko.Gui2.ExternalResource.Core;

namespace EugenePetrenko.Gui2.Application.SystemFunctions
{
	/// <summary>
	/// Summary description for PredefinedFunctions.
	/// </summary>
	public class PredefinedFunctions
	{
		private const string XML = "predefined.xml";
		private ResourceManager manager;
		private string[] names;

		public PredefinedFunctions()
		{
			manager = Runner.Runner.Instance.ResourceManager;
			XmlNode document = manager.GetXmlResource(XML);

			ArrayList list = new ArrayList();
			foreach (XmlNode node in document.SelectNodes("predefined/system/@name"))
			{
				list.Add(node.Value.ToString());
			}
			names = (string[]) list.ToArray(typeof(string));
		}


		public XmlNode GetFunction(string name)
		{
			XmlNode document = manager.GetXmlResource(XML);
			return document.SelectSingleNode("predefined/system[@name=\"" + name + "\"]");			
		}

		public string[] PredefinedSystems
		{
			get { return names;}
		}
	}
}
