using System;
using guiActions.Parameters;
using MorseKernel2;

namespace guiActions.actionImpl.Tarjan
{
	public class TarjanParameters : ParametersControl
	{
		private System.Windows.Forms.CheckBox resolveEdges;
		private System.ComponentModel.Container components = null;
		


		public TarjanParameters()
		{
			InitializeComponent();

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
			this.resolveEdges = new System.Windows.Forms.CheckBox();
			this.SuspendLayout();
			// 
			// resolveEdges
			// 
			this.resolveEdges.Dock = System.Windows.Forms.DockStyle.Fill;
			this.resolveEdges.Location = new System.Drawing.Point(0, 0);
			this.resolveEdges.Name = "resolveEdges";
			this.resolveEdges.Size = new System.Drawing.Size(512, 360);
			this.resolveEdges.TabIndex = 0;
			this.resolveEdges.Text = "Resolve Edges";
			// 
			// TarjanParameters
			// 
			this.Controls.Add(this.resolveEdges);
			this.Name = "TarjanParameters";
			this.Size = new System.Drawing.Size(512, 360);
			this.ResumeLayout(false);

		}
		#endregion

		protected override IParameters SubmitDataInternal()
		{
			return new TarjanParametersImpl(resolveEdges.Checked);
		}

		public override string BoxCaption
		{
			get { return "Strong Component localization"; }
		}
	}
}
