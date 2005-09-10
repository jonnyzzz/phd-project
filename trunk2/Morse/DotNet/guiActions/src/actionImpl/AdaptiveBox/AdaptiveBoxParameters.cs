using System;
using guiActions.Parameters;
using guiControls.Grid.Rows;
using guiKernel2.Document;
using MorseKernel2;

namespace guiActions.actionImpl.AdaptiveBox
{
	/// <summary>
	/// Summary description for AdaptiveBoxParameters.
	/// </summary>
	public class AdaptiveBoxParameters : ParametersControl
	{
	    private readonly Function function;
	    private guiControls.Grid.ExGrid exGrid;

        private IntPlusGridData factor;
        private DoublePrecsion precision;
    
	    public AdaptiveBoxParameters(Function function, int dimention, double[] recomendedPrecision)
	    {
	        this.function = function;
	        factor = new IntPlusGridData("Divisor", dimention);
            precision = new DoublePrecsion(recomendedPrecision, "Precision");
            
            exGrid.SetRows(dimention, factor, precision);               
	    }

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
            this.exGrid.TabIndex = 0;
            // 
            // AdaptiveBoxParameters
            // 
            this.Controls.Add(this.exGrid);
            this.Name = "AdaptiveBoxParameters";
            this.ResumeLayout(false);

        }

	    protected override IParameters SubmitDataInternal()
	    {
	        exGrid.SubmitData();

            return new AdaptiveBoxParametersImpl(function, factor.Data, precision.Data);
	    }

	    public override string BoxCaption
	    {
	        get { return "Adaptive Box Parameters"; }
	    }
	}
}
