using System.Windows.Forms;
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
			items = new ComputationNodeMenuItem[]
				{
					ComputationNodeMenuFactory.getMenuExportData(new ComputationNodeMenuFactory.UniversalMenuItemClick(OnExportData)),
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
			sfd.DefaultExt = "points";
			sfd.FileName = "points";
			sfd.Filter = "Point files|*.points|All files|*.*";
			sfd.Title = "Save Points of selected node";


			if (sfd.ShowDialog(null) == DialogResult.OK)
			{
				node.ExportData(sfd.FileName);
				MessageBox.Show(null, "Data was exported to " + sfd.FileName, "Export");
			}
		}

		private ComputationNodeMenuItem[] items = new ComputationNodeMenuItem[] {};
	}
}