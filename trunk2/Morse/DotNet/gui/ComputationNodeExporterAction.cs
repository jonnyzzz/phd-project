using System;
using System.Windows.Forms;
using MorseKernelATL;

namespace gui
{
	/// <summary>
	/// Summary description for ComputationNodeExporterAction.
	/// </summary>
	public class ComputationNodeExporterAction : ComputationNodeAction
	{
		private IExportData node;
		public ComputationNodeExporterAction(IExportData node)
		{
			this.node = node;
			items = new ComputationNodeMenuItem[] {
				ComputationNodeMenuFactory.getMenuExportData(new ComputationNodeMenuFactory.ExportData(OnExportData))};
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

		ComputationNodeMenuItem[] items = new ComputationNodeMenuItem[]{};
	}
}
