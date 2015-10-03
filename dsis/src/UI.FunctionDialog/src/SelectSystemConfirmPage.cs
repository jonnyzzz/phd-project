using System.Xml;
using DSIS.Core.System;
using DSIS.UI.Controls.Web;
using DSIS.UI.Wizard;
using DSIS.Utils;

namespace DSIS.UI.FunctionDialog
{
  public class SelectSystemConfirmPage : WizardPageBase<HtmlControl>, IWizardPageWithState
  {
    private readonly ISystemFunctionSelectionWizardInt myWizard;

    public SelectSystemConfirmPage(ISystemFunctionSelectionWizardInt wizard)
    {
      myWizard = wizard;
      ControlInternal = new HtmlControl();
      ControlInternal.SetHTML("<html><head><title>aaa</title><body><h1>TestControl</h1></body></html>");
    }

    public override void ControlShown()
    {
      var systemInfo = myWizard.CreateInfo();
      var systemSpace = myWizard.CreateSpace();

      ControlInternal.SetHTML("<html><head><title>aaa</title><body>" + PresentSystemInfo(systemInfo) + PresentSystemSpace(systemSpace) + "</body></html>");
    }

    private static string PresentSystemInfo(ISystemInfoBase info)
    {
      var doc = new XmlDocument();
      var root = doc.CreateRootElement("root");

      root.CreateChildElement("h1")
        .CreateText("System information");
      root.CreateChildElement("dl")
        .CreateChildElement("dt").CreateText("Name").ParentNode
        .CreateChildElement("dd").CreateText(info.PresentableName).ParentNode
        .CreateChildElement("dt").CreateText("Dim").ParentNode
        .CreateChildElement("dd").CreateText(info.Dimension.ToString());

      return root.InnerXml;
    }

    private static string PresentSystemSpace(ISystemSpace space)
    {
      var doc = new XmlDocument();
      var root = doc.CreateRootElement("root");

      root.CreateChildElement("h1").CreateText("System space");
      var node = root.CreateChildElement("dt");

      var text = "";
      for(int i=0; i<space.Dimension; i++)
      {
        text += string.Format("[{0}, {1}]x{2}", space.AreaLeftPoint[i], space.AreaRightPoint[i],
                              space.InitialSubdivision[i]);
        text += "<br />";
      }

      node.InnerXml = text;

      return root.InnerXml;
    }

    public IWizardPageWithState NextPage
    {
      get { return null; }
    }

    public bool IsLastPage
    {
      get { return true; }
    }
  }
}