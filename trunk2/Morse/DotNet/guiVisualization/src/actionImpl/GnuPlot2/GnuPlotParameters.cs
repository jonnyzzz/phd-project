using System;
using System.Collections;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Windows.Forms;

namespace guiVisualization.src.actionImpl.GnuPlot2
{
	/// <summary>
	/// Summary description for GnuPlotParameters.
	/// </summary>
	public class GnuPlotParameters : System.Windows.Forms.UserControl
	{
        private System.Windows.Forms.GroupBox groupOutputFile;
        private System.Windows.Forms.Panel panelOutputFile;
        private System.Windows.Forms.Panel panelFileName;
        private System.Windows.Forms.Label labelFileName;
        private System.Windows.Forms.Panel panelFileNameButton;
        private System.Windows.Forms.Button buttonSelectFileName;
        private System.Windows.Forms.Panel panelFileText;
        private System.Windows.Forms.TextBox textFileName;
        private System.Windows.Forms.TabControl tabControl;
        private System.Windows.Forms.Panel panelFileNameGroup;
        private System.Windows.Forms.TabPage tabSave;
        private System.Windows.Forms.GroupBox groupBoxSettings;
        private System.Windows.Forms.Panel panelImageSize;
        private System.Windows.Forms.Panel panelAdditional;
        private System.Windows.Forms.TabPage tabShow;
        private System.Windows.Forms.Panel panelShow;
        private guiVisualization.actionImpl.GnuPlot2.Controls.ReduceImageSizeControl reduceImageSizeControl;
        private guiVisualization.src.actionImpl.GnuPlot2.Controls.AdditionalSettingsControl additionalSettingsControl;
        private guiVisualization.actionImpl.GnuPlot2.Controls.ReduceImageSizeControl reduceImageSizeControl1;
        private guiVisualization.src.actionImpl.GnuPlot2.Controls.AdditionalSettingsControl additionalSettingsControl1;
		/// <summary> 
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.Container components = null;

		public GnuPlotParameters()
		{
			// This call is required by the Windows.Forms Form Designer.
			InitializeComponent();

			// TODO: Add any initialization after the InitializeComponent call

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
            this.groupOutputFile = new System.Windows.Forms.GroupBox();
            this.panelOutputFile = new System.Windows.Forms.Panel();
            this.panelFileName = new System.Windows.Forms.Panel();
            this.panelFileText = new System.Windows.Forms.Panel();
            this.textFileName = new System.Windows.Forms.TextBox();
            this.panelFileNameButton = new System.Windows.Forms.Panel();
            this.buttonSelectFileName = new System.Windows.Forms.Button();
            this.labelFileName = new System.Windows.Forms.Label();
            this.tabControl = new System.Windows.Forms.TabControl();
            this.tabSave = new System.Windows.Forms.TabPage();
            this.panelFileNameGroup = new System.Windows.Forms.Panel();
            this.groupBoxSettings = new System.Windows.Forms.GroupBox();
            this.panelAdditional = new System.Windows.Forms.Panel();
            this.additionalSettingsControl = new guiVisualization.src.actionImpl.GnuPlot2.Controls.AdditionalSettingsControl();
            this.panelImageSize = new System.Windows.Forms.Panel();
            this.reduceImageSizeControl = new guiVisualization.actionImpl.GnuPlot2.Controls.ReduceImageSizeControl();
            this.tabShow = new System.Windows.Forms.TabPage();
            this.panelShow = new System.Windows.Forms.Panel();
            this.additionalSettingsControl1 = new guiVisualization.src.actionImpl.GnuPlot2.Controls.AdditionalSettingsControl();
            this.reduceImageSizeControl1 = new guiVisualization.actionImpl.GnuPlot2.Controls.ReduceImageSizeControl();
            this.groupOutputFile.SuspendLayout();
            this.panelOutputFile.SuspendLayout();
            this.panelFileName.SuspendLayout();
            this.panelFileText.SuspendLayout();
            this.panelFileNameButton.SuspendLayout();
            this.tabControl.SuspendLayout();
            this.tabSave.SuspendLayout();
            this.panelFileNameGroup.SuspendLayout();
            this.groupBoxSettings.SuspendLayout();
            this.panelAdditional.SuspendLayout();
            this.panelImageSize.SuspendLayout();
            this.tabShow.SuspendLayout();
            this.panelShow.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupOutputFile
            // 
            this.groupOutputFile.Controls.Add(this.panelOutputFile);
            this.groupOutputFile.Dock = System.Windows.Forms.DockStyle.Top;
            this.groupOutputFile.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.groupOutputFile.Location = new System.Drawing.Point(10, 10);
            this.groupOutputFile.Name = "groupOutputFile";
            this.groupOutputFile.Size = new System.Drawing.Size(476, 70);
            this.groupOutputFile.TabIndex = 0;
            this.groupOutputFile.TabStop = false;
            this.groupOutputFile.Text = "Output File Name";
            // 
            // panelOutputFile
            // 
            this.panelOutputFile.Controls.Add(this.panelFileName);
            this.panelOutputFile.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelOutputFile.Location = new System.Drawing.Point(3, 16);
            this.panelOutputFile.Name = "panelOutputFile";
            this.panelOutputFile.Size = new System.Drawing.Size(470, 51);
            this.panelOutputFile.TabIndex = 0;
            // 
            // panelFileName
            // 
            this.panelFileName.Controls.Add(this.panelFileText);
            this.panelFileName.Controls.Add(this.panelFileNameButton);
            this.panelFileName.Controls.Add(this.labelFileName);
            this.panelFileName.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelFileName.Location = new System.Drawing.Point(0, 0);
            this.panelFileName.Name = "panelFileName";
            this.panelFileName.Size = new System.Drawing.Size(470, 40);
            this.panelFileName.TabIndex = 0;
            // 
            // panelFileText
            // 
            this.panelFileText.Controls.Add(this.textFileName);
            this.panelFileText.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelFileText.DockPadding.Top = 10;
            this.panelFileText.Location = new System.Drawing.Point(88, 0);
            this.panelFileText.Name = "panelFileText";
            this.panelFileText.Size = new System.Drawing.Size(334, 40);
            this.panelFileText.TabIndex = 2;
            // 
            // textFileName
            // 
            this.textFileName.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.textFileName.Dock = System.Windows.Forms.DockStyle.Fill;
            this.textFileName.Enabled = false;
            this.textFileName.Location = new System.Drawing.Point(0, 10);
            this.textFileName.Name = "textFileName";
            this.textFileName.Size = new System.Drawing.Size(334, 20);
            this.textFileName.TabIndex = 0;
            this.textFileName.Text = "...";
            // 
            // panelFileNameButton
            // 
            this.panelFileNameButton.Controls.Add(this.buttonSelectFileName);
            this.panelFileNameButton.Dock = System.Windows.Forms.DockStyle.Right;
            this.panelFileNameButton.DockPadding.All = 10;
            this.panelFileNameButton.Location = new System.Drawing.Point(422, 0);
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
            // tabControl
            // 
            this.tabControl.Alignment = System.Windows.Forms.TabAlignment.Bottom;
            this.tabControl.Controls.Add(this.tabSave);
            this.tabControl.Controls.Add(this.tabShow);
            this.tabControl.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabControl.Location = new System.Drawing.Point(0, 0);
            this.tabControl.Name = "tabControl";
            this.tabControl.SelectedIndex = 0;
            this.tabControl.Size = new System.Drawing.Size(504, 296);
            this.tabControl.TabIndex = 1;
            // 
            // tabSave
            // 
            this.tabSave.Controls.Add(this.panelFileNameGroup);
            this.tabSave.Location = new System.Drawing.Point(4, 4);
            this.tabSave.Name = "tabSave";
            this.tabSave.Size = new System.Drawing.Size(496, 270);
            this.tabSave.TabIndex = 0;
            this.tabSave.Text = "Save To File";
            // 
            // panelFileNameGroup
            // 
            this.panelFileNameGroup.Controls.Add(this.groupBoxSettings);
            this.panelFileNameGroup.Controls.Add(this.groupOutputFile);
            this.panelFileNameGroup.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelFileNameGroup.DockPadding.All = 10;
            this.panelFileNameGroup.Location = new System.Drawing.Point(0, 0);
            this.panelFileNameGroup.Name = "panelFileNameGroup";
            this.panelFileNameGroup.Size = new System.Drawing.Size(496, 270);
            this.panelFileNameGroup.TabIndex = 2;
            // 
            // groupBoxSettings
            // 
            this.groupBoxSettings.Controls.Add(this.panelAdditional);
            this.groupBoxSettings.Controls.Add(this.panelImageSize);
            this.groupBoxSettings.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBoxSettings.Location = new System.Drawing.Point(10, 80);
            this.groupBoxSettings.Name = "groupBoxSettings";
            this.groupBoxSettings.Size = new System.Drawing.Size(476, 180);
            this.groupBoxSettings.TabIndex = 1;
            this.groupBoxSettings.TabStop = false;
            this.groupBoxSettings.Text = "Settings";
            // 
            // panelAdditional
            // 
            this.panelAdditional.Controls.Add(this.additionalSettingsControl);
            this.panelAdditional.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelAdditional.Location = new System.Drawing.Point(3, 112);
            this.panelAdditional.Name = "panelAdditional";
            this.panelAdditional.Size = new System.Drawing.Size(470, 56);
            this.panelAdditional.TabIndex = 1;
            // 
            // additionalSettingsControl
            // 
            this.additionalSettingsControl.Dock = System.Windows.Forms.DockStyle.Fill;
            this.additionalSettingsControl.DockPadding.All = 5;
            this.additionalSettingsControl.Location = new System.Drawing.Point(0, 0);
            this.additionalSettingsControl.Name = "additionalSettingsControl";
            this.additionalSettingsControl.Size = new System.Drawing.Size(470, 55);
            this.additionalSettingsControl.TabIndex = 0;
            // 
            // panelImageSize
            // 
            this.panelImageSize.Controls.Add(this.reduceImageSizeControl);
            this.panelImageSize.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelImageSize.Location = new System.Drawing.Point(3, 16);
            this.panelImageSize.Name = "panelImageSize";
            this.panelImageSize.Size = new System.Drawing.Size(470, 96);
            this.panelImageSize.TabIndex = 0;
            // 
            // reduceImageSizeControl
            // 
            this.reduceImageSizeControl.AllowImageSizeWithoutReduse = false;
            this.reduceImageSizeControl.Dock = System.Windows.Forms.DockStyle.Fill;
            this.reduceImageSizeControl.DockPadding.All = 5;
            this.reduceImageSizeControl.Location = new System.Drawing.Point(0, 0);
            this.reduceImageSizeControl.Name = "reduceImageSizeControl";
            this.reduceImageSizeControl.Reduse = false;
            this.reduceImageSizeControl.Size = new System.Drawing.Size(470, 119);
            this.reduceImageSizeControl.TabIndex = 0;
            // 
            // tabShow
            // 
            this.tabShow.Controls.Add(this.panelShow);
            this.tabShow.Location = new System.Drawing.Point(4, 4);
            this.tabShow.Name = "tabShow";
            this.tabShow.Size = new System.Drawing.Size(496, 270);
            this.tabShow.TabIndex = 1;
            this.tabShow.Text = "Show";
            // 
            // panelShow
            // 
            this.panelShow.Controls.Add(this.additionalSettingsControl1);
            this.panelShow.Controls.Add(this.reduceImageSizeControl1);
            this.panelShow.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelShow.DockPadding.All = 10;
            this.panelShow.Location = new System.Drawing.Point(0, 0);
            this.panelShow.Name = "panelShow";
            this.panelShow.Size = new System.Drawing.Size(496, 270);
            this.panelShow.TabIndex = 0;
            // 
            // additionalSettingsControl1
            // 
            this.additionalSettingsControl1.Dock = System.Windows.Forms.DockStyle.Top;
            this.additionalSettingsControl1.DockPadding.All = 5;
            this.additionalSettingsControl1.Location = new System.Drawing.Point(10, 129);
            this.additionalSettingsControl1.Name = "additionalSettingsControl1";
            this.additionalSettingsControl1.Size = new System.Drawing.Size(476, 55);
            this.additionalSettingsControl1.TabIndex = 1;
            // 
            // reduceImageSizeControl1
            // 
            this.reduceImageSizeControl1.AllowImageSizeWithoutReduse = false;
            this.reduceImageSizeControl1.Dock = System.Windows.Forms.DockStyle.Top;
            this.reduceImageSizeControl1.DockPadding.All = 5;
            this.reduceImageSizeControl1.Location = new System.Drawing.Point(10, 10);
            this.reduceImageSizeControl1.Name = "reduceImageSizeControl1";
            this.reduceImageSizeControl1.Reduse = false;
            this.reduceImageSizeControl1.Size = new System.Drawing.Size(476, 119);
            this.reduceImageSizeControl1.TabIndex = 0;
            // 
            // GnuPlotParameters
            // 
            this.Controls.Add(this.tabControl);
            this.Name = "GnuPlotParameters";
            this.Size = new System.Drawing.Size(504, 296);
            this.groupOutputFile.ResumeLayout(false);
            this.panelOutputFile.ResumeLayout(false);
            this.panelFileName.ResumeLayout(false);
            this.panelFileText.ResumeLayout(false);
            this.panelFileNameButton.ResumeLayout(false);
            this.tabControl.ResumeLayout(false);
            this.tabSave.ResumeLayout(false);
            this.panelFileNameGroup.ResumeLayout(false);
            this.groupBoxSettings.ResumeLayout(false);
            this.panelAdditional.ResumeLayout(false);
            this.panelImageSize.ResumeLayout(false);
            this.tabShow.ResumeLayout(false);
            this.panelShow.ResumeLayout(false);
            this.ResumeLayout(false);

        }
		#endregion

        private void groupBoxImageSize_Enter(object sender, System.EventArgs e)
        {
        
        }
	}
}
