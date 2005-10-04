using System;
using System.Collections;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Windows.Forms;
using guiActions.Parameters;
using guiControls.Control;
using guiControls.Grid.Rows;
using guiKernel2.Document;
using MorseKernel2;


namespace guiActions.actionImpl.Projector
{
	/// <summary>
	/// Summary description for ProjectorParameters.
	/// </summary>
	public class ProjectorParameters : ParametersControl
	{
		private guiControls.Grid.ExGrid exGrid;
		/// <summary> 
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.Container components = null;

		private IntPlusGridData factor;

		public ProjectorParameters(int dimention)
		{
			// This call is required by the Windows.Forms Form Designer.
			InitializeComponent();

			factor = new IntPlusGridData("Devisor", dimention);			
			exGrid.SetRows(dimention, factor);
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
			// exGrid
			// 
			this.exGrid.Dock = System.Windows.Forms.DockStyle.Fill;
			this.exGrid.Location = new System.Drawing.Point(0, 0);
			this.exGrid.Name = "exGrid";
			this.exGrid.Size = new System.Drawing.Size(432, 312);
			this.exGrid.TabIndex = 0;
			// 
			// ProjectorParameters
			// 
			this.Controls.Add(this.exGrid);
			this.Name = "ProjectorParameters";
			this.Size = new System.Drawing.Size(432, 312);
			this.ResumeLayout(false);

		}
		#endregion


		protected override IParameters SubmitDataInternal()
		{
			exGrid.SubmitData();
			return new ProjectorParametersImpl( factor.Data);
		}

		public override string BoxCaption
		{
			get { return "Graph Devisor"; }
		}
	}
}
