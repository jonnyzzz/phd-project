using System;
using System.Collections;
using gui.Tree.Node;
using gui.Tree.Node.Action;
using gui.Tree.Node.Factory;
using gui.Tree.Node.Menu;
using MorseKernelATL;

namespace gui.Tree.Node
{
	/// <summary>
	/// Summary description for ComputationNodeDynamicTest.
	/// </summary>
	public class ComputationNodeDynamicTest
	{
		public class ComputationNodeDynamicTestResult 
		{
			public ComputationNodeMenuItem[] items;
			public ComputationNodeAction[] actions;

			public ComputationNodeDynamicTestResult(ComputationNodeAction[] actions, ComputationNodeMenuItem[] items)
			{
				this.items = items;
				this.actions = actions;
			}
		}

		public static ComputationNodeDynamicTestResult parseNode(IKernelNode mnode)
		{
			if (mnode is IGraph) // a base class for all graph-nodes
			{
				return parseNode(mnode as IGraph);
			}
			else return new ComputationNodeDynamicTestResult(new ComputationNodeAction[]{}, new ComputationNodeMenuItem[]{} );
		}

		public static ComputationNodeDynamicTestResult parseNode(IGraph mnode)
		{
			ArrayList arrayActions = new ArrayList();
			ArrayList arrayItems = new ArrayList();

		    ComputationNodeAction act = null;

			if (mnode is ISubdevidable)
			{
				act = new ComputationNodeSubdevidable(mnode as ISubdevidable);
				arrayActions.Add(act);
				arrayItems.AddRange(act.getMenuItems());				
			}

			if (mnode is ISubdevidablePoint)
			{
				act = new ComputationNodeSubdevidablePoint(mnode as ISubdevidablePoint);
				arrayActions.Add(act);
				arrayItems.AddRange(act.getMenuItems());								
			}

			if (act != null)
			{
				arrayItems.Add(ComputationNodeMenuFactory.DelimeterItem());
				act = null;
			}

            /*
			if (mnode is IExtendable)
			{
				act = new ComputationNodeExtendable(mnode as IExtendable);
				arrayActions.Add(act);
				arrayItems.AddRange(act.getMenuItems());								
			}
            */

			if (act != null)
			{
				arrayItems.Add(ComputationNodeMenuFactory.DelimeterItem());
				act = null;
			}

			if (mnode is IMorsable)
			{
				act = new ComputationNodeMorsable(mnode as IMorsable);
				arrayActions.Add(act);
				arrayItems.AddRange(act.getMenuItems());								
			}

			if (act != null)
			{
				arrayItems.Add(ComputationNodeMenuFactory.DelimeterItem());
				act = null;
			}

			if (false && mnode.graphDimension() == 2 && mnode is CSymbolicImageGraph)
			{
				CSymbolicImageGraph node = mnode as CSymbolicImageGraph;
				IntPtr graph;
				node.getGraph( out graph);				
				act = new ComputationNodeVisualizer2D(graph);
				
				arrayActions.Add(act);				
				arrayItems.AddRange(act.getMenuItems());								
			}

			if (false && mnode.graphDimension() == 3 && mnode is CSymbolicImageGraph)
			{
				CSymbolicImageGraph node = mnode  as CSymbolicImageGraph;
				IntPtr graph;
				node.getGraph(out graph);

				act = new ComputationNodeVisualizer3D(graph);

				arrayActions.Add(act);
				arrayItems.AddRange(act.getMenuItems());
			}

			if (act != null)
			{
				arrayItems.Add(ComputationNodeMenuFactory.DelimeterItem());
				act = null;
			}
	
			if (mnode is IExportData)
			{
				IExportData node = mnode as IExportData;
				act = new ComputationNodeExportable(node);
				arrayActions.Add(act);
				arrayItems.AddRange(act.getMenuItems());
			}


			ComputationNodeAction[] actions = new ComputationNodeAction[arrayActions.Count];						

			for (int i=0; i<arrayActions.Count; i++)
			{
				actions[i] = arrayActions[i] as ComputationNodeAction;				
			}

			ComputationNodeMenuItem[] items = new ComputationNodeMenuItem[arrayItems.Count];
			for (int i=0; i<arrayItems.Count; i++)
			{
				items[i] = arrayItems[i] as ComputationNodeMenuItem;
			}

			return new ComputationNodeDynamicTestResult(actions, items);
		}
	}
}
