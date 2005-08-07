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

namespace guiActions.src.actionImpl.AdaptiveMethod
{
	/// <summary>
	/// Summary description for AdaptiveMethodParameters.
	/// </summary>
	public class AdaptiveMethodParameters : ParametersControl
	{	    
	    private guiControls.Grid.ExGrid exGrid;
        private System.Windows.Forms.Panel panelUp;
        private System.Windows.Forms.Panel panelDown;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Panel panelDownRight;
		private System.ComponentModel.Container components = null;

        private IntPlusGridData factor;
        private int dimension;
        private Function function;
        private System.Windows.Forms.TextBox textPrecison;
        private double recomendedPrecision;

		public AdaptiveMethodParameters(int dimension, Function function, double recomendedPrecision)
		{
		    this.recomendedPrecision = recomendedPrecision;
		    this.dimension = dimension;
		    this.function = function;
		    InitializeComponent();

            textPrecison.Text = recomendedPrecision.ToString();

            factor = new IntPlusGridData("Cell devisor", dimension);
            UpdateGrid();
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
            this.panelUp = new System.Windows.Forms.Panel();
            this.panelDown = new System.Windows.Forms.Panel();
            this.label1 = new System.Windows.Forms.Label();
            this.textPrecison = new System.Windows.Forms.TextBox();
            this.panelDownRight = new System.Windows.Forms.Panel();
            this.panelUp.SuspendLayout();
            this.panelDown.SuspendLayout();
            this.panelDownRight.SuspendLayout();
            this.SuspendLayout();
            // 
            // exGrid
            // 
            this.exGrid.Dock = System.Windows.Forms.DockStyle.Fill;
            this.exGrid.DockPadding.All = 1;
            this.exGrid.Location = new System.Drawing.Point(0, 0);
            this.exGrid.Name = "exGrid";
            this.exGrid.Size = new System.Drawing.Size(400, 240);
            this.exGrid.TabIndex = 0;
            // 
            // panelUp
            // 
            this.panelUp.Controls.Add(this.exGrid);
            this.panelUp.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelUp.Location = new System.Drawing.Point(0, 0);
            this.panelUp.Name = "panelUp";
            this.panelUp.Size = new System.Drawing.Size(400, 240);
            this.panelUp.TabIndex = 1;
            // 
            // panelDown
            // 
            this.panelDown.Controls.Add(this.panelDownRight);
            this.panelDown.Controls.Add(this.label1);
            this.panelDown.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panelDown.Location = new System.Drawing.Point(0, 208);
            this.panelDown.Name = "panelDown";
            this.panelDown.Size = new System.Drawing.Size(400, 32);
            this.panelDown.TabIndex = 2;
            // 
            // label1
            // 
            this.label1.Dock = System.Windows.Forms.DockStyle.Left;
            this.label1.Location = new System.Drawing.Point(0, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(176, 32);
            this.label1.TabIndex = 0;
            this.label1.Text = "Precision:";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // textPrecison
            // 
            this.textPrecison.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.textPrecison.Dock = System.Windows.Forms.DockStyle.Fill;
            this.textPrecison.Location = new System.Drawing.Point(0, 5);
            this.textPrecison.Name = "textPrecison";
            this.textPrecison.Size = new System.Drawing.Size(219, 20);
            this.textPrecison.TabIndex = 1;
            this.textPrecison.Text = "0.1";
            // 
            // panelDownRight
            // 
            this.panelDownRight.Controls.Add(this.textPrecison);
            this.panelDownRight.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelDownRight.DockPadding.Bottom = 5;
            this.panelDownRight.DockPadding.Right = 5;
            this.panelDownRight.DockPadding.Top = 5;
            this.panelDownRight.Location = new System.Drawing.Point(176, 0);
            this.panelDownRight.Name = "panelDownRight";
            this.panelDownRight.Size = new System.Drawing.Size(224, 32);
            this.panelDownRight.TabIndex = 2;
            // 
            // AdaptiveMethodParameters
            // 
            this.Controls.Add(this.panelDown);
            this.Controls.Add(this.panelUp);
            this.Name = "AdaptiveMethodParameters";
            this.Size = new System.Drawing.Size(400, 240);
            this.panelUp.ResumeLayout(false);
            this.panelDown.ResumeLayout(false);
            this.panelDownRight.ResumeLayout(false);
            this.ResumeLayout(false);

        }
		#endregion

        private void UpdateGrid()
        {
            try
            {
                exGrid.SubmitData();
            }
            catch (ControlException) { } //ignore fill errors

            exGrid.SetRows(dimension, factor);
        }

	    protected override IParameters SubmitDataInternal()
	    {
            exGrid.SubmitData();
            DoublePrecsion pr = new DoublePrecsion(new double[]{0}, "Precision" );
            pr[0] = this.textPrecison.Text;
            recomendedPrecision = pr.Data[0];

	        return new AdaptiveMethodParameretsImpl(factor.Data, recomendedPrecision, function);
	    }

	    public override string BoxCaption
	    {
	        get { return "Adaptive Method"; }
	    }
	}
}
