using System;
using System.Windows.Forms;

namespace gui
{
	/// <summary>
	/// Summary description for ComputationNodeVisualizer.
	/// </summary>
	public class ComputationNodeVisualizer2D : ComputationNodeAction
	{
		IntPtr graph;
		public ComputationNodeVisualizer2D(IntPtr graph) : base()
		{
			this.graph = graph;
			menus = new ComputationNodeMenuItem[] {
			ComputationNodeMenuFactory.VisualizeAction(new ComputationNodeMenuFactory.Visualize(visualize))};
		}

		public override ComputationNodeMenuItem[] getMenuItems()
		{
			return menus;
		}

		ComputationNodeMenuItem[] menus; 

		public void visualize()
		{
			Visualization2D vis = new Visualization2D();
			vis.ShowMe(graph);
			
		}
	}

	public class ComputationNodeVisualizer3D : ComputationNodeAction
	{
		IntPtr graph;
		public ComputationNodeVisualizer3D(IntPtr graph) : base()
		{
			this.graph = graph;
			menus = new ComputationNodeMenuItem[] {
			ComputationNodeMenuFactory.VisualizeAction(new ComputationNodeMenuFactory.Visualize(visualize))};
		}

		public override ComputationNodeMenuItem[] getMenuItems()
		{
			return menus;
		}

		ComputationNodeMenuItem[] menus; 

		public void visualize()
		{
			Visualization3D vis = new Visualization3D();
			vis.ShowMe(graph);
			
		}
	}


}
