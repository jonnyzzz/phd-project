using System;
using guiActions.Parameters;
using guiVisualization.KernelAction;
using MorseKernel2;
using guiVisualization.KernelAction.GnuPlot;
using System.Windows.Forms;
using guiKernel2.Document;
using guiKernel2.Container;

namespace guiVisualization.src.actionImpl.GnuPlot
{
	/// <summary>
	/// Summary description for GnuPlotParameters.
	/// </summary>
	public class GnuPlotParameters : ParametersControl, IGnuPlotVisualizationKernelParameters, GnuPlotScriptGenParameters
	{
		private string fileNameToSave = null;

		protected override IParameters SubmitDataInternal()
		{
			SaveFileDialog dialog = new SaveFileDialog();			
			dialog.DefaultExt = "png";
			dialog.Filter = "Png image|*.png|All files|*.*";
			dialog.Title = "Select file to save picture or press cancel to show it";

			if (dialog.ShowDialog(this) == DialogResult.OK) 
			{
				fileNameToSave = dialog.FileName;
			} 
			else 
			{
				fileNameToSave = null;
			}

			return this;
		}

		public override string BoxCaption
		{
			get { return "Visualization settings"; }
		}

		public override bool NeedShowForm
		{
			get { return false; } 
		}

		public GnuPlotScriptGenParameters Parameters
		{
			get { return FileName == null ? null : this  ;}
		}
		
		public string FileName { get {return this.fileNameToSave;} }

		int GnuPlotScriptGenParameters.Width { get{return 1000;} }
		int GnuPlotScriptGenParameters.Height{ get{return 1000;} }	  

		public string Title 
		{
			get 
			{
				if (Core.Instance.KernelDocument.Title != null) 
				{
					return Core.Instance.KernelDocument.Title;
				} else return "";
			}
		}
	}
}
