using gui.Attributes;
using gui.Tree.Node.ActionAllocator;
using gui.Tree.Node.Factory;
using gui.Tree.Node.Menu;
using gui.Visualization.GnuPlot;
using MorseKernelATL;

namespace gui.Tree.Node.Action
{
	/// <summary>
	/// Summary description for GnuplotViewAction.
	/// </summary>		
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
			return new ComputationNodeMenuItem[]
				{
					ComputationNodeMenuFactory.getUniversalMenuItem(
						new ComputationNodeMenuFactory.UniversalMenuItemClick(onClick),
						"Show using GnuPlot")
				};
		}

		private void onClick()
		{
			GnuPlotView.ShowFromFile(info, data);

		}

		#region IActionFactory

		[InitializeOnRun]
		public static void Register()
		{
			DynamicActionNodeTest.Instance.registerActionFactory(new RegistratorGnuplotViewAction());
		}

		private class RegistratorGnuplotViewAction : IActionFactory
		{
			public bool Corresponds(IKernelNode node)
			{
				if (!(node is IExportData && node is IGraph)) return false;
				int dimension = ((IGraph) node).graphDimension();
				return dimension == 2 || dimension == 3;
			}

			public ComputationNodeAction CreateAction(IKernelNode node)
			{
				return new GnuplotViewAction((IExportData) node, ((IGraph) node).graphInfo());
			}
		}

		#endregion
	}
}