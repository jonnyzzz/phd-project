using guiActions.Parameters;
using guiControls.Grid;
using guiControls.Grid.Rows;
using MorseKernel2;

namespace guiActions.actionImpl.MinimalLoopLocalization
{
	/// <summary>
	/// Summary description for MinimalLoopLocalizationParameters.
	/// </summary>
	public class MinimalLoopLocalizationParameters : ParametersControl
	{
		private guiControls.Grid.ExGrid exGrid;
		private System.ComponentModel.Container components = null;

		private DoubleCoordinatesRow dataRow;

		public event ContentChanged DataChanged
		{
			add
			{
				exGrid.DataChanged += value;
			}
			remove
			{
				exGrid.DataChanged -= value;
			}
		}


		public MinimalLoopLocalizationParameters() : base()
		{
			InitializeComponent();
		}

		public MinimalLoopLocalizationParameters(int dimension) : this()
		{
			Initialize(dimension);
		}


		public void Initialize(int dimension)
		{
			dataRow = new DoubleCoordinatesRow("Point", dimension);

			exGrid.SetRows(dimension, dataRow);			
		}


		protected override IParameters SubmitDataInternal()
		{
			exGrid.SubmitData();
			return new MinimalLoopLocalizationParametersImpl(dataRow.Data);
		}

		public override string BoxCaption
		{
			get { return "Select point coordinate to find minimal loop"; }
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
			this.exGrid = new guiControls.Grid.ExGrid();
			this.SuspendLayout();
			// 
			// exGrid1
			// 
			this.exGrid.Dock = System.Windows.Forms.DockStyle.Fill;
			this.exGrid.Location = new System.Drawing.Point(0, 0);
			this.exGrid.Name = "exGrid";
			this.exGrid.Size = new System.Drawing.Size(288, 208);
			this.exGrid.TabIndex = 0;
			// 
			// MinimalLoopLocalizationParameters
			// 
			this.Controls.Add(this.exGrid);
			this.Name = "MinimalLoopLocalizationParameters";
			this.Size = new System.Drawing.Size(288, 208);
			this.ResumeLayout(false);

		}
		#endregion
	}
}
