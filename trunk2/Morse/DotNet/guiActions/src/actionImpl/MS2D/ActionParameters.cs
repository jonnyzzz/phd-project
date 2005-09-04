using System;
using System.Collections;
using System.ComponentModel;
using System.Drawing;
using guiActions.Parameters;
using guiControls.Grid;
using guiControls.Grid.Rows;
using MorseKernel2;

namespace guiActions.actionImpl.MS2D
{
	/// <summary>
	/// Summary description for ActionParameters.
	/// </summary>
	public abstract class ActionParameters : ParametersControl
	{
        private guiControls.Grid.ExGrid exGrid;
		/// <summary> 
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.Container components = null;

	    private IntPlusGridData data;

	    public ActionParameters()
		{
			// This call is required by the Windows.Forms Form Designer.
			InitializeComponent();

            data = new IntPlusGridData("Cell Devisor on Angle", 1);
            exGrid.SetRows(1, new IExGridRow[]{data});
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
            this.exGrid.Size = new System.Drawing.Size(336, 336);
            this.exGrid.TabIndex = 0;
            // 
            // ActionParameters
            // 
            this.Controls.Add(this.exGrid);
            this.Name = "ActionParameters";
            this.Size = new System.Drawing.Size(336, 336);
            this.ResumeLayout(false);

        }
		#endregion

	    public override string BoxCaption
	    {
	        get { return "Angle Method Projective Bundle Initial SI Creation"; }
	    }

        protected abstract IParameters LoadParameters(int factor);

	    protected override IParameters SubmitDataInternal()
	    {
            exGrid.SubmitData();
	        return LoadParameters(data.Data[0]);
	    }
	}
}
