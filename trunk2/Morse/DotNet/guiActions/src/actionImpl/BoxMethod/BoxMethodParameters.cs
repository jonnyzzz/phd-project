using System;
using guiActions.Parameters;
using guiControls.Grid;
using guiControls.Grid.Rows;
using guiKernel2.Document;
using MorseKernel2;

namespace guiActions.ActionImpl
{
	/// <summary>
	/// Summary description for BoxMethodParameters.
	/// </summary>
	public class BoxMethodParameters : ParametersControl
	{
		private readonly Function function;
		private guiControls.Grid.ExGrid exGrid;
		private System.ComponentModel.Container components = null;

		private IntPlusGridData data;

		public BoxMethodParameters(int dimension, Function function)
		{
			this.function = function;
			InitializeComponent();
			
			data = new IntPlusGridData("Cell Devisor", dimension);
			exGrid.SetRows(dimension, new IExGridRow[]{data});
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
			this.exGrid = new guiControls.Grid.ExGrid();
			this.SuspendLayout();
			// 
			// exGrid1
			// 
			this.exGrid.Dock = System.Windows.Forms.DockStyle.Fill;
			this.exGrid.Location = new System.Drawing.Point(0, 0);
			this.exGrid.Name = "exGrid";
			this.exGrid.Size = new System.Drawing.Size(424, 408);
			this.exGrid.TabIndex = 0;
			// 
			// BoxMethodParameters
			// 
			this.BackColor = System.Drawing.SystemColors.Control;
			this.Controls.Add(this.exGrid);
			this.Name = "BoxMethodParameters";
			this.Size = new System.Drawing.Size(424, 408);
			this.ResumeLayout(false);

		}
		#endregion

		protected override IParameters SubmitDataInternal()
		{
			exGrid.SubmitData();

			return new BoxMethodParametersImpl(true, function.IFunction, data.Data );
		}

		public override string BoxCaption
		{
			get { return "Box Method"; }
		}
	}
}
