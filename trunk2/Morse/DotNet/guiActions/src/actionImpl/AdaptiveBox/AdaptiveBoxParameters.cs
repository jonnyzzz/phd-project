using System.Drawing;
using System.Windows.Forms;
using EugenePetrenko.Gui2.Actions.Parameters;
using EugenePetrenko.Gui2.Controls.Grid;
using EugenePetrenko.Gui2.Controls.Grid.Rows;
using EugenePetrenko.Gui2.ExternalResource.Core;
using EugenePetrenko.Gui2.Kernell2.Document;
using EugenePetrenko.Gui2.MorseKernel2;

namespace EugenePetrenko.Gui2.Actions.ActionImpl.AdaptiveBox
{
    /// <summary>
    /// Summary description for AdaptiveBoxParameters.
    /// </summary>
    public class AdaptiveBoxParameters : ParametersControl
    {
        private readonly Function function;
        private ExGrid exGrid;

        private IntPlusGridData factor;
        private DoublePrecsion precision;

        public AdaptiveBoxParameters(Function function, int dimention, double[] recomendedPrecision)
        {
            this.function = function;
            factor = new IntPlusGridData(ResourceManager.Strings.CellDivision, dimention);
            precision = new DoublePrecsion(recomendedPrecision, ResourceManager.Strings.AdaptivePrecision);

            InitializeComponent();

            exGrid.SetRows(dimention, factor, precision);
        }

        private void InitializeComponent()
        {
            this.exGrid = new ExGrid();
            this.SuspendLayout();
            // 
            // exGrid
            // 
            this.exGrid.Dock = DockStyle.Fill;
            this.exGrid.Location = new Point(0, 0);
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