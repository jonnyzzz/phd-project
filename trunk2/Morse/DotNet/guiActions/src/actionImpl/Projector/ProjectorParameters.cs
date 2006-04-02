using System.ComponentModel;
using EugenePetrenko.Gui2.Actions.Parameters;
using EugenePetrenko.Gui2.Controls.Grid;
using EugenePetrenko.Gui2.Controls.Grid.Rows;
using EugenePetrenko.Gui2.ExternalResource.Core;
using EugenePetrenko.Gui2.MorseKernel2;

namespace EugenePetrenko.Gui2.Actions.ActionImpl.Projector
{
    /// <summary>
    /// Summary description for ProjectorParameters.
    /// </summary>
    public class ProjectorParameters : ParametersControl
    {
        private ExGrid exGrid;

        /// <summary> 
        /// Required designer variable.
        /// </summary>
        private Container components = null;

        private IntPlusGridData factor;

        public ProjectorParameters(int dimention)
        {
            // This call is required by the Windows.Forms Form Designer.
            InitializeComponent();

            factor = new IntPlusGridData(ResourceManager.Strings.CellDivision, dimention);
            exGrid.SetRows(dimention, factor);
        }

        /// <summary> 
        /// Clean up any resources being used.
        /// </summary>
        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                if (components != null)
                {
                    components.Dispose();
                }
            }
            base.Dispose(disposing);
        }

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.exGrid = new Controls.Grid.ExGrid();
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
            return new ProjectorParametersImpl(factor.Data);
        }

        public override string BoxCaption
        {
            get { return "Graph Devisor"; }
        }
    }
}