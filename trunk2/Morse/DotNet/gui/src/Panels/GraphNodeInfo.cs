using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;
using gui.Tree.Node.Util;
using MorseKernelATL;

namespace gui.Panels
{
	/// <summary>
	/// Summary description for GraphNodeInfo.
	/// </summary>
	public class GraphNodeInfo : System.Windows.Forms.UserControl
	{
        private gui.Panels.NotedTextField spaceSize;
        private gui.Panels.NotedTextField cellSize;
        private gui.Panels.NotedTextField pointsPerAxis;
        private gui.Panels.NotedTextField graphParameters;
        private System.Windows.Forms.Panel panelMargins;
		/// <summary>
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.Container components = null;

		public GraphNodeInfo(IGraphInfo info)
		{
			InitializeComponent();


            FromGraphInfo(new InfoGraphParser(info));
		}

        private void FromGraphInfo(InfoGraphParser parser)
        {
            this.spaceSize.Value = parser.Space();
            this.cellSize.Value = parser.GridSize();
            this.pointsPerAxis.Value = parser.GridNum();
            this.graphParameters.Value = string.Format("nodes = {0}; edges = {1}", parser.Nodes, parser.Edges);
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

		#region Windows Form Designer generated code
		/// <summary>
		/// Required method for Designer support - do not modify
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent()
		{
            this.spaceSize = new gui.Panels.NotedTextField();
            this.panelMargins = new System.Windows.Forms.Panel();
            this.graphParameters = new gui.Panels.NotedTextField();
            this.pointsPerAxis = new gui.Panels.NotedTextField();
            this.cellSize = new gui.Panels.NotedTextField();
            this.panelMargins.SuspendLayout();
            this.SuspendLayout();
            // 
            // spaceSize
            // 
            this.spaceSize.Caption = "Space Size";
            this.spaceSize.Dock = System.Windows.Forms.DockStyle.Top;
            this.spaceSize.Location = new System.Drawing.Point(20, 20);
            this.spaceSize.Name = "spaceSize";
            this.spaceSize.Size = new System.Drawing.Size(324, 48);
            this.spaceSize.TabIndex = 0;
            this.spaceSize.Value = "textBox";
            // 
            // panelMargins
            // 
            this.panelMargins.Controls.Add(this.graphParameters);
            this.panelMargins.Controls.Add(this.pointsPerAxis);
            this.panelMargins.Controls.Add(this.cellSize);
            this.panelMargins.Controls.Add(this.spaceSize);
            this.panelMargins.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelMargins.DockPadding.Bottom = 10;
            this.panelMargins.DockPadding.Left = 20;
            this.panelMargins.DockPadding.Right = 40;
            this.panelMargins.DockPadding.Top = 20;
            this.panelMargins.Location = new System.Drawing.Point(0, 0);
            this.panelMargins.Name = "panelMargins";
            this.panelMargins.Size = new System.Drawing.Size(384, 352);
            this.panelMargins.TabIndex = 1;
            // 
            // graphParameters
            // 
            this.graphParameters.Caption = "";
            this.graphParameters.Dock = System.Windows.Forms.DockStyle.Top;
            this.graphParameters.Location = new System.Drawing.Point(20, 164);
            this.graphParameters.Name = "graphParameters";
            this.graphParameters.Size = new System.Drawing.Size(324, 48);
            this.graphParameters.TabIndex = 3;
            this.graphParameters.Value = "textBox";
            // 
            // pointsPerAxis
            // 
            this.pointsPerAxis.Caption = "Points per axis";
            this.pointsPerAxis.Dock = System.Windows.Forms.DockStyle.Top;
            this.pointsPerAxis.Location = new System.Drawing.Point(20, 116);
            this.pointsPerAxis.Name = "pointsPerAxis";
            this.pointsPerAxis.Size = new System.Drawing.Size(324, 48);
            this.pointsPerAxis.TabIndex = 2;
            this.pointsPerAxis.Value = "textBox";
            // 
            // cellSize
            // 
            this.cellSize.Caption = "Cell Size";
            this.cellSize.Dock = System.Windows.Forms.DockStyle.Top;
            this.cellSize.Location = new System.Drawing.Point(20, 68);
            this.cellSize.Name = "cellSize";
            this.cellSize.Size = new System.Drawing.Size(324, 48);
            this.cellSize.TabIndex = 1;
            this.cellSize.Value = "textBox";
            // 
            // GraphNodeInfo
            // 
            this.Controls.Add(this.panelMargins);
            this.Name = "GraphNodeInfo";
            this.Size = new System.Drawing.Size(384, 352);
            this.panelMargins.ResumeLayout(false);
            this.ResumeLayout(false);

        }
		#endregion
	}
}
