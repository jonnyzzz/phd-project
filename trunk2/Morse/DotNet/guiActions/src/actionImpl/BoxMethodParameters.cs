using System;
using guiActions.parameters;
using MorseKernel2;

namespace guiActions.src.actionImpl
{
	/// <summary>
	/// Summary description for BoxMethodParameters.
	/// </summary>
	public class BoxMethodParameters : ParametersControl
	{
		private System.ComponentModel.Container components = null;

		public BoxMethodParameters()
		{
			InitializeComponent();

		}

		/// <summary> 
		/// Clean up any resources being used.
		/// </summary>
		protected override void Dispose( bool disposing )
		{
			if( disposing )
			{
				if(components != null)
				{
					components.Dispose();
				}
			}
			base.Dispose( disposing );
		}

		#region Component Designer generated code
		/// <summary> 
		/// Required method for Designer support - do not modify 
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent()
		{
			components = new System.ComponentModel.Container();
		}
		#endregion

		protected override IParameters SubmitDataInternal()
		{
			throw new NotImplementedException();
		}
	}
}
