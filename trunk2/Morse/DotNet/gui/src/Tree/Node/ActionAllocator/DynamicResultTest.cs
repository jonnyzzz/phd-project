using System;
using System.Collections;
using gui.Logger;
using gui.Tree.Node.ActionAllocator;
using MorseKernelATL;

namespace gui.Tree.Node.ActionAllocator
{
	/// <summary>
	/// Summary description for DynamicComputationTest.
	/// </summary>
	public class DynamicResultTest
	{
		private DynamicResultTest()
		{
		}

        private static DynamicResultTest instance = null;
        public static DynamicResultTest Instance
        {
            get 
            {
                if (instance == null) instance = new DynamicResultTest();
                return instance;
            }
        }

        private ArrayList actions = new ArrayList();

        public void RegisterAction(IResultActionFactory factory)
        {
            Log.LogMessage(this, "Registered IResultFactory : {0}", factory.GetType().Name);
            actions.Add(factory);
        }

        public void UnRegisterAction(IResultActionFactory factory)
        {
            actions.Remove(factory);
        }

        public void UnRegisterAll()
        {
            Instance.actions.Clear();
        }


        public ResultAction[] AllocateResutAction(IComputationResult result)
        {
            ArrayList results = new ArrayList();
            foreach (IResultActionFactory action in actions)
            {
                if (action.Corresponds(result))
                {
                    results.Add(action.CreateAction(result));
                }
            }
            return (ResultAction[])results.ToArray(typeof(ResultAction));
        }
	}
}
