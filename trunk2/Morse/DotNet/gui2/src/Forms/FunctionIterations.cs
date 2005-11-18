using System;
using System.ComponentModel;
using System.Windows.Forms;

namespace EugenePetrenko.Gui2.Application.Forms
{
    /// <summary>
    /// Summary description for FunctionIterations.
    /// </summary>
    public class FunctionIterations : Form
    {
        private NumericUpDown iterations;
        private GroupBox groupBox;
        private Button buttonOK;
        private Button buttonCancel;

        /// <summary>
        /// Required designer variable.
        /// </summary>
        private Container components = null;

        public FunctionIterations(int oldValue)
        {
            InitializeComponent();

            this.iterations.Value = oldValue;
        }

        public int Iterations
        {
            get { return (int) this.iterations.Value; }
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

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.Resources.ResourceManager resources = new System.Resources.ResourceManager(typeof (FunctionIterations));
            this.iterations = new System.Windows.Forms.NumericUpDown();
            this.groupBox = new System.Windows.Forms.GroupBox();
            this.buttonOK = new System.Windows.Forms.Button();
            this.buttonCancel = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize) (this.iterations)).BeginInit();
            this.groupBox.SuspendLayout();
            this.SuspendLayout();
            // 
            // iterations
            // 
            this.iterations.Location = new System.Drawing.Point(16, 24);
            this.iterations.Maximum = new System.Decimal(new int[]
                {
                    1000,
                    0,
                    0,
                    0
                });
            this.iterations.Minimum = new System.Decimal(new int[]
                {
                    1,
                    0,
                    0,
                    0
                });
            this.iterations.Name = "iterations";
            this.iterations.Size = new System.Drawing.Size(88, 20);
            this.iterations.TabIndex = 0;
            this.iterations.ThousandsSeparator = true;
            this.iterations.Value = new System.Decimal(new int[]
                {
                    1,
                    0,
                    0,
                    0
                });
            // 
            // groupBox
            // 
            this.groupBox.Controls.Add(this.buttonCancel);
            this.groupBox.Controls.Add(this.buttonOK);
            this.groupBox.Controls.Add(this.iterations);
            this.groupBox.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox.Location = new System.Drawing.Point(5, 5);
            this.groupBox.Name = "groupBox";
            this.groupBox.Size = new System.Drawing.Size(342, 62);
            this.groupBox.TabIndex = 1;
            this.groupBox.TabStop = false;
            this.groupBox.Text = "Set power of function";
            // 
            // buttonOK
            // 
            this.buttonOK.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonOK.Location = new System.Drawing.Point(168, 24);
            this.buttonOK.Name = "buttonOK";
            this.buttonOK.Size = new System.Drawing.Size(75, 24);
            this.buttonOK.TabIndex = 1;
            this.buttonOK.Text = "Ok";
            this.buttonOK.Click += new System.EventHandler(this.buttonOK_Click);
            // 
            // buttonCancel
            // 
            this.buttonCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.buttonCancel.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonCancel.Location = new System.Drawing.Point(256, 24);
            this.buttonCancel.Name = "buttonCancel";
            this.buttonCancel.Size = new System.Drawing.Size(75, 24);
            this.buttonCancel.TabIndex = 2;
            this.buttonCancel.Text = "Cancel";
            // 
            // FunctionIterations
            // 
            this.AcceptButton = this.buttonOK;
            this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
            this.CancelButton = this.buttonCancel;
            this.ClientSize = new System.Drawing.Size(352, 72);
            this.Controls.Add(this.groupBox);
            this.DockPadding.All = 5;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Icon = ((System.Drawing.Icon) (resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "FunctionIterations";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "FunctionIterations";
            ((System.ComponentModel.ISupportInitialize) (this.iterations)).EndInit();
            this.groupBox.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private void buttonOK_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.OK;
        }
    }
}