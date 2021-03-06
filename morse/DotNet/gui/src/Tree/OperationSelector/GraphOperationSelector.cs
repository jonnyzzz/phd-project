using System;
using System.ComponentModel;
using System.Windows.Forms;
using gui.Logger;
using gui.Tree.Node.ActionAllocator;
using MorseKernelATL;

namespace gui.Tree.Node.Forms
{
	/// <summary>
	/// Summary description for GraphOperationSelector.
	/// </summary>
	public class GraphOperationSelector : Form
	{
		private ListBox actionListBox;
		private Button buttonCancel;
		private Button buttonOK;
		private GroupBox groupBox1;

		/// <summary>
		/// Required designer variable.
		/// </summary>
		private Container components = null;

		public GraphOperationSelector()
		{
			Console.Out.WriteLine("GraphOperationSelector: Creation");
			//
			// Required for Windows Form Designer support
			//
			InitializeComponent();

			//
			// TODO: Add any constructor code after InitializeComponent call
			//
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
			System.Resources.ResourceManager resources = new System.Resources.ResourceManager(typeof (GraphOperationSelector));
			this.actionListBox = new System.Windows.Forms.ListBox();
			this.buttonCancel = new System.Windows.Forms.Button();
			this.buttonOK = new System.Windows.Forms.Button();
			this.groupBox1 = new System.Windows.Forms.GroupBox();
			this.groupBox1.SuspendLayout();
			this.SuspendLayout();
			// 
			// actionListBox
			// 
			this.actionListBox.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.actionListBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F);
			this.actionListBox.ItemHeight = 16;
			this.actionListBox.Location = new System.Drawing.Point(16, 24);
			this.actionListBox.Name = "actionListBox";
			this.actionListBox.Size = new System.Drawing.Size(320, 146);
			this.actionListBox.TabIndex = 0;
			// 
			// buttonCancel
			// 
			this.buttonCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
			this.buttonCancel.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			this.buttonCancel.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F);
			this.buttonCancel.ImeMode = System.Windows.Forms.ImeMode.NoControl;
			this.buttonCancel.Location = new System.Drawing.Point(184, 200);
			this.buttonCancel.Name = "buttonCancel";
			this.buttonCancel.Size = new System.Drawing.Size(176, 24);
			this.buttonCancel.TabIndex = 1;
			this.buttonCancel.Text = "Cancel";
			this.buttonCancel.Click += new System.EventHandler(this.buttonCancel_Click);
			// 
			// buttonOK
			// 
			this.buttonOK.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			this.buttonOK.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F);
			this.buttonOK.ImeMode = System.Windows.Forms.ImeMode.NoControl;
			this.buttonOK.Location = new System.Drawing.Point(8, 200);
			this.buttonOK.Name = "buttonOK";
			this.buttonOK.Size = new System.Drawing.Size(176, 24);
			this.buttonOK.TabIndex = 2;
			this.buttonOK.Text = "OK";
			this.buttonOK.Click += new System.EventHandler(this.buttonOK_Click);
			// 
			// groupBox1
			// 
			this.groupBox1.Controls.Add(this.actionListBox);
			this.groupBox1.Location = new System.Drawing.Point(8, 8);
			this.groupBox1.Name = "groupBox1";
			this.groupBox1.Size = new System.Drawing.Size(352, 184);
			this.groupBox1.TabIndex = 3;
			this.groupBox1.TabStop = false;
			this.groupBox1.Text = "Select method for graph processing";
			// 
			// GraphOperationSelector
			// 
			this.AcceptButton = this.buttonOK;
			this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
			this.CancelButton = this.buttonCancel;
			this.ClientSize = new System.Drawing.Size(366, 228);
			this.Controls.Add(this.groupBox1);
			this.Controls.Add(this.buttonOK);
			this.Controls.Add(this.buttonCancel);
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
			this.Icon = ((System.Drawing.Icon) (resources.GetObject("$this.Icon")));
			this.MaximizeBox = false;
			this.Name = "GraphOperationSelector";
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
			this.Text = "GraphOperationSelector";
			this.groupBox1.ResumeLayout(false);
			this.ResumeLayout(false);

		}

		#endregion

		private delegate void Do();

		private IComputationResult computationResult = null;

		public DialogResult ShowModal(IWin32Window owner, ComputationNode node, IComputationResult result)
		{
			Log.LogMessage(this, "Select continue for {0}", result.GetType().Name);
			actionListBox.Items.Clear();
			actionListBox.Items.AddRange(DynamicResultTest.Instance.AllocateResutAction(result));

			return this.ShowDialog(owner);
		}

		private void doFixedPointSet()
		{
			(computationResult as IComputationGraphResult).Loops();
		}

		private void buttonCancel_Click(object sender, EventArgs e)
		{
			DialogResult = DialogResult.Cancel;
		}

		private void buttonOK_Click(object sender, EventArgs e)
		{
			if (actionListBox.SelectedItem == null)
			{
				MessageBox.Show("Please select action to continue or cancel");
			}
			else
			{
				DialogResult = DialogResult.OK;
			}
		}

		public void DoSelected()
		{
			ResultAction node = (actionListBox.SelectedItem as ResultAction);
			if (node != null)
			{
				node.DoAction();
			}
		}
	}
}