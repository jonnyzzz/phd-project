using System.Windows.Forms;
using EugenePetrenko.Gui2.Actions.Parameters;
using EugenePetrenko.Gui2.ExternalResource.Core;
using EugenePetrenko.Gui2.MorseKernel2;
using EugenePetrenko.Gui2.Visualization.ActionImpl.GnuPlot2;

namespace EugenePetrenko.Gui2.Visualization.src.actionImpl.GnuPlot2
{
	/// <summary>
	/// Summary description for SaveImageControl.
	/// </summary>
	public class SaveImageControl : System.Windows.Forms.UserControl
	{
        private System.Windows.Forms.Panel panelMain;
        private System.Windows.Forms.Panel panelOutputFile;
        private System.Windows.Forms.GroupBox groupOutputFile;
        private System.Windows.Forms.Panel panelFileName;
        private System.Windows.Forms.Panel panelFileText;
        private System.Windows.Forms.TextBox textFileName;
        private System.Windows.Forms.Panel panelFileNameButton;
        private System.Windows.Forms.Button buttonSelectFileName;
        private System.Windows.Forms.Label labelFileName;
        private System.Windows.Forms.Panel panelImageSize;
        private System.Windows.Forms.Panel panelSaveInternal;
        private EugenePetrenko.Gui2.Visualization.ActionImpl.GnuPlot2.ReduceImageSizeControl reduceImageSize;
        private System.Windows.Forms.Panel panelAdditional;
        private EugenePetrenko.Gui2.Visualization.ActionImpl.GnuPlot2.AdditionalSettingsControl additionalSettings;
        private System.Windows.Forms.SaveFileDialog dialogSave;
		/// <summary> 
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.Container components = null;
		private System.Windows.Forms.Panel panelShowStyle;
		private EugenePetrenko.Gui2.Visualization.ActionImpl.GnuPlot2.ShowStyleControl showStyleControl;

	    private bool dialogSuccess = false;

	    public SaveImageControl()
		{
			InitializeComponent();
			showStyleControl.SetControlData(
				ResourceManager.Instance.GetXmlResourceFromCommon("gnuplot"));
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
			this.panelMain = new System.Windows.Forms.Panel();
			this.panelAdditional = new System.Windows.Forms.Panel();
			this.additionalSettings = new EugenePetrenko.Gui2.Visualization.ActionImpl.GnuPlot2.AdditionalSettingsControl();
			this.panelImageSize = new System.Windows.Forms.Panel();
			this.reduceImageSize = new EugenePetrenko.Gui2.Visualization.ActionImpl.GnuPlot2.ReduceImageSizeControl();
			this.panelOutputFile = new System.Windows.Forms.Panel();
			this.groupOutputFile = new System.Windows.Forms.GroupBox();
			this.panelSaveInternal = new System.Windows.Forms.Panel();
			this.panelFileName = new System.Windows.Forms.Panel();
			this.panelFileText = new System.Windows.Forms.Panel();
			this.textFileName = new System.Windows.Forms.TextBox();
			this.panelFileNameButton = new System.Windows.Forms.Panel();
			this.buttonSelectFileName = new System.Windows.Forms.Button();
			this.labelFileName = new System.Windows.Forms.Label();
			this.dialogSave = new System.Windows.Forms.SaveFileDialog();
			this.panelShowStyle = new System.Windows.Forms.Panel();
			this.showStyleControl = new EugenePetrenko.Gui2.Visualization.ActionImpl.GnuPlot2.ShowStyleControl();
			this.panelMain.SuspendLayout();
			this.panelAdditional.SuspendLayout();
			this.panelImageSize.SuspendLayout();
			this.panelOutputFile.SuspendLayout();
			this.groupOutputFile.SuspendLayout();
			this.panelSaveInternal.SuspendLayout();
			this.panelFileName.SuspendLayout();
			this.panelFileText.SuspendLayout();
			this.panelFileNameButton.SuspendLayout();
			this.panelShowStyle.SuspendLayout();
			this.SuspendLayout();
			// 
			// panelMain
			// 
			this.panelMain.Controls.Add(this.panelShowStyle);
			this.panelMain.Controls.Add(this.panelAdditional);
			this.panelMain.Controls.Add(this.panelImageSize);
			this.panelMain.Controls.Add(this.panelOutputFile);
			this.panelMain.Dock = System.Windows.Forms.DockStyle.Fill;
			this.panelMain.Location = new System.Drawing.Point(0, 0);
			this.panelMain.Name = "panelMain";
			this.panelMain.Size = new System.Drawing.Size(424, 376);
			this.panelMain.TabIndex = 0;
			// 
			// panelAdditional
			// 
			this.panelAdditional.Controls.Add(this.additionalSettings);
			this.panelAdditional.Dock = System.Windows.Forms.DockStyle.Top;
			this.panelAdditional.Location = new System.Drawing.Point(0, 208);
			this.panelAdditional.Name = "panelAdditional";
			this.panelAdditional.Size = new System.Drawing.Size(424, 72);
			this.panelAdditional.TabIndex = 2;
			// 
			// additionalSettings
			// 
			this.additionalSettings.Dock = System.Windows.Forms.DockStyle.Fill;
			this.additionalSettings.DockPadding.All = 5;
			this.additionalSettings.IsDrawBoxesChecked = false;
			this.additionalSettings.IsShowHistoryChecked = true;
			this.additionalSettings.Location = new System.Drawing.Point(0, 0);
			this.additionalSettings.Name = "additionalSettings";
			this.additionalSettings.Size = new System.Drawing.Size(424, 55);
			this.additionalSettings.TabIndex = 1;
			// 
			// panelImageSize
			// 
			this.panelImageSize.Controls.Add(this.reduceImageSize);
			this.panelImageSize.Dock = System.Windows.Forms.DockStyle.Top;
			this.panelImageSize.Location = new System.Drawing.Point(0, 80);
			this.panelImageSize.Name = "panelImageSize";
			this.panelImageSize.Size = new System.Drawing.Size(424, 128);
			this.panelImageSize.TabIndex = 1;
			// 
			// reduceImageSize
			// 
			this.reduceImageSize.AllowImageSizeWithoutReduse = true;
			this.reduceImageSize.Dock = System.Windows.Forms.DockStyle.Fill;
			this.reduceImageSize.DockPadding.All = 5;
			this.reduceImageSize.Location = new System.Drawing.Point(0, 0);
			this.reduceImageSize.Name = "reduceImageSize";
			this.reduceImageSize.NeedResizeInside = false;
			this.reduceImageSize.Reduse = false;
			this.reduceImageSize.Size = new System.Drawing.Size(424, 119);
			this.reduceImageSize.TabIndex = 0;
			// 
			// panelOutputFile
			// 
			this.panelOutputFile.AutoScroll = true;
			this.panelOutputFile.AutoScrollMinSize = new System.Drawing.Size(350, 70);
			this.panelOutputFile.Controls.Add(this.groupOutputFile);
			this.panelOutputFile.Dock = System.Windows.Forms.DockStyle.Top;
			this.panelOutputFile.DockPadding.All = 5;
			this.panelOutputFile.Location = new System.Drawing.Point(0, 0);
			this.panelOutputFile.Name = "panelOutputFile";
			this.panelOutputFile.Size = new System.Drawing.Size(424, 80);
			this.panelOutputFile.TabIndex = 0;
			// 
			// groupOutputFile
			// 
			this.groupOutputFile.Controls.Add(this.panelSaveInternal);
			this.groupOutputFile.Dock = System.Windows.Forms.DockStyle.Top;
			this.groupOutputFile.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			this.groupOutputFile.Location = new System.Drawing.Point(5, 5);
			this.groupOutputFile.Name = "groupOutputFile";
			this.groupOutputFile.Size = new System.Drawing.Size(414, 70);
			this.groupOutputFile.TabIndex = 1;
			this.groupOutputFile.TabStop = false;
			this.groupOutputFile.Text = "Output File Name";
			// 
			// panelSaveInternal
			// 
			this.panelSaveInternal.Controls.Add(this.panelFileName);
			this.panelSaveInternal.Dock = System.Windows.Forms.DockStyle.Fill;
			this.panelSaveInternal.Location = new System.Drawing.Point(3, 16);
			this.panelSaveInternal.Name = "panelSaveInternal";
			this.panelSaveInternal.Size = new System.Drawing.Size(408, 51);
			this.panelSaveInternal.TabIndex = 0;
			// 
			// panelFileName
			// 
			this.panelFileName.Controls.Add(this.panelFileText);
			this.panelFileName.Controls.Add(this.panelFileNameButton);
			this.panelFileName.Controls.Add(this.labelFileName);
			this.panelFileName.Dock = System.Windows.Forms.DockStyle.Top;
			this.panelFileName.Location = new System.Drawing.Point(0, 0);
			this.panelFileName.Name = "panelFileName";
			this.panelFileName.Size = new System.Drawing.Size(408, 40);
			this.panelFileName.TabIndex = 0;
			// 
			// panelFileText
			// 
			this.panelFileText.Controls.Add(this.textFileName);
			this.panelFileText.Dock = System.Windows.Forms.DockStyle.Fill;
			this.panelFileText.DockPadding.Top = 10;
			this.panelFileText.Location = new System.Drawing.Point(88, 0);
			this.panelFileText.Name = "panelFileText";
			this.panelFileText.Size = new System.Drawing.Size(272, 40);
			this.panelFileText.TabIndex = 2;
			// 
			// textFileName
			// 
			this.textFileName.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.textFileName.Dock = System.Windows.Forms.DockStyle.Fill;
			this.textFileName.Enabled = false;
			this.textFileName.Location = new System.Drawing.Point(0, 10);
			this.textFileName.Name = "textFileName";
			this.textFileName.Size = new System.Drawing.Size(272, 20);
			this.textFileName.TabIndex = 0;
			this.textFileName.Text = "...";
			// 
			// panelFileNameButton
			// 
			this.panelFileNameButton.Controls.Add(this.buttonSelectFileName);
			this.panelFileNameButton.Dock = System.Windows.Forms.DockStyle.Right;
			this.panelFileNameButton.DockPadding.All = 10;
			this.panelFileNameButton.Location = new System.Drawing.Point(360, 0);
			this.panelFileNameButton.Name = "panelFileNameButton";
			this.panelFileNameButton.Size = new System.Drawing.Size(48, 40);
			this.panelFileNameButton.TabIndex = 1;
			// 
			// buttonSelectFileName
			// 
			this.buttonSelectFileName.Dock = System.Windows.Forms.DockStyle.Fill;
			this.buttonSelectFileName.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			this.buttonSelectFileName.Location = new System.Drawing.Point(10, 10);
			this.buttonSelectFileName.Name = "buttonSelectFileName";
			this.buttonSelectFileName.Size = new System.Drawing.Size(28, 20);
			this.buttonSelectFileName.TabIndex = 0;
			this.buttonSelectFileName.Text = "...";
			this.buttonSelectFileName.Click += new System.EventHandler(this.buttonSelectFileName_Click);
			// 
			// labelFileName
			// 
			this.labelFileName.Dock = System.Windows.Forms.DockStyle.Left;
			this.labelFileName.Location = new System.Drawing.Point(0, 0);
			this.labelFileName.Name = "labelFileName";
			this.labelFileName.Size = new System.Drawing.Size(88, 40);
			this.labelFileName.TabIndex = 0;
			this.labelFileName.Text = "Selet file name";
			this.labelFileName.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			// 
			// dialogSave
			// 
			this.dialogSave.DefaultExt = "png";
			this.dialogSave.FileName = "image.png";
			this.dialogSave.Filter = "Png image (*.png)|*.png|All Files (*.*)|*.*";
			this.dialogSave.RestoreDirectory = true;
			this.dialogSave.Title = "Select filename to save image";
			// 
			// panelShowStyle
			// 
			this.panelShowStyle.Controls.Add(this.showStyleControl);
			this.panelShowStyle.Dock = System.Windows.Forms.DockStyle.Top;
			this.panelShowStyle.DockPadding.All = 5;
			this.panelShowStyle.Location = new System.Drawing.Point(0, 280);
			this.panelShowStyle.Name = "panelShowStyle";
			this.panelShowStyle.Size = new System.Drawing.Size(424, 40);
			this.panelShowStyle.TabIndex = 3;
			// 
			// showStyleControl
			// 
			this.showStyleControl.Dock = System.Windows.Forms.DockStyle.Fill;
			this.showStyleControl.Location = new System.Drawing.Point(5, 5);
			this.showStyleControl.Name = "showStyleControl";
			this.showStyleControl.Size = new System.Drawing.Size(414, 30);
			this.showStyleControl.TabIndex = 0;
			// 
			// SaveImageControl
			// 
			this.AutoScroll = true;
			this.AutoScrollMinSize = new System.Drawing.Size(424, 0);
			this.Controls.Add(this.panelMain);
			this.Location = new System.Drawing.Point(300, 0);
			this.Name = "SaveImageControl";
			this.Size = new System.Drawing.Size(424, 376);
			this.panelMain.ResumeLayout(false);
			this.panelAdditional.ResumeLayout(false);
			this.panelImageSize.ResumeLayout(false);
			this.panelOutputFile.ResumeLayout(false);
			this.groupOutputFile.ResumeLayout(false);
			this.panelSaveInternal.ResumeLayout(false);
			this.panelFileName.ResumeLayout(false);
			this.panelFileText.ResumeLayout(false);
			this.panelFileNameButton.ResumeLayout(false);
			this.panelShowStyle.ResumeLayout(false);
			this.ResumeLayout(false);

		}
		#endregion

        private void buttonSelectFileName_Click(object sender, System.EventArgs e)
        {
            if (this.dialogSave.ShowDialog(this) == DialogResult.OK)
            {
                dialogSuccess = true;
                this.textFileName.Text = dialogSave.FileName;
            } else
            {
                dialogSuccess = false;
            }
        }


        public IParameters SubmitData()
        {
            if (!dialogSuccess)
                throw new ParametersControlException("Please Select File to Save");

            return new GnuPlotParametersImpl(
                this.dialogSave.FileName, 
				showStyleControl.SelectedValue,
                this.reduceImageSize.GetImageSize().Width,
                this.reduceImageSize.GetImageSize().Height,
                this.additionalSettings.IsShowHistoryChecked,
                true,
                false,
                this.additionalSettings.IsDrawBoxesChecked
                );
        }
	}
}
