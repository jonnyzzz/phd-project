using System.Collections;
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
		private IExportData[] data;
		private int dimension;

		public GnuplotViewAction(IExportData[] data, int dimension)
		{
			this.data = data;
			this.dimension = dimension;
		}

		public override ComputationNodeMenuItem[] getMenuItems()
		{
			return new ComputationNodeMenuItem[]
				{
					ComputationNodeMenuFactory.getUniversalMenuItem(
						new ComputationNodeMenuFactory.UniversalMenuItemClick(onClick),
						"Visualization")
				};
		}

		private void onClick()
		{
			GnuPlotView.Visualize(data, dimension);

		}

		#region IActionFactory

		[InitializeOnRun]
		public static void Register()
		{
			DynamicActionNodeTest.Instance.registerActionFactory(new RegistratorGnuplotViewAction());
		}

		private class RegistratorGnuplotViewAction : IActionFactory
		{
			public bool Corresponds(ComputationNode anode)
			{
				IKernelNode node = anode.Node;
				if (!(node is IExportData && node is IGraph)) return false;
				int dimension = ((IGraph) node).graphDimension();
				return dimension == 2 || dimension == 3;
			}

			public ComputationNodeAction CreateAction(ComputationNode anode)
			{
				IKernelNode kernelNode = anode.Node;
				if (kernelNode is IGroupNode)
				{
					IGroupNode groupNode = (IGroupNode) kernelNode;
					ArrayList items = new ArrayList();
					for (int i = 0; i < groupNode.nodeCount(); i++)
					{
						IKernelNode knode = groupNode.getNode(i);
						//We believe that any node of gourp implements IExportData interface!
						items.Add((IExportData) knode);
					}
					IExportData[] data = items.ToArray(typeof (IExportData)) as IExportData[];
					return new GnuplotViewAction(data, ((IGraph) kernelNode).graphDimension());
				}
				else
				{
					return new GnuplotViewAction(new IExportData[] {(IExportData) kernelNode}, ((IGraph) kernelNode).graphDimension());
				}
			}
		}
	}

	#endregion
}
