using System;
using System.Windows.Forms;
using gui.Logger;
using gui.Tree.Node.Menu;

namespace gui.Tree.Node.Factory
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

		#region class SubdevidePointActionMenuItem {...} + static getter

		public static ComputationNodeMenuItem SubdevidePointAction(UniversalMenuItemClick universal)
		{
			return new UniversalComputationMenuItem(universal, "Subdivide using Point Method");
		}

		#endregion

		#region Visualize! + static getter

		public static ComputationNodeMenuItem VisualizeAction(UniversalMenuItemClick visualization)
		{
			return new UniversalComputationMenuItem(visualization, "Visualize");
		}

		#endregion

		#region toMorse! + static getter

		public static ComputationNodeMenuItem MorseAction(UniversalMenuItemClick morse)
		{
			return new UniversalComputationMenuItem(morse, "Estimate Morse Spectrum");
		}

		#endregion

		#region rename menu item

		public static ComputationNodeMenuItem getMenuRenameAdapter(ComputationNodeMenuItem item, string name)
		{
			return new UniversalComputationMenuItem(new UniversalMenuItemClick(item.PerformClick), name);
		}

		#endregion

		#region ShowChildrens

		public static ComputationNodeMenuItem getMenuShowChildrens(UniversalMenuItemClick deleg)
		{
			return new UniversalComputationMenuItem(deleg, "Show childrens");
		}

		#endregion

		#region doCreateGroup

		public static ComputationNodeMenuItem getMenuCreateGroupNode(UniversalMenuItemClick callBack)
		{
			return new UniversalComputationMenuItem(callBack, "Create a group");
		}

		#endregion

		#region ExportData

		public static ComputationNodeMenuItem getMenuExportData(UniversalMenuItemClick exportData)
		{
			return new UniversalComputationMenuItem(exportData, "Export to File");
		}

		#endregion

		#region universal...

		public delegate void UniversalMenuItemClick();

		public class UniversalComputationMenuItem : ComputationNodeMenuItem
		{
			private UniversalMenuItemClick universalMenuItem;

			public UniversalComputationMenuItem(UniversalMenuItemClick universalMenuItem, String caption)
			{
				this.universalMenuItem = universalMenuItem;
				this.Text = caption;
				this.Click += new EventHandler(UnirevsalComputationMenuItem_Click);
			}

			private void UnirevsalComputationMenuItem_Click(object sender, EventArgs e)
			{
				try 
				{
					ThreadedAction();
				} catch (Exception ee)
				{
					Log.LogException(this, ee, "Unable to perform such action in DLL");
					MessageBox.Show("Unable to perform Such action");
				}
			}

			private void ThreadedAction()
			{
				universalMenuItem();
			}
		}

		public static ComputationNodeMenuItem getUniversalMenuItem(UniversalMenuItemClick del, String caption)
		{
			return new UniversalComputationMenuItem(del, caption);
		}

		#endregion

		protected ComputationNodeMenuFactory()
		{
		}
	}
}