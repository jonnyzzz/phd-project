using System.ComponentModel;
using System.Windows.Forms;
using EugenePetrenko.Gui2.Actions.Parameters;
using EugenePetrenko.Gui2.Controls.Grid;
using EugenePetrenko.Gui2.Controls.Grid.Rows;
using EugenePetrenko.Gui2.Kernell2.Document;
using EugenePetrenko.Gui2.MorseKernel2;

namespace EugenePetrenko.Gui2.Actions.ActionImpl
{
    /// <summary>
    /// Summary description for BoxMethodParameters.
    /// </summary>
    public class BoxMethodParameters : ParametersControl
    {
        private readonly Function function;
        private ExGrid exGrid;
        private Container components = null;
        private GroupBox groupUp;
        private GroupBox groupDown;
        private Panel panelDown;
        private Panel panelUp;
        private CheckBox checkDerivate;

        private IntPlusGridData data;

        public BoxMethodParameters(int dimension, Function function)
        {
            this.function = function;
            InitializeComponent();

            data = new IntPlusGridData("Cell Devisor", dimension);
            exGrid.SetRows(dimension, new IExGridRow[] {data});
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
            this.groupUp = new System.Windows.Forms.GroupBox();
            this.groupDown = new System.Windows.Forms.GroupBox();
            this.panelDown = new System.Windows.Forms.Panel();
            this.panelUp = new System.Windows.Forms.Panel();
            this.checkDerivate = new System.Windows.Forms.CheckBox();
            this.groupUp.SuspendLayout();
            this.groupDown.SuspendLayout();
            this.panelDown.SuspendLayout();
            this.panelUp.SuspendLayout();
            this.SuspendLayout();
            // 
            // exGrid
            // 
            this.exGrid.Dock = System.Windows.Forms.DockStyle.Fill;
            this.exGrid.Location = new System.Drawing.Point(5, 5);
            this.exGrid.Name = "exGrid";
            this.exGrid.Size = new System.Drawing.Size(408, 379);
            this.exGrid.TabIndex = 0;
            // 
            // groupUp
            // 
            this.groupUp.Controls.Add(this.panelUp);
            this.groupUp.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupUp.Location = new System.Drawing.Point(0, 0);
            this.groupUp.Name = "groupUp";
            this.groupUp.Size = new System.Drawing.Size(424, 408);
            this.groupUp.TabIndex = 1;
            this.groupUp.TabStop = false;
            this.groupUp.Text = "Quantitive Params";
            // 
            // groupDown
            // 
            this.groupDown.Controls.Add(this.panelDown);
            this.groupDown.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.groupDown.Location = new System.Drawing.Point(0, 352);
            this.groupDown.Name = "groupDown";
            this.groupDown.Size = new System.Drawing.Size(424, 56);
            this.groupDown.TabIndex = 2;
            this.groupDown.TabStop = false;
            this.groupDown.Text = "Cell Image Options";
            // 
            // panelDown
            // 
            this.panelDown.Controls.Add(this.checkDerivate);
            this.panelDown.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelDown.DockPadding.Bottom = 5;
            this.panelDown.DockPadding.Left = 40;
            this.panelDown.DockPadding.Right = 5;
            this.panelDown.DockPadding.Top = 5;
            this.panelDown.Location = new System.Drawing.Point(3, 16);
            this.panelDown.Name = "panelDown";
            this.panelDown.Size = new System.Drawing.Size(418, 37);
            this.panelDown.TabIndex = 0;
            // 
            // panelUp
            // 
            this.panelUp.Controls.Add(this.exGrid);
            this.panelUp.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelUp.DockPadding.All = 5;
            this.panelUp.Location = new System.Drawing.Point(3, 16);
            this.panelUp.Name = "panelUp";
            this.panelUp.Size = new System.Drawing.Size(418, 389);
            this.panelUp.TabIndex = 1;
            // 
            // checkDerivate
            // 
            this.checkDerivate.Dock = System.Windows.Forms.DockStyle.Left;
            this.checkDerivate.Location = new System.Drawing.Point(40, 5);
            this.checkDerivate.Name = "checkDerivate";
            this.checkDerivate.Size = new System.Drawing.Size(163, 27);
            this.checkDerivate.TabIndex = 0;
            this.checkDerivate.Text = "Use Taylor Approximation";
            // 
            // BoxMethodParameters
            // 
            this.BackColor = System.Drawing.SystemColors.Control;
            this.Controls.Add(this.groupDown);
            this.Controls.Add(this.groupUp);
            this.Name = "BoxMethodParameters";
            this.Size = new System.Drawing.Size(424, 408);
            this.groupUp.ResumeLayout(false);
            this.groupDown.ResumeLayout(false);
            this.panelDown.ResumeLayout(false);
            this.panelUp.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        protected override IParameters SubmitDataInternal()
        {
            exGrid.SubmitData();

            return new BoxMethodParametersImpl(checkDerivate.Checked, function.IFunction, data.Data);
        }

        public override string BoxCaption
        {
            get { return "Box Method"; }
        }
    }
}