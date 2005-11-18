using System;
using System.ComponentModel;
using System.Windows.Forms;

namespace EugenePetrenko.Gui2.Controls.TextFields
{
    /// <summary>
    /// Summary description for CenteredTextBox.
    /// </summary>
    public class CenteredTextBox : UserControl
    {
        private Panel panelUp;
        private TextBox textControl;
        private Panel panelCenter;

        /// <summary> 
        /// Required designer variable.
        /// </summary>
        private Container components = null;

        public CenteredTextBox()
        {
            InitializeComponent();

            this.BackColor = textControl.BackColor;
            panelUp.BackColor = textControl.BackColor;
            panelCenter.BackColor = textControl.BackColor;

            textControl.BackColorChanged += new EventHandler(textControl_BackColorChanged);
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
            this.panelUp = new System.Windows.Forms.Panel();
            this.textControl = new System.Windows.Forms.TextBox();
            this.panelCenter = new System.Windows.Forms.Panel();
            this.panelCenter.SuspendLayout();
            this.SuspendLayout();
            // 
            // panelUp
            // 
            this.panelUp.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelUp.Location = new System.Drawing.Point(5, 0);
            this.panelUp.Name = "panelUp";
            this.panelUp.Size = new System.Drawing.Size(92, 16);
            this.panelUp.TabIndex = 0;
            // 
            // textControl
            // 
            this.textControl.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.textControl.Dock = System.Windows.Forms.DockStyle.Top;
            this.textControl.Location = new System.Drawing.Point(5, 16);
            this.textControl.Name = "textControl";
            this.textControl.Size = new System.Drawing.Size(92, 13);
            this.textControl.TabIndex = 1;
            this.textControl.Text = "textControl";
            // 
            // panelCenter
            // 
            this.panelCenter.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panelCenter.Controls.Add(this.textControl);
            this.panelCenter.Controls.Add(this.panelUp);
            this.panelCenter.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelCenter.DockPadding.Left = 5;
            this.panelCenter.DockPadding.Right = 5;
            this.panelCenter.Location = new System.Drawing.Point(0, 0);
            this.panelCenter.Name = "panelCenter";
            this.panelCenter.Size = new System.Drawing.Size(104, 160);
            this.panelCenter.TabIndex = 2;
            // 
            // CenteredTextBox
            // 
            this.Controls.Add(this.panelCenter);
            this.Name = "CenteredTextBox";
            this.Size = new System.Drawing.Size(104, 160);
            this.Resize += new System.EventHandler(this.CenteredTextBox_Resize);
            this.panelCenter.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private void CenteredTextBox_Resize(object sender, EventArgs e)
        {
            int height = (Height - textControl.Height)/2;
            if (height < 0) height = 0;
            panelUp.Height = height;

            this.Refresh();
        }

        public TextBox TextControl
        {
            get { return textControl; }
        }

        private void textControl_BackColorChanged(object sender, EventArgs e)
        {
            this.BackColor = textControl.BackColor;
            panelUp.BackColor = textControl.BackColor;
            panelCenter.BackColor = textControl.BackColor;
        }
    }
}