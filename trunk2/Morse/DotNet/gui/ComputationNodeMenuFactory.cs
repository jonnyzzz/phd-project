using System;
using System.Resources;
using System.Windows.Forms;
using MorseKernelATL;

namespace gui
{
	/// <summary>
	/// Summary description for ComputationNodeMenuFactory.
	/// </summary>
	public class ComputationNodeMenuFactory
	{
		#region class EmptyMenuItem {...} + static getter 
		protected class EmptyMenuItem : ComputationNodeMenuItem
		{
            public EmptyMenuItem() : base()
            {
            	Text = "No actions";
				this.Enabled = false;				
            }
		}
		public static ComputationNodeMenuItem Empty()
		{
			return new EmptyMenuItem();
		}
		#endregion

		#region class DelelectNodeMenuItem {...} + static getter
		protected class DeselectNodeMenuItem : ComputationNodeMenuItem
		{
			private TreeView treeView;
			public DeselectNodeMenuItem(TreeView treeView) : base()
			{
				this.treeView = treeView;
				this.Text = "Deselect";

				this.Click += new EventHandler(DeselectAction_Click);
			}

			private void DeselectAction_Click(object sender, EventArgs e)
			{
				//Selectend, but not checked!
				treeView.SelectedNode = null;				
			}
		}
		public static ComputationNodeMenuItem DeselectItem(TreeView treeView)
		{
			return new DeselectNodeMenuItem(treeView);
		}
		#endregion

		#region class Delimiter {...} + static getter
		protected class DelimiterComputationMenuItem : ComputationNodeMenuItem
		{
			public DelimiterComputationMenuItem() : base() 
			{				
				this.Text = "-";
			}			
		}

		public static ComputationNodeMenuItem DelimeterItem()
		{
			return new DelimiterComputationMenuItem();
		}
		#endregion

		#region class SubdevideActionMenuItem {...} + static getter
		public delegate void Subdevide();
		protected class SubdevideActionMenuItem : ComputationNodeMenuItem
		{				
			private Subdevide subdevide;
			public SubdevideActionMenuItem(Subdevide subdevide) : base()
			{
				this.subdevide = subdevide;
				this.Text = "Subdevide";
				this.Click += new EventHandler(SubdevideActionMenuItem_Click);
			}

			private void SubdevideActionMenuItem_Click(object sender, EventArgs e)
			{
				subdevide();
			}
		}

		public static ComputationNodeMenuItem SubdevideAction(Subdevide subdevide)
		{
			return new SubdevideActionMenuItem(subdevide);
		}
		#endregion

		#region class SubdevidePointActionMenuItem {...} + static getter
		public delegate void SubdevidePoint();
		protected class SubdevidePointActionMenuItem : ComputationNodeMenuItem
		{				
			private SubdevidePoint subdevide;
			public SubdevidePointActionMenuItem(SubdevidePoint subdevide) : base()
			{
				this.subdevide = subdevide;
				this.Text = "Subdevide Point Method";
				this.Click += new EventHandler(SubdevideActionMenuItem_Click);
			}

			private void SubdevideActionMenuItem_Click(object sender, EventArgs e)
			{
				subdevide();
			}
		}

		public static ComputationNodeMenuItem SubdevidePointAction(SubdevidePoint subdevide)
		{
			return new SubdevidePointActionMenuItem(subdevide);
		}
		#endregion


		#region class ExtendActionMenuItem {...} + static getter
		public delegate void Extend();
		protected class ExtendActionMenuItem : ComputationNodeMenuItem
		{				
			private Extend subdevide;
			public ExtendActionMenuItem(Extend subdevide) : base()
			{
				this.subdevide = subdevide;
				this.Text = "Extend Symbolic Image to Projective Bundle";
				this.Click += new EventHandler(SubdevideActionMenuItem_Click);
			}

			private void SubdevideActionMenuItem_Click(object sender, EventArgs e)
			{
				subdevide();
			}
		}

		public static ComputationNodeMenuItem ExtendAction(Extend subdevide)
		{
			return new ExtendActionMenuItem(subdevide);
		}
		#endregion


		#region Visualize! + static getter
		public delegate void Visualize();
		protected class VisualizeMenuItem : ComputationNodeMenuItem
		{
			private Visualize visualize;
			public VisualizeMenuItem(Visualize visualize) : base()
			{
				this.visualize = visualize;
				this.Text = "Visualize";
				this.Click += new EventHandler(VisualizeMenuItem_Click);
			}

			private void VisualizeMenuItem_Click(object sender, EventArgs e)
			{
				visualize();
			}
		}

		public static ComputationNodeMenuItem VisualizeAction(Visualize visualization)
		{
			return new VisualizeMenuItem(visualization);
		}

		#endregion


		#region toMorse! + static getter
		public delegate void Morse();
		protected class MorseMenuItem : ComputationNodeMenuItem
		{
			private Morse morse;
			public MorseMenuItem(Morse morse) : base()
			{
				this.morse = morse;
				this.Text = "Estimate Morse";
				this.Click += new EventHandler(MorseMenuItem_Click);
			}

			private void MorseMenuItem_Click(object sender, EventArgs e)
			{
				morse();
			}
		}

		public static ComputationNodeMenuItem MorseAction(Morse morse)
		{
			return new MorseMenuItem(morse);
		}

		#endregion


		#region rename menu item
		protected class MenuAdapter : ComputationNodeMenuItem
		{
			private ComputationNodeMenuItem item;
			public MenuAdapter(ComputationNodeMenuItem item, string caption)
			{
				this.Text = caption;
				this.item = item;
				this.Click +=new EventHandler(MenuAdapter_Click);
			}

			private void MenuAdapter_Click(object sender, EventArgs e)
			{
				item.PerformClick();				
			}
		}

		public static ComputationNodeMenuItem getMenuRenameAdapter(ComputationNodeMenuItem item, string name)
		{
			return new MenuAdapter(item, name);
		}
		#endregion


		#region ShowChildrens
		public delegate void DoMenuShowChildrens();
		protected class MenuShowChildrens : ComputationNodeMenuItem
		{
			private DoMenuShowChildrens deleg;
			public MenuShowChildrens(DoMenuShowChildrens deleg)
			{
				this.Text = "Show childrens";
				this.deleg = deleg;
				this.Click +=new EventHandler(MenuAdapter_Click);
			}

			private void MenuAdapter_Click(object sender, EventArgs e)
			{
				deleg();				
			}
		}

		public static ComputationNodeMenuItem getMenuShowChildrens(DoMenuShowChildrens deleg)
		{
			return new MenuShowChildrens(deleg);
		}
		#endregion


		#region doCreateGroup
		public delegate void DoCreateGroupNode();
		private class MenuCreateGroupNode : ComputationNodeMenuItem {
			private DoCreateGroupNode callBack;
			public MenuCreateGroupNode(DoCreateGroupNode callBack)
			{
				this.callBack = callBack;
				this.Text = "Create a group";
				this.Click +=new EventHandler(MenuCreateGroupNode_Click);
			}

			private void MenuCreateGroupNode_Click(object sender, EventArgs e)
			{
				callBack();
			}
		}

		public static ComputationNodeMenuItem getMenuCreateGroupNode(DoCreateGroupNode callBack)
		{
			return new MenuCreateGroupNode(callBack);
		}
		#endregion

		#region ExportData
		public delegate void ExportData();
		private class MenuExportData : ComputationNodeMenuItem
		{
			private ExportData exportData;
			public MenuExportData(ExportData exportData)
			{
				this.exportData = exportData;
				this.Text = "Export to File";
				this.Click +=new EventHandler(MenuExportData_Click);
			}

			private void MenuExportData_Click(object sender, EventArgs e)
			{
				exportData();
			}
		}
		public static ComputationNodeMenuItem getMenuExportData(ExportData exportData)
		{
			return new MenuExportData(exportData);
		}
		#endregion


		protected ComputationNodeMenuFactory()
		{
		}



	}
}
