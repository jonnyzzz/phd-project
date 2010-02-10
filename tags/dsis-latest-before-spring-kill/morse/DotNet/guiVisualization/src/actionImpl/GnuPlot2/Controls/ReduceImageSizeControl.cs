using System;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;

namespace EugenePetrenko.Gui2.Visualization.ActionImpl.GnuPlot2.Controls
{
    /// <summary>
    /// Summary description for ReduceImageSizeControl.
    /// </summary>
    public class ReduceImageSizeControl : UserControl
    {
        private GroupBox groupBoxImageSize;
        private Panel panelReduceBeforeShow;
        private CheckBox checkBoxReduceSize;
        private Panel panelImageSizeY;
        private TextBox textBoxImageSizeY;
        private Label labelImageSizeY;
        private Panel panelImageSizeX;
        private TextBox textBoxImageSizeX;
        private Label labelImageSizeX;

        private bool allowImageSizeWithoutReduse;

        /// <summary> 
        /// Required designer variable.
        /// </summary>
        private Container components = null;

        public ReduceImageSizeControl()
        {
            InitializeComponent();
        }

        public bool AllowImageSizeWithoutReduse
        {
            get { return allowImageSizeWithoutReduse; }
            set { allowImageSizeWithoutReduse = value; }
        }

        public bool Reduse
        {
            get { return checkBoxReduceSize.Checked; }
            set { checkBoxReduceSize.Checked = value; }
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
            this.groupBoxImageSize = new System.Windows.Forms.GroupBox();
            this.panelReduceBeforeShow = new System.Windows.Forms.Panel();
            this.checkBoxReduceSize = new System.Windows.Forms.CheckBox();
            this.panelImageSizeY = new System.Windows.Forms.Panel();
            this.textBoxImageSizeY = new System.Windows.Forms.TextBox();
            this.labelImageSizeY = new System.Windows.Forms.Label();
            this.panelImageSizeX = new System.Windows.Forms.Panel();
            this.textBoxImageSizeX = new System.Windows.Forms.TextBox();
            this.labelImageSizeX = new System.Windows.Forms.Label();
            this.groupBoxImageSize.SuspendLayout();
            this.panelReduceBeforeShow.SuspendLayout();
            this.panelImageSizeY.SuspendLayout();
            this.panelImageSizeX.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBoxImageSize
            // 
            this.groupBoxImageSize.Controls.Add(this.panelReduceBeforeShow);
            this.groupBoxImageSize.Controls.Add(this.panelImageSizeY);
            this.groupBoxImageSize.Controls.Add(this.panelImageSizeX);
            this.groupBoxImageSize.Dock = System.Windows.Forms.DockStyle.Top;
            this.groupBoxImageSize.Location = new System.Drawing.Point(5, 5);
            this.groupBoxImageSize.Name = "groupBoxImageSize";
            this.groupBoxImageSize.Size = new System.Drawing.Size(422, 104);
            this.groupBoxImageSize.TabIndex = 1;
            this.groupBoxImageSize.TabStop = false;
            this.groupBoxImageSize.Text = "Image Size";
            // 
            // panelReduceBeforeShow
            // 
            this.panelReduceBeforeShow.BackColor = System.Drawing.SystemColors.Control;
            this.panelReduceBeforeShow.Controls.Add(this.checkBoxReduceSize);
            this.panelReduceBeforeShow.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelReduceBeforeShow.DockPadding.Left = 20;
            this.panelReduceBeforeShow.Location = new System.Drawing.Point(3, 72);
            this.panelReduceBeforeShow.Name = "panelReduceBeforeShow";
            this.panelReduceBeforeShow.Size = new System.Drawing.Size(416, 24);
            this.panelReduceBeforeShow.TabIndex = 3;
            // 
            // checkBoxReduceSize
            // 
            this.checkBoxReduceSize.Dock = System.Windows.Forms.DockStyle.Top;
            this.checkBoxReduceSize.Location = new System.Drawing.Point(20, 0);
            this.checkBoxReduceSize.Name = "checkBoxReduceSize";
            this.checkBoxReduceSize.Size = new System.Drawing.Size(396, 24);
            this.checkBoxReduceSize.TabIndex = 0;
            this.checkBoxReduceSize.Text = "Reduce size before sending data";
            this.checkBoxReduceSize.CheckedChanged += new System.EventHandler(this.checkBoxReduceSize_CheckedChanged);
            // 
            // panelImageSizeY
            // 
            this.panelImageSizeY.Controls.Add(this.textBoxImageSizeY);
            this.panelImageSizeY.Controls.Add(this.labelImageSizeY);
            this.panelImageSizeY.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelImageSizeY.DockPadding.Top = 10;
            this.panelImageSizeY.Location = new System.Drawing.Point(3, 40);
            this.panelImageSizeY.Name = "panelImageSizeY";
            this.panelImageSizeY.Size = new System.Drawing.Size(416, 32);
            this.panelImageSizeY.TabIndex = 2;
            // 
            // textBoxImageSizeY
            // 
            this.textBoxImageSizeY.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.textBoxImageSizeY.Dock = System.Windows.Forms.DockStyle.Fill;
            this.textBoxImageSizeY.Location = new System.Drawing.Point(48, 10);
            this.textBoxImageSizeY.Name = "textBoxImageSizeY";
            this.textBoxImageSizeY.Size = new System.Drawing.Size(368, 20);
            this.textBoxImageSizeY.TabIndex = 1;
            this.textBoxImageSizeY.Text = "1000";
            // 
            // labelImageSizeY
            // 
            this.labelImageSizeY.Dock = System.Windows.Forms.DockStyle.Left;
            this.labelImageSizeY.Location = new System.Drawing.Point(0, 10);
            this.labelImageSizeY.Name = "labelImageSizeY";
            this.labelImageSizeY.Size = new System.Drawing.Size(48, 22);
            this.labelImageSizeY.TabIndex = 0;
            this.labelImageSizeY.Text = "Height";
            this.labelImageSizeY.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // panelImageSizeX
            // 
            this.panelImageSizeX.Controls.Add(this.textBoxImageSizeX);
            this.panelImageSizeX.Controls.Add(this.labelImageSizeX);
            this.panelImageSizeX.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelImageSizeX.Location = new System.Drawing.Point(3, 16);
            this.panelImageSizeX.Name = "panelImageSizeX";
            this.panelImageSizeX.Size = new System.Drawing.Size(416, 24);
            this.panelImageSizeX.TabIndex = 2;
            // 
            // textBoxImageSizeX
            // 
            this.textBoxImageSizeX.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.textBoxImageSizeX.Dock = System.Windows.Forms.DockStyle.Fill;
            this.textBoxImageSizeX.Location = new System.Drawing.Point(48, 0);
            this.textBoxImageSizeX.Name = "textBoxImageSizeX";
            this.textBoxImageSizeX.Size = new System.Drawing.Size(368, 20);
            this.textBoxImageSizeX.TabIndex = 1;
            this.textBoxImageSizeX.Text = "1000";
            // 
            // labelImageSizeX
            // 
            this.labelImageSizeX.Dock = System.Windows.Forms.DockStyle.Left;
            this.labelImageSizeX.Location = new System.Drawing.Point(0, 0);
            this.labelImageSizeX.Name = "labelImageSizeX";
            this.labelImageSizeX.Size = new System.Drawing.Size(48, 24);
            this.labelImageSizeX.TabIndex = 0;
            this.labelImageSizeX.Text = "Width";
            this.labelImageSizeX.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // ReduceImageSizeControl
            // 
            this.Controls.Add(this.groupBoxImageSize);
            this.DockPadding.All = 5;
            this.Name = "ReduceImageSizeControl";
            this.Size = new System.Drawing.Size(432, 416);
            this.groupBoxImageSize.ResumeLayout(false);
            this.panelReduceBeforeShow.ResumeLayout(false);
            this.panelImageSizeY.ResumeLayout(false);
            this.panelImageSizeX.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private bool isInsizeSizeChanged = false;

        protected override void OnSizeChanged(EventArgs e)
        {
            if (!isInsizeSizeChanged)
            {
                isInsizeSizeChanged = true;
                Size = new Size(Size.Width, groupBoxImageSize.Size.Height + this.DockPadding.Bottom + this.DockPadding.Top + 5);
                base.OnSizeChanged(e);
                isInsizeSizeChanged = false;
            }
        }

        private void checkBoxReduceSize_CheckedChanged(object sender, EventArgs e)
        {
            textBoxImageSizeX.Enabled = AllowImageSizeWithoutReduse || checkBoxReduceSize.Checked;
            textBoxImageSizeY.Enabled = AllowImageSizeWithoutReduse || checkBoxReduceSize.Checked;
        }
    }
}