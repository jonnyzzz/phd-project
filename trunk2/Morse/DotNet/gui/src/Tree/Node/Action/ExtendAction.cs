using System;
using gui.Attributes;
using gui.src.Tree.Node.ActionAllocator;
using gui.Tree.Node.Action;
using gui.Tree.Node.Factory;
using gui.Tree.Node.Menu;
using MorseKernelATL;

namespace gui.src.Tree.Node.Action
{
	/// <summary>
	/// Summary description for Extend.
	/// </summary>
	[InitializeStaticAttrubute("Register")]
	public class ExtendAction : ComputationNodeAction
	{
        private IExtendable node;

		public ExtendAction(IExtendable node)
		{
			this.node = node;
		}

	    public override ComputationNodeMenuItem[] getMenuItems()
	    {
	        return new ComputationNodeMenuItem[] {
	            ComputationNodeMenuFactory.getUniversalMenuItem(
                      new ComputationNodeMenuFactory.UniversalMenuItem(Extend), 
                      "Extend")
	            };
	    }

        private void Extend()
        {
            node.Extend();
        }

        public static void Register()
        {
            DynamicActionNodeTest.Instance.registerActionFactory(new ExtendActionFactory());
        }


        private class ExtendActionFactory : IActionFactory
        {
            public bool Corresponds(IKernelNode node)
            {
                return node is IExtendable;
            }

            public ComputationNodeAction CreateAction(IKernelNode node)
            {
                return new ExtendAction((IExtendable)node);
            }
        }

	}
}
