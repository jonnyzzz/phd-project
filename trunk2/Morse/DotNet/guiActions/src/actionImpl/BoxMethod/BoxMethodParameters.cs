using System;
using guiActions.Parameters;
using MorseKernel2;

namespace guiActions.ActionImpl
{
	/// <summary>
	/// Summary description for BoxMethodParameters.
	/// </summary>
	public class BoxMethodParameters : ParametersControl
	{
		private readonly int dimension;
		private readonly IFunction function;
		private System.ComponentModel.Container components = null;

		public BoxMethodParameters(int dimension, IFunction function)
		{
			this.dimension = dimension;
			this.function = function;
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
			// 
			// BoxMethodParameters
			// 
			this.BackColor = System.Drawing.SystemColors.Desktop;
			this.Name = "BoxMethodParameters";
			this.Size = new System.Drawing.Size(424, 408);

		}
		#endregion

		protected override IParameters SubmitDataInternal()
		{
			int[] factor = new int[dimension];
			for (int i=0; i<dimension; i++) factor[i] = 2;

			return new BoxMethodParametersImpl(false, function, factor );
		}

		public override string BoxCaption
		{
			get { return "Box Method"; }
		}
	}
}
