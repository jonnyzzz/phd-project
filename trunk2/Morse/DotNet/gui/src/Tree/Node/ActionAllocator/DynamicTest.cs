using System;
using System.Collections;
using gui.Logger;
using gui.Tree.Node;
using gui.Tree.Node.Action;
using MorseKernelATL;

namespace gui.src.Tree.Node.ActionAllocator
{
	/// <summary>
	/// Summary description for DynamicTest.
	/// </summary>
	public class DynamicTest
	{
		protected DynamicTest() {}
        private static DynamicTest instance = null;
        public static DynamicTest Instance
        {
            get
            {
                if (instance == null) instance = new DynamicTest();
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

        public ComputationNodeAction[] CreateAction(IKernelNode node)
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
            
            al.AddRange(ComputationNodeDynamicTest.parseNode(node).actions);

            ComputationNodeAction[] act = new ComputationNodeAction[al.Count];            
            for (int i=0; i<al.Count; act[i] = (ComputationNodeAction)al[i++]);

            return act;
        }
	}
}
