using System;
using System.Windows.Forms;
using guiActions.Parameters;
using guiExternalResource.Core;
using MorseKernel2;

namespace guiActions.src.actionImpl.SavePoints
{
	/// <summary>
	/// Summary description for SavaPointsParameters.
	/// </summary>
	public class SavePointsParameters : ParametersControl
	{
		private SaveFileDialog dialog = null;

		public SavePointsParameters() : base()
		{
			dialog = new SaveFileDialog();
			dialog.DefaultExt = "txt";
			dialog.Filter = "Points (*.txt)|*.txt|All Files (*.*)|*.*";
			dialog.Title = "Select file name to save points";
			dialog.CheckPathExists = true;
			dialog.OverwritePrompt = true;							
		}

		protected override IParameters SubmitDataInternal()
		{		
			string file;
			if (dialog.ShowDialog(null) != DialogResult.OK)
			{
				file = ResourceManager.Instance.TempFileAllocator.CreateFile();
			} else
			{
				file = dialog.FileName;
			}

			return new SavePointsParametersImpl(file);
		}

		public override string BoxCaption
		{
			get { return "Select file to save"; }
		}

		public override bool NeedShowForm
		{
			get { return false; }
		}		
	}
}
