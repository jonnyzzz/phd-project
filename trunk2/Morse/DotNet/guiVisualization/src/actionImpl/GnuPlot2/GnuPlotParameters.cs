using System.ComponentModel;
using System.Windows.Forms;
using EugenePetrenko.Gui2.Actions.Parameters;
using EugenePetrenko.Gui2.MorseKernel2;
using EugenePetrenko.Gui2.Visualization.src.actionImpl.GnuPlot2;

namespace EugenePetrenko.Gui2.Visualization.ActionImpl.GnuPlot2
{
    /// <summary>
    /// Summary description for GnuPlotParameters.
    /// </summary>
    public class GnuPlotParameters : ParametersControl
    {        
        private TabControl tabControl;     
        private Panel panelMain;
        private TabPage tabSave;        
        private TabPage tabShow;

        private SaveImageControl saveImage;
        private ShowImageControl showImage;
        
        /// <summary> 
        /// Required designer variable.
        /// </summary>
        private Container components = null;

        public GnuPlotParameters()
        {
            InitializeComponent();
            tabControl.SelectedTab = tabShow;
        }

        protected override IParameters SubmitDataInternal()
        {
            if (tabControl.SelectedTab == tabSave)
            {
                return saveImage.SubmitData();
            } else if (tabControl.SelectedTab == tabShow)
            {
                return showImage.SubmitData();
            } else throw new ParametersControlException("Please select type of view");
        }

        public override string BoxCaption
        {
            get { return "Visualization Options"; }
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
            this.panelMain = new System.Windows.Forms.Panel();
            this.tabControl = new System.Windows.Forms.TabControl();
            this.tabSave = new System.Windows.Forms.TabPage();
            this.saveImage = new EugenePetrenko.Gui2.Visualization.src.actionImpl.GnuPlot2.SaveImageControl();
            this.tabShow = new System.Windows.Forms.TabPage();
            this.showImage = new EugenePetrenko.Gui2.Visualization.src.actionImpl.GnuPlot2.ShowImageControl();
            this.panelMain.SuspendLayout();
            this.tabControl.SuspendLayout();
            this.tabSave.SuspendLayout();
            this.tabShow.SuspendLayout();
            this.SuspendLayout();
            // 
            // panelMain
            // 
            this.panelMain.Controls.Add(this.tabControl);
            this.panelMain.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelMain.Location = new System.Drawing.Point(0, 0);
            this.panelMain.Name = "panelMain";
            this.panelMain.Size = new System.Drawing.Size(432, 328);
            this.panelMain.TabIndex = 0;
            // 
            // tabControl
            // 
            this.tabControl.Appearance = System.Windows.Forms.TabAppearance.FlatButtons;
            this.tabControl.Controls.Add(this.tabSave);
            this.tabControl.Controls.Add(this.tabShow);
            this.tabControl.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabControl.Location = new System.Drawing.Point(0, 0);
            this.tabControl.Multiline = true;
            this.tabControl.Name = "tabControl";
            this.tabControl.SelectedIndex = 0;
            this.tabControl.Size = new System.Drawing.Size(432, 328);
            this.tabControl.TabIndex = 1;
            // 
            // tabSave
            // 
            this.tabSave.Controls.Add(this.saveImage);
            this.tabSave.Location = new System.Drawing.Point(4, 25);
            this.tabSave.Name = "tabSave";
            this.tabSave.Size = new System.Drawing.Size(424, 299);
            this.tabSave.TabIndex = 0;
            this.tabSave.Text = "Save To File";
            // 
            // saveImage
            // 
            this.saveImage.AutoScroll = true;
            this.saveImage.AutoScrollMinSize = new System.Drawing.Size(360, 0);
            this.saveImage.Dock = System.Windows.Forms.DockStyle.Fill;
            this.saveImage.Location = new System.Drawing.Point(0, 0);
            this.saveImage.Name = "saveImage";
            this.saveImage.Size = new System.Drawing.Size(424, 299);
            this.saveImage.TabIndex = 0;
            // 
            // tabShow
            // 
            this.tabShow.Controls.Add(this.showImage);
            this.tabShow.Location = new System.Drawing.Point(4, 25);
            this.tabShow.Name = "tabShow";
            this.tabShow.Size = new System.Drawing.Size(424, 299);
            this.tabShow.TabIndex = 1;
            this.tabShow.Text = "Show";
            // 
            // showImage
            // 
            this.showImage.AutoScroll = true;
            this.showImage.AutoScrollMinSize = new System.Drawing.Size(360, 0);
            this.showImage.Dock = System.Windows.Forms.DockStyle.Fill;
            this.showImage.Location = new System.Drawing.Point(0, 0);
            this.showImage.Name = "showImage";
            this.showImage.Size = new System.Drawing.Size(424, 299);
            this.showImage.TabIndex = 0;
            // 
            // GnuPlotParameters
            // 
            this.Controls.Add(this.panelMain);
            this.Name = "GnuPlotParameters";
            this.Size = new System.Drawing.Size(432, 328);
            this.panelMain.ResumeLayout(false);
            this.tabControl.ResumeLayout(false);
            this.tabSave.ResumeLayout(false);
            this.tabShow.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion                
    }
}