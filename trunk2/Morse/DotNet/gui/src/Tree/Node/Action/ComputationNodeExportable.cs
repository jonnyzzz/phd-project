using System.Windows.Forms;
using gui.src.Visualization.GnuPlot;
using gui.Tree.Node;
using gui.Tree.Node.Action;
using gui.Tree.Node.Factory;
using gui.Tree.Node.Menu;
using MorseKernelATL;

namespace gui.Tree.Node.Action
{
	/// <summary>
	/// Summary description for ComputationNodeExporterAction.
	/// </summary>
	public class ComputationNodeExportable : ComputationNodeAction
	{
		private IExportData node;
		public ComputationNodeExportable(IExportData node)
		{
			this.node = node;
			items = new ComputationNodeMenuItem[] {
			    ComputationNodeMenuFactory.getMenuExportData(new ComputationNodeMenuFactory.ExportData(OnExportData)),
		        ComputationNodeMenuFactory.getUniversalMenuItem(new ComputationNodeMenuFactory.UniversalMenuItem(visualizeGnuPlot), "Visualize; GnuPlot" ),                                                 
            };
		}

		public override ComputationNodeMenuItem[] getMenuItems()
		{
			return items;
		}

		private void OnExportData()
		{
			SaveFileDialog sfd = new SaveFileDialog();
			sfd.OverwritePrompt = true;
			
			
			if (sfd.ShowDialog(null) == DialogResult.OK || !sfd.CheckPathExists)
			{
				node.ExportData(sfd.FileName);
				MessageBox.Show(null, "Data was exported to " + sfd.FileName, "Export");
			} 
		}

        private void visualizeGnuPlot()
        {
            string name = GnuPlotView.AllocateTemporaryFile();
            node.ExportData(name);
            GnuPlotView.ShowFromFile(name);
        }

	    ComputationNodeMenuItem[] items = new ComputationNodeMenuItem[]{};
	}
}
