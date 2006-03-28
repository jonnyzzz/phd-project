using System;
using System.Text;
using System.Xml;
using EugenePetrenko.Gui2.MorseKernel2;

namespace EugenePetrenko.Gui2.Kernell2
{
	/// <summary>
	/// Summary description for GraphInfoPresenter.
	/// </summary>
	public class GraphInfoPresenter
	{
        public string PresentToLogFile(IGraphResult res)
        {
            IGraphInfo info = res.GetGraphInfo();
            StringBuilder bld = new StringBuilder();

            bld.AppendFormat("Graph: Nodes {0}, Edges {1}", info.GetNodes(), info.GetEdges());

            return bld.ToString();
        }

        public string PresentToHistory(IGraphResult res)
        {
            IGraphInfo info = res.GetGraphInfo();
            return string.Format("Nodes {0}, Edges {1}", info.GetNodes(), info.GetEdges());
        }

		public void PresentToXml(IGraphResult res, XmlElement element)
		{
			IGraphInfo info = res.GetGraphInfo();
			XmlElement el = element.OwnerDocument.CreateElement("graphResult");
			WriteArrtibute(el, "Nodes", info.GetNodes());
			WriteArrtibute(el, "Edges", info.GetEdges());
			int dim = info.GetDimension();
			
			WriteArrtibute(el, "Edges", info.GetEdges());

			StringBuilder grid = new StringBuilder();
			StringBuilder left = new StringBuilder();
			StringBuilder right = new StringBuilder();
			for (int i=0; i<dim; i++)
			{
				grid.Append(info.GetGridNumber(i));
				grid.Append(',');
				left.Append(info.GetMinimum(i));
				left.Append(',');
				right.Append(info.GetMaximum(i));
				right.Append(',');
			}

			WriteArrtibute(el, "grid", grid.ToString());
			WriteArrtibute(el, "min", left.ToString());
			WriteArrtibute(el, "max", right.ToString());

			element.AppendChild(el);
		}

		private void WriteArrtibute(XmlElement element, string name, object value)
		{
			XmlAttribute attr = element.OwnerDocument.CreateAttribute(name);
			attr.Value = value.ToString();
			element.Attributes.Append(attr);
		}
	}
}
