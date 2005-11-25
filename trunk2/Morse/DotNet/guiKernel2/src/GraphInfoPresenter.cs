using System;
using System.Text;
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
	}
}
