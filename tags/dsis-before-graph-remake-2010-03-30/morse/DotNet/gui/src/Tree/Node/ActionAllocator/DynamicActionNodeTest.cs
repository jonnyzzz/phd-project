using System;
using System.Collections;
using gui.Logger;
using gui.Tree.Node.Action;
using MorseKernelATL;

namespace gui.Tree.Node.ActionAllocator
{
	/// <summary>
	/// Summary description for DynamicTest.
	/// </summary>
	public class DynamicActionNodeTest
	{
		protected DynamicActionNodeTest()
		{
		}

		private static DynamicActionNodeTest instance = null;

		public static DynamicActionNodeTest Instance
		{
			get
			{
				if (instance == null) instance = new DynamicActionNodeTest();
				return instance;
			}
		}


		private ActionFactoryList actionFactoryes = new ActionFactoryList();

		public void registerActionFactory(IActionFactory factory)
		{
			actionFactoryes.AddActionList(factory);
		}

		public void unregisterActionFactory(IActionFactory factory)
		{
			actionFactoryes.RemoveAction(factory);
		}

		public void UnRegisterAll()
		{
			Instance.actionFactoryes.RemoveAll();
		}

		public ComputationNodeAction[] CreateAction(ComputationNode node)
		{
			ArrayList al = new ArrayList();
			foreach (IActionFactory actionFactory in actionFactoryes)
			{
				if (actionFactory.Corresponds(node))
				{
					al.Add(actionFactory.CreateAction(node));
				}
			}

			Log.LogMessage(this, "Dynamicly allocated {0} actions", al.Count);

			al.AddRange(ComputationNodeDynamicTest.parseNode(node.Node).actions);

			al.Sort(new ActionFactoryComparer());

			return (ComputationNodeAction[])al.ToArray(typeof(ComputationNodeAction));
		}

		private class ActionFactoryComparer : IComparer
		{
			public int Compare(object x, object y)
			{
				ComputationNodeAction a1 = x as ComputationNodeAction;
				ComputationNodeAction a2 = y as ComputationNodeAction;

				if (a1 == null || a2 == null) return 0;

				return a1.ToString().CompareTo(a2.ToString());
			}
		}
		
	}
}