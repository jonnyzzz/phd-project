using System;
using System.Windows.Forms;
using gui.src.Tree.Node.ActionAllocator;
using gui.Tree.Node.Action;
using gui.Tree.Node.Menu;
using MorseKernelATL;

namespace gui.src.Tree.Node.Action
{
	/// <summary>
	/// Summary description for GnuplotViewAction.
	/// </summary>	
	public class GnuplotViewAction : ComputationNodeAction
	{
        private IExportData data;
        private int dimension;
		public GnuplotViewAction(IExportData data, int dimension)
		{
			this.data = data;
            this.dimension = dimension;
		}

	    public override ComputationNodeMenuItem[] getMenuItems()
	    {
	        return new ComputationNodeMenuItem[]{};	        
	    }

        
        static GnuplotViewAction()
        {            
            DynamicTest.Instance.registerActionFactory(new RegistratorGnuplotViewAction());
            Logger.Logger.Log("GnuplotActionRegistered!");            
        }

        private class RegistratorGnuplotViewAction : IActionFactory
        {           
            public bool Corresponds(MorseKernelATL.IKernelNode node)
            {
                return node is IExportData && node is IGraph;
            }

            public ComputationNodeAction CreateAction(MorseKernelATL.IKernelNode node)
            {
                // TODO:  Add RegistratorGnuplotViewAction.CreateAction implementation
                return null;
            }
        }

	}
}
