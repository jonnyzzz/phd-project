using System;
using System.Collections;
using System.Drawing;
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
        private System.Windows.Forms.Panel panelDownRight;
        private Color prevUpdateButtonColor;
		private System.ComponentModel.Container components = null;

        private IntPlusGridData factor;
        private DoublePrecsion precision;
        private int dimension;
        private Function function;
        private System.Windows.Forms.CheckBox autoSetPrecision;
        private System.Windows.Forms.Button updatePrecision;
        private double[] precisionValue;

	    public AdaptiveMethodParameters(int dimension, Function function, double[] recomendedPrecision)
		{
		    this.dimension = dimension;
		    this.function = function;
		    InitializeComponent();

            prevUpdateButtonColor = updatePrecision.BackColor;

            precisionValue = (double[]) new ArrayList( recomendedPrecision).ToArray(typeof(double));
            precision = new DoublePrecsion(recomendedPrecision, "Adaptive Precision");
            factor = new IntPlusGridData("Cell devisor", dimension);            
            UpdateGrid();
            OnRefreshPrecision();
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
            this.panelDownRight = new System.Windows.Forms.Panel();
            this.autoSetPrecision = new System.Windows.Forms.CheckBox();
            this.updatePrecision = new System.Windows.Forms.Button();
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
            this.panelDown.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panelDown.DockPadding.Left = 25;
            this.panelDown.DockPadding.Right = 15;
            this.panelDown.Location = new System.Drawing.Point(0, 208);
            this.panelDown.Name = "panelDown";
            this.panelDown.Size = new System.Drawing.Size(400, 32);
            this.panelDown.TabIndex = 2;
            // 
            // panelDownRight
            // 
            this.panelDownRight.Controls.Add(this.autoSetPrecision);
            this.panelDownRight.Controls.Add(this.updatePrecision);
            this.panelDownRight.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelDownRight.DockPadding.Bottom = 5;
            this.panelDownRight.DockPadding.Right = 5;
            this.panelDownRight.DockPadding.Top = 5;
            this.panelDownRight.Location = new System.Drawing.Point(25, 0);
            this.panelDownRight.Name = "panelDownRight";
            this.panelDownRight.Size = new System.Drawing.Size(360, 32);
            this.panelDownRight.TabIndex = 2;
            // 
            // autoSetPrecision
            // 
            this.autoSetPrecision.Checked = true;
            this.autoSetPrecision.CheckState = System.Windows.Forms.CheckState.Checked;
            this.autoSetPrecision.Dock = System.Windows.Forms.DockStyle.Fill;
            this.autoSetPrecision.Location = new System.Drawing.Point(75, 5);
            this.autoSetPrecision.Name = "autoSetPrecision";
            this.autoSetPrecision.Size = new System.Drawing.Size(280, 22);
            this.autoSetPrecision.TabIndex = 0;
            this.autoSetPrecision.Text = "Auto Update Precision On Submit";
            this.autoSetPrecision.CheckedChanged += new System.EventHandler(this.autoSetPrecision_CheckedChanged);
            // 
            // updatePrecision
            // 
            this.updatePrecision.Dock = System.Windows.Forms.DockStyle.Left;
            this.updatePrecision.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.updatePrecision.Location = new System.Drawing.Point(0, 5);
            this.updatePrecision.Name = "updatePrecision";
            this.updatePrecision.Size = new System.Drawing.Size(75, 22);
            this.updatePrecision.TabIndex = 1;
            this.updatePrecision.Text = "Update";
            this.updatePrecision.Click += new System.EventHandler(this.updatePrecision_Click);
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

            exGrid.SetRows(
                    dimension, 
                    new ExGridRowChangedHandler(new NeedSaveRowChange(OnFactorChanged), factor),
                    new ExGridRowChangedHandler(new NeedSaveRowChange(OnPrecisionChanged), precision)
                );            
        }

	    private bool OnPrecisionChanged()
	    {
	        /*if (autoSetPrecision.Checked)
	        {
	            DialogResult show = MessageBox.Show(this, "Do you want to override automatic precision value?", "Warning", MessageBoxButtons.YesNo );
                if (show == DialogResult.Yes)
                {
                    autoSetPrecision.Checked = false;
                    return true;
                } else
                {
                    return false;
                }
	        }*/
            return true;
	    }        

	    private bool OnFactorChanged()
	    {
            if (autoSetPrecision.Checked)
                updatePrecision.BackColor = Color.Maroon;
	        return true;
	    }

	    protected override IParameters SubmitDataInternal()
	    {
            if (autoSetPrecision.Checked) 
                OnRefreshPrecision();
            exGrid.SubmitData();                        
	        return new AdaptiveMethodParameretsImpl(factor.Data, precision.Data, function);
	    }

        private void autoSetPrecision_CheckedChanged(object sender, System.EventArgs e)
        {
            if (autoSetPrecision.Checked)
            {
                OnRefreshPrecision();
            }        
        }

        private void updatePrecision_Click(object sender, System.EventArgs e)
        {
            updatePrecision.BackColor = prevUpdateButtonColor;
            OnRefreshPrecision();
        }

	    private void OnRefreshPrecision()
	    {
	        try
	        {
	            exGrid.SubmitData();
	            for (int i=0; i<dimension; i++)
	            {
	                precision.SetValue(i, precisionValue[i]/factor.Data[i]);
	            }
	            exGrid.ReLoadData();                
	        } catch (Exception) {}
	    }

	    public override string BoxCaption
	    {
	        get { return "Adaptive Method"; }
	    }
	}
}
