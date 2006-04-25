using System.Collections;
using System.IO;
using System.Reflection;
using System.Xml;
using EugenePetrenko.Gui2.Kernell2.Container;

namespace Eugene.Petrenko.Gui2.MethodComparer
{
  /// <summary>
  /// Summary description for PredefinedRunMode.
  /// </summary>
  public class PredefinedRunMode : IRunMode
  {
    private XmlDocument[] items;

    public PredefinedRunMode(CommandLineParser cmd)
    {
      ArrayList itemsList = new ArrayList();

      Assembly ass = Assembly.GetExecutingAssembly();
      XmlDocument doc = new XmlDocument();

      using (Stream stream = ass.GetManifestResourceStream("Eugene.Petrenko.Gui2.MethodComparer.xml.Items.xml"))
        doc.Load(stream);

      XmlNodeList nodes = doc.SelectNodes("items/item");
      foreach (XmlNode node in nodes)
      {
        XmlDocument param = new XmlDocument();
        using (Stream stream = ass.GetManifestResourceStream(node.Attributes["xml"].Value))
          param.Load(stream);
        itemsList.Add(param);
      }

      items = (XmlDocument[]) itemsList.ToArray(typeof (XmlDocument));
    }

    public XmlDocument[] Items
    {
      get { return items; }
    }
  }
}