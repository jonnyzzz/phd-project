using gui.Attributes;
using gui.src.Tree.Node.ActionAllocator;
using gui.Visualization.GnuPlot;
using gui.Tree.Node.Action;
using gui.Tree.Node.Factory;
using gui.Tree.Node.Menu;
using MorseKernelATL;

namespace gui.src.Tree.Node.Action
{
	/// <summary>
	/// Summary description for GnuplotViewAction.
	/// </summary>		
	[InitializeStaticAttrubute(InitializeStaticAttrubute.Type.TreeNodeAction, "Register")]
	public class GnuplotViewAction : ComputationNodeAction
	{
        private IExportData data;
        private IGraphInfo info;        
		public GnuplotViewAction(IExportData data, IGraphInfo info)
		{
			this.data = data;
            this.info = info;
		}

	    public override ComputationNodeMenuItem[] getMenuItems()
	    {
	        return new ComputationNodeMenuItem[] {
	            ComputationNodeMenuFactory.getUniversalMenuItem(
                                                     new ComputationNodeMenuFactory.UniversalMenuItem(onClick),
                                                     "Show using GnuPlot")};
        }

        private void onClick()
        {
            GnuPlotView.ShowFromFile(info,data);
            
        }
        
        #region IActionFactory
        public static void Register()
        {
            DynamicTest.Instance.registerActionFactory(new RegistratorGnuplotViewAction());         
        }              

        private class RegistratorGnuplotViewAction : IActionFactory
        {           
            public bool Corresponds(MorseKernelATL.IKernelNode node)
            {
                if (!( node is IExportData && node is IGraph)) return false;
                int dimension = ((IGraph)node).graphDimension();
                return dimension == 2 || dimension == 3;
            }

            public ComputationNodeAction CreateAction(MorseKernelATL.IKernelNode node)
            {                
                return new GnuplotViewAction((IExportData)node,((IGraph)node).graphInfo());
            }
        }
        #endregion
	}
}
