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

namespace guiActions.src.actionImpl.PointMethod
{
	/// <summary>
	/// Summary description for PointMethodParameters.
	/// </summary>
	public class PointMethodParameters : ParametersControl
	{
		private System.Windows.Forms.Panel panelUpper;
		private System.Windows.Forms.Panel panelLover;
		private System.Windows.Forms.CheckBox useOverlapping;
		private System.Windows.Forms.Panel panelLoverLeftGap;
		private guiControls.Grid.ExGrid exGrid;
		private System.ComponentModel.Container components = null;

		private IntPlusGridData factor;
		private IntPlusGridData ks;
		private DoublePercent offset1;
		private DoublePercent offset2;
		private int dimension;
		private readonly Function function;

		public PointMethodParameters(int dimension, Function function)
		{
			this.dimension = dimension;
			this.function = function;
			InitializeComponent();
			factor = new IntPlusGridData("Cell devisor", dimension);
			ks = new IntPlusGridData("Points in cell", dimension);
			offset1 = new DoublePercent("Left Offset", dimension);
			offset2 = new DoublePercent("Right Offset", dimension);

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
			this.panelUpper = new System.Windows.Forms.Panel();
			this.panelLover = new System.Windows.Forms.Panel();
			this.useOverlapping = new System.Windows.Forms.CheckBox();
			this.panelLoverLeftGap = new System.Windows.Forms.Panel();
			this.exGrid = new guiControls.Grid.ExGrid();
			this.panelUpper.SuspendLayout();
			this.panelLover.SuspendLayout();
			this.SuspendLayout();
			// 
			// panelUpper
			// 
			this.panelUpper.Controls.Add(this.exGrid);
			this.panelUpper.Dock = System.Windows.Forms.DockStyle.Fill;
			this.panelUpper.Location = new System.Drawing.Point(0, 0);
			this.panelUpper.Name = "panelUpper";
			this.panelUpper.Size = new System.Drawing.Size(384, 224);
			this.panelUpper.TabIndex = 0;
			// 
			// panelLover
			// 
			this.panelLover.Controls.Add(this.useOverlapping);
			this.panelLover.Controls.Add(this.panelLoverLeftGap);
			this.panelLover.Dock = System.Windows.Forms.DockStyle.Bottom;
			this.panelLover.Location = new System.Drawing.Point(0, 192);
			this.panelLover.Name = "panelLover";
			this.panelLover.Size = new System.Drawing.Size(384, 32);
			this.panelLover.TabIndex = 1;
			// 
			// useOverlapping
			// 
			this.useOverlapping.Dock = System.Windows.Forms.DockStyle.Fill;
			this.useOverlapping.Location = new System.Drawing.Point(32, 0);
			this.useOverlapping.Name = "useOverlapping";
			this.useOverlapping.Size = new System.Drawing.Size(352, 32);
			this.useOverlapping.TabIndex = 0;
			this.useOverlapping.Text = "Use Overlapping";
			this.useOverlapping.CheckStateChanged += new System.EventHandler(this.useOverlapping_CheckStateChanged);
			// 
			// panelLoverLeftGap
			// 
			this.panelLoverLeftGap.Dock = System.Windows.Forms.DockStyle.Left;
			this.panelLoverLeftGap.Location = new System.Drawing.Point(0, 0);
			this.panelLoverLeftGap.Name = "panelLoverLeftGap";
			this.panelLoverLeftGap.Size = new System.Drawing.Size(32, 32);
			this.panelLoverLeftGap.TabIndex = 1;
			// 
			// exGrid
			// 
			this.exGrid.Dock = System.Windows.Forms.DockStyle.Fill;
			this.exGrid.Location = new System.Drawing.Point(0, 0);
			this.exGrid.Name = "exGrid";
			this.exGrid.Size = new System.Drawing.Size(384, 224);
			this.exGrid.TabIndex = 0;
			// 
			// PointMethodParameters
			// 
			this.Controls.Add(this.panelLover);
			this.Controls.Add(this.panelUpper);
			this.Name = "PointMethodParameters";
			this.Size = new System.Drawing.Size(384, 224);
			this.panelUpper.ResumeLayout(false);
			this.panelLover.ResumeLayout(false);
			this.ResumeLayout(false);

		}
		#endregion

		private void UpdateGrid()
		{
			try
			{
				exGrid.SubmitData();
			}catch (ControlException) { } //ignore fill errors

			if (useOverlapping.Checked)
			{
				exGrid.SetRows(dimension, factor, ks, offset1, offset2 );
			} else
			{
				exGrid.SetRows(dimension, factor, ks);
			}			
		}

		private void useOverlapping_CheckStateChanged(object sender, System.EventArgs e)
		{
			UpdateGrid();
		}

		protected override IParameters SubmitDataInternal()
		{
			exGrid.SubmitData();
			return new PointMethodParametersImpl(function.IFunction, factor.Data, ks.Data,offset1.Data, offset2.Data, useOverlapping.Checked);
		}

		public override string BoxCaption
		{
			get { return "Point Method"; }
		}
	}
}
