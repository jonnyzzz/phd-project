using System;
using System.Drawing;
using System.Windows.Forms;
using guiActions.actionImpl.MinimalLoopLocalization;
using guiActions.Parameters;
using guiActions.src.parameters;
using guiControls.Control;
using guiKernel2.Actions;
using guiKernel2.Container;
using guiKernel2.Node;
using MorseKernel2;

namespace guiActions.actionImpl.HomotopAction
{
	/// <summary>
	/// Summary description for HomotopParameters.
	/// </summary>
	public class HomotopParameters : ParametersControl
	{
		private readonly KernelNode node;
		private bool hasCorrectData = false;
		private ProgressBarInfo progressBarInfo = new ProgressBarInfo();
		private volatile IGraphResult graphResult = null;

		protected override IParameters SubmitDataInternal()
		{
			if (graphResult == null)
			{				
				PerformSearch();
				if (graphResult == null)
				{
					throw new ParametersControlException("Please select initial contour to start");
				}
			}
			return new HomotopParametersImpl(graphResult);
		}

		private System.Windows.Forms.GroupBox groupBoxPointSelection;
		private guiActions.actionImpl.MinimalLoopLocalization.MinimalLoopLocalizationParameters minimalLoop;
		private System.Windows.Forms.GroupBox groupBoxDown;
		private System.Windows.Forms.Panel panelDown;
		private System.Windows.Forms.Panel panelUpper;
		private System.Windows.Forms.Label labelStatic;
		private System.Windows.Forms.Panel panelPreAnswer;
		private System.Windows.Forms.Panel panelPreAnswerGapRight;
		private System.Windows.Forms.Label labelLength;
		private System.Windows.Forms.LinkLabel linkUpdate;

		public override string BoxCaption
		{
			get { return "Isolating Set parameters"; }
		}

		private System.ComponentModel.Container components = null;

		public HomotopParameters(KernelNode node)
		{
			this.node = node;
			InitializeComponent();
			minimalLoop.DataChanged +=new guiControls.Grid.ContentChanged(minimalLoop_DataChanged);
			progressBarInfo.Tick +=new ProgressBarTick(progressBarInfo_Tick);
			minimalLoop.Initialize((node.Results.ToResults[0] as IGraphResult).GetGraphInfo().GetDimension());
			updateLink();			
		}

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
			this.minimalLoop = new guiActions.actionImpl.MinimalLoopLocalization.MinimalLoopLocalizationParameters();
			this.groupBoxPointSelection = new System.Windows.Forms.GroupBox();
			this.panelDown = new System.Windows.Forms.Panel();
			this.groupBoxDown = new System.Windows.Forms.GroupBox();
			this.panelPreAnswer = new System.Windows.Forms.Panel();
			this.labelStatic = new System.Windows.Forms.Label();
			this.panelUpper = new System.Windows.Forms.Panel();
			this.panelPreAnswerGapRight = new System.Windows.Forms.Panel();
			this.labelLength = new System.Windows.Forms.Label();
			this.linkUpdate = new System.Windows.Forms.LinkLabel();
			this.groupBoxPointSelection.SuspendLayout();
			this.panelDown.SuspendLayout();
			this.groupBoxDown.SuspendLayout();
			this.panelPreAnswer.SuspendLayout();
			this.panelUpper.SuspendLayout();
			this.SuspendLayout();
			// 
			// minimalLoop
			// 
			this.minimalLoop.Dock = System.Windows.Forms.DockStyle.Fill;
			this.minimalLoop.Location = new System.Drawing.Point(3, 16);
			this.minimalLoop.Name = "minimalLoop";
			this.minimalLoop.Size = new System.Drawing.Size(364, 239);
			this.minimalLoop.TabIndex = 0;
			// 
			// groupBoxPointSelection
			// 
			this.groupBoxPointSelection.Controls.Add(this.minimalLoop);
			this.groupBoxPointSelection.Dock = System.Windows.Forms.DockStyle.Fill;
			this.groupBoxPointSelection.Location = new System.Drawing.Point(3, 3);
			this.groupBoxPointSelection.Name = "groupBoxPointSelection";
			this.groupBoxPointSelection.Size = new System.Drawing.Size(370, 258);
			this.groupBoxPointSelection.TabIndex = 1;
			this.groupBoxPointSelection.TabStop = false;
			this.groupBoxPointSelection.Text = "Select point to find minimal loop";
			// 
			// panelDown
			// 
			this.panelDown.Controls.Add(this.groupBoxDown);
			this.panelDown.Dock = System.Windows.Forms.DockStyle.Bottom;
			this.panelDown.DockPadding.All = 3;
			this.panelDown.Location = new System.Drawing.Point(0, 264);
			this.panelDown.Name = "panelDown";
			this.panelDown.Size = new System.Drawing.Size(376, 56);
			this.panelDown.TabIndex = 2;
			// 
			// groupBoxDown
			// 
			this.groupBoxDown.Controls.Add(this.panelPreAnswer);
			this.groupBoxDown.Dock = System.Windows.Forms.DockStyle.Fill;
			this.groupBoxDown.Location = new System.Drawing.Point(3, 3);
			this.groupBoxDown.Name = "groupBoxDown";
			this.groupBoxDown.Size = new System.Drawing.Size(370, 50);
			this.groupBoxDown.TabIndex = 0;
			this.groupBoxDown.TabStop = false;
			this.groupBoxDown.Text = "Selected loop";
			// 
			// panelPreAnswer
			// 
			this.panelPreAnswer.Controls.Add(this.linkUpdate);
			this.panelPreAnswer.Controls.Add(this.labelLength);
			this.panelPreAnswer.Controls.Add(this.panelPreAnswerGapRight);
			this.panelPreAnswer.Controls.Add(this.labelStatic);
			this.panelPreAnswer.Dock = System.Windows.Forms.DockStyle.Top;
			this.panelPreAnswer.Location = new System.Drawing.Point(3, 16);
			this.panelPreAnswer.Name = "panelPreAnswer";
			this.panelPreAnswer.Size = new System.Drawing.Size(364, 32);
			this.panelPreAnswer.TabIndex = 3;
			// 
			// labelStatic
			// 
			this.labelStatic.Dock = System.Windows.Forms.DockStyle.Left;
			this.labelStatic.Location = new System.Drawing.Point(0, 0);
			this.labelStatic.Name = "labelStatic";
			this.labelStatic.Size = new System.Drawing.Size(144, 32);
			this.labelStatic.TabIndex = 1;
			this.labelStatic.Text = "Selected loop length:         ";
			this.labelStatic.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
			// 
			// panelUpper
			// 
			this.panelUpper.Controls.Add(this.groupBoxPointSelection);
			this.panelUpper.Dock = System.Windows.Forms.DockStyle.Fill;
			this.panelUpper.DockPadding.All = 3;
			this.panelUpper.Location = new System.Drawing.Point(0, 0);
			this.panelUpper.Name = "panelUpper";
			this.panelUpper.Size = new System.Drawing.Size(376, 264);
			this.panelUpper.TabIndex = 3;
			// 
			// panelPreAnswerGapRight
			// 
			this.panelPreAnswerGapRight.Dock = System.Windows.Forms.DockStyle.Right;
			this.panelPreAnswerGapRight.Location = new System.Drawing.Point(340, 0);
			this.panelPreAnswerGapRight.Name = "panelPreAnswerGapRight";
			this.panelPreAnswerGapRight.Size = new System.Drawing.Size(24, 32);
			this.panelPreAnswerGapRight.TabIndex = 3;
			// 
			// labelLength
			// 
			this.labelLength.Dock = System.Windows.Forms.DockStyle.Left;
			this.labelLength.Location = new System.Drawing.Point(144, 0);
			this.labelLength.Name = "labelLength";
			this.labelLength.Size = new System.Drawing.Size(80, 32);
			this.labelLength.TabIndex = 4;
			this.labelLength.Text = "label1";
			this.labelLength.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			// 
			// linkUpdate
			// 
			this.linkUpdate.Dock = System.Windows.Forms.DockStyle.Right;
			this.linkUpdate.Location = new System.Drawing.Point(240, 0);
			this.linkUpdate.Name = "linkUpdate";
			this.linkUpdate.Size = new System.Drawing.Size(100, 32);
			this.linkUpdate.TabIndex = 5;
			this.linkUpdate.TabStop = true;
			this.linkUpdate.Text = "Update";
			this.linkUpdate.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			this.linkUpdate.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.linkUpdate_LinkClicked);
			// 
			// HomotopParameters
			// 
			this.Controls.Add(this.panelUpper);
			this.Controls.Add(this.panelDown);
			this.Name = "HomotopParameters";
			this.Size = new System.Drawing.Size(376, 320);
			this.groupBoxPointSelection.ResumeLayout(false);
			this.panelDown.ResumeLayout(false);
			this.groupBoxDown.ResumeLayout(false);
			this.panelPreAnswer.ResumeLayout(false);
			this.panelUpper.ResumeLayout(false);
			this.ResumeLayout(false);

		}
		#endregion

		private void minimalLoop_DataChanged()
		{
			hasCorrectData = false;
		}
		
		private void updateLink()
		{
			if (!hasCorrectData)
			{
				linkUpdate.ForeColor = Color.Red;
				linkUpdate.Font = new Font(linkUpdate.Font, FontStyle.Bold);
				labelLength.Text = "Unknown";
			} else
			{
				linkUpdate.ForeColor = Color.Black;
				linkUpdate.Font = new Font(linkUpdate.Font, FontStyle.Regular);
			}
		}

		private void linkUpdate_LinkClicked(object sender, System.Windows.Forms.LinkLabelLinkClickedEventArgs e)
		{
			PerformSearch();
		}

		private void PerformSearch()
		{
			System.Windows.Forms.Cursor cursor = this.Cursor;
			this.Cursor = Cursors.WaitCursor;
			try 
			{					
				MinimalLoopLocalizationAction action = Core.Instance.NextActionFactory.NextActionByName(node, typeof(IMinimalLoopLocalizationAction)) as MinimalLoopLocalizationAction;
	
				if (action == null) throw new ActionException("Unable to load IMinimalLoopLocalizationAction");
	
				try
				{
					minimalLoop.SubmitData();
				} 
				catch (ControlException ee)
				{
					MessageBox.Show(this, ee.ErrorDescription, "Error filling parameters", MessageBoxButtons.OK, MessageBoxIcon.Error );
					return;
				}

				action.FakeControl(minimalLoop);
	
				ResultSet set = action.Do(node.Results, progressBarInfo);
	
				if (set.Count == 1)
				{
					graphResult = set.ToResults[0] as IGraphResult;
					labelLength.Text = graphResult.GetGraphInfo().GetNodes().ToString();			
					hasCorrectData = true;
				} 
				else
				{
					labelLength.Text = "Not found";
				}
			} 
			finally 
			{	
				this.Cursor = cursor;
			}
		}

		private void progressBarInfo_Tick()
		{
			Application.DoEvents();
		}
	}
}
