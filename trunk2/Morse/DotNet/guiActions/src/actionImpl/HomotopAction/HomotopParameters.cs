using System;
using guiActions.Parameters;
using MorseKernel2;

namespace guiActions.actionImpl.HomotopAction
{
	/// <summary>
	/// Summary description for HomotopParameters.
	/// </summary>
	public class HomotopParameters : ParametersControl
	{
		protected override IParameters SubmitDataInternal()
		{
			return new HomotopParametersImpl(null);
		}

		public override string BoxCaption
		{
			get { return "Isolating Set parameters"; }
		}

		private System.ComponentModel.Container components = null;

		public HomotopParameters()
		{
			InitializeComponent();

		}

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
			// 
			// HomotopParameters
			// 
			this.Name = "HomotopParameters";
			this.Size = new System.Drawing.Size(328, 312);

		}
		#endregion
	}
}
