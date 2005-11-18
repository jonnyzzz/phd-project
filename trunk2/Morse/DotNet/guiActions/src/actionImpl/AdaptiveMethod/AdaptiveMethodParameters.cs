using System;
using System.Collections;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;
using EugenePetrenko.Gui2.Actions.Parameters;
using EugenePetrenko.Gui2.Controls.Control;
using EugenePetrenko.Gui2.Controls.Grid;
using EugenePetrenko.Gui2.Controls.Grid.Rows;
using EugenePetrenko.Gui2.Kernell2.Document;
using EugenePetrenko.Gui2.MorseKernel2;

namespace EugenePetrenko.Gui2.Actions.ActionImpl.AdaptiveMethod
{
    /// <summary>
    /// Summary description for AdaptiveMethodParameters.
    /// </summary>
    public class AdaptiveMethodParameters : ParametersControl
    {
        private ExGrid exGrid;
        private Panel panelUp;
        private Panel panelDown;
        private Panel panelDownRight;
        private Color prevUpdateButtonColor;
        private Container components = null;

        private IntPlusGridData factor;
        private DoublePrecsion precision;
        private IntPlusGridData upperLimit;
        private int dimension;
        private Function function;
        private CheckBox autoSetPrecision;
        private Button updatePrecision;
        private Panel panelDownDown;
        private TextBox textUpperLimit;
        private CheckBox checkUpperLimit;
        private Panel panelDownRightButton;
        private Panel panelDownTextBox;
        private double[] precisionValue;

        public AdaptiveMethodParameters(int dimension, Function function, double[] recomendedPrecision)
        {
            this.dimension = dimension;
            this.function = function;
            InitializeComponent();

            prevUpdateButtonColor = updatePrecision.BackColor;

            precisionValue = (double[]) new ArrayList(recomendedPrecision).ToArray(typeof (double));
            precision = new DoublePrecsion(recomendedPrecision, "Adaptive Precision");
            factor = new IntPlusGridData("Cell devisor", dimension);
            upperLimit = new IntPlusGridData("Upper Limit", 1);
            UpdateGrid();
            OnRefreshPrecision();
        }

        public void UpdateState(int dimension, Function function, double[] recomendedDimension)
        {
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
            this.panelUp = new System.Windows.Forms.Panel();
            this.panelDown = new System.Windows.Forms.Panel();
            this.panelDownRight = new System.Windows.Forms.Panel();
            this.autoSetPrecision = new System.Windows.Forms.CheckBox();
            this.updatePrecision = new System.Windows.Forms.Button();
            this.panelDownDown = new System.Windows.Forms.Panel();
            this.textUpperLimit = new System.Windows.Forms.TextBox();
            this.checkUpperLimit = new System.Windows.Forms.CheckBox();
            this.panelDownRightButton = new System.Windows.Forms.Panel();
            this.panelDownTextBox = new System.Windows.Forms.Panel();
            this.panelUp.SuspendLayout();
            this.panelDown.SuspendLayout();
            this.panelDownRight.SuspendLayout();
            this.panelDownDown.SuspendLayout();
            this.panelDownRightButton.SuspendLayout();
            this.panelDownTextBox.SuspendLayout();
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
            this.panelDown.Controls.Add(this.panelDownDown);
            this.panelDown.Controls.Add(this.panelDownRight);
            this.panelDown.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panelDown.DockPadding.Left = 25;
            this.panelDown.DockPadding.Right = 15;
            this.panelDown.Location = new System.Drawing.Point(0, 168);
            this.panelDown.Name = "panelDown";
            this.panelDown.Size = new System.Drawing.Size(400, 72);
            this.panelDown.TabIndex = 2;
            // 
            // panelDownRight
            // 
            this.panelDownRight.Controls.Add(this.autoSetPrecision);
            this.panelDownRight.Controls.Add(this.panelDownRightButton);
            this.panelDownRight.Dock = System.Windows.Forms.DockStyle.Top;
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
            this.autoSetPrecision.Location = new System.Drawing.Point(88, 5);
            this.autoSetPrecision.Name = "autoSetPrecision";
            this.autoSetPrecision.Size = new System.Drawing.Size(267, 22);
            this.autoSetPrecision.TabIndex = 0;
            this.autoSetPrecision.Text = "Auto Update Precision On Submit";
            this.autoSetPrecision.CheckedChanged += new System.EventHandler(this.autoSetPrecision_CheckedChanged);
            // 
            // updatePrecision
            // 
            this.updatePrecision.Dock = System.Windows.Forms.DockStyle.Fill;
            this.updatePrecision.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.updatePrecision.Location = new System.Drawing.Point(0, 0);
            this.updatePrecision.Name = "updatePrecision";
            this.updatePrecision.Size = new System.Drawing.Size(78, 22);
            this.updatePrecision.TabIndex = 1;
            this.updatePrecision.Text = "Update";
            this.updatePrecision.Click += new System.EventHandler(this.updatePrecision_Click);
            // 
            // panelDownDown
            // 
            this.panelDownDown.Controls.Add(this.panelDownTextBox);
            this.panelDownDown.Controls.Add(this.checkUpperLimit);
            this.panelDownDown.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelDownDown.Location = new System.Drawing.Point(25, 32);
            this.panelDownDown.Name = "panelDownDown";
            this.panelDownDown.Size = new System.Drawing.Size(360, 40);
            this.panelDownDown.TabIndex = 3;
            // 
            // textUpperLimit
            // 
            this.textUpperLimit.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.textUpperLimit.Dock = System.Windows.Forms.DockStyle.Fill;
            this.textUpperLimit.Enabled = false;
            this.textUpperLimit.Location = new System.Drawing.Point(10, 10);
            this.textUpperLimit.Name = "textUpperLimit";
            this.textUpperLimit.Size = new System.Drawing.Size(236, 20);
            this.textUpperLimit.TabIndex = 1;
            this.textUpperLimit.Text = "0";
            // 
            // checkUpperLimit
            // 
            this.checkUpperLimit.Dock = System.Windows.Forms.DockStyle.Left;
            this.checkUpperLimit.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.checkUpperLimit.Location = new System.Drawing.Point(0, 0);
            this.checkUpperLimit.Name = "checkUpperLimit";
            this.checkUpperLimit.Size = new System.Drawing.Size(104, 40);
            this.checkUpperLimit.TabIndex = 2;
            this.checkUpperLimit.Text = "Division Limit";
            this.checkUpperLimit.CheckedChanged += new System.EventHandler(this.checkUpperLimit_CheckedChanged);
            // 
            // panelDownRightButton
            // 
            this.panelDownRightButton.Controls.Add(this.updatePrecision);
            this.panelDownRightButton.Dock = System.Windows.Forms.DockStyle.Left;
            this.panelDownRightButton.DockPadding.Right = 10;
            this.panelDownRightButton.Location = new System.Drawing.Point(0, 5);
            this.panelDownRightButton.Name = "panelDownRightButton";
            this.panelDownRightButton.Size = new System.Drawing.Size(88, 22);
            this.panelDownRightButton.TabIndex = 2;
            // 
            // panelDownTextBox
            // 
            this.panelDownTextBox.Controls.Add(this.textUpperLimit);
            this.panelDownTextBox.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelDownTextBox.DockPadding.All = 10;
            this.panelDownTextBox.Location = new System.Drawing.Point(104, 0);
            this.panelDownTextBox.Name = "panelDownTextBox";
            this.panelDownTextBox.Size = new System.Drawing.Size(256, 40);
            this.panelDownTextBox.TabIndex = 3;
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
            this.panelDownDown.ResumeLayout(false);
            this.panelDownRightButton.ResumeLayout(false);
            this.panelDownTextBox.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private void UpdateGrid()
        {
            try
            {
                exGrid.SubmitData();
            }
            catch (ControlException)
            {
            } //ignore fill errors

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
            if (checkUpperLimit.Checked)
            {
                upperLimit[0] = textUpperLimit.Text;
                return new AdaptiveMethodParameretsImpl(factor.Data, precision.Data, upperLimit.Data[0], function);
            }
            else
            {
                return new AdaptiveMethodParameretsImpl(factor.Data, precision.Data, 0, function);
            }
        }

        private void autoSetPrecision_CheckedChanged(object sender, EventArgs e)
        {
            if (autoSetPrecision.Checked)
            {
                OnRefreshPrecision();
            }
        }

        private void updatePrecision_Click(object sender, EventArgs e)
        {
            updatePrecision.BackColor = prevUpdateButtonColor;
            OnRefreshPrecision();
        }

        private void OnRefreshPrecision()
        {
            try
            {
                exGrid.SubmitData();
                for (int i = 0; i < dimension; i++)
                {
                    precision.SetValue(i, precisionValue[i]/factor.Data[i]);
                }
                exGrid.ReLoadData();
            }
            catch (Exception)
            {
            }
        }

        private void checkUpperLimit_CheckedChanged(object sender, EventArgs e)
        {
            textUpperLimit.Enabled = checkUpperLimit.Checked;
        }

        public override string BoxCaption
        {
            get { return "Adaptive Method"; }
        }
    }
}