using System.Windows.Forms;
using System.Xml;

namespace EugenePetrenko.Gui2.Visualization.ActionImpl.GnuPlot2
{
	/// <summary>
	/// Summary description for ShowStyleControl.
	/// </summary>
	public class ShowStyleControl : UserControl
	{
		private System.Windows.Forms.ComboBox comboBox;
		/// <summary> 
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.Container components = null;

		public ShowStyleControl()
		{
			InitializeComponent();
		}

		public string SelectedValue
		{
			get{ return ((Item)comboBox.SelectedItem).Value; }
		}

		public void SetControlData(XmlNode node)
		{
			comboBox.BeginUpdate();

			comboBox.Items.Clear();
			Item selected = null;
			foreach (XmlElement element in node.SelectNodes("showStyles/style"))
			{
				string caption = element.InnerText;
				string value = element.Attributes["value"].Value;
				XmlAttribute defaultAttribute = element.Attributes["default"];
				bool isDefault = defaultAttribute != null && defaultAttribute.Value == "true";

				Item item = new Item(caption, value);
				if (isDefault)
					selected = item;
				
				comboBox.Items.Add(item);
			}
			comboBox.SelectedItem = selected;
			comboBox.EndUpdate();
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
			this.comboBox = new System.Windows.Forms.ComboBox();
			this.SuspendLayout();
			// 
			// comboBox
			// 
			this.comboBox.Dock = System.Windows.Forms.DockStyle.Fill;
			this.comboBox.Location = new System.Drawing.Point(0, 0);
			this.comboBox.Name = "comboBox";
			this.comboBox.Size = new System.Drawing.Size(288, 21);
			this.comboBox.TabIndex = 0;
			this.comboBox.Text = "comboBox";
			// 
			// ShowStyleControl
			// 
			this.Controls.Add(this.comboBox);
			this.Name = "ShowStyleControl";
			this.Size = new System.Drawing.Size(288, 48);
			this.ResumeLayout(false);

		}
		#endregion

		private class Item
		{
			private string caption;
			private string value;

			public Item(string caption, string value)
			{
				this.caption = caption;
				this.value = value;
			}

			public string Value
			{
				get { return this.value; }
			}

			public override string ToString()
			{
				return caption;
			}
		}
	}
}
