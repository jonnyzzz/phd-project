using System;
using System.Collections;
using System.Windows.Forms;
using gui2.Forms;
using gui2.TreeNodes;
using guiActions.Actions;
using guiActions.Parameters;
using guiKernel2.Actions;

namespace gui2.ActionPerformer
{
	/// <summary>
	/// Summary description for ActionChain.
	/// </summary>
	public class ActionChainParameters
	{
		private readonly Action[] path;
		private readonly Node node;
		private bool wasSubmitted = false;

		public ActionChainParameters(Node node, Action[] path)
		{
			this.path = path;
			this.node = node;
		}

		protected ParametersControl[] GetControls()
		{
			ArrayList controls = new ArrayList();
			foreach (Action action in path)
			{
				controls.Add(action.GetParametesControl(node.KernelNode));
			}
			return (ParametersControl[])controls.ToArray(typeof(ParametersControl));
		}


		public DialogResult ShowParametersSelectionDialog(IWin32Window owner) 
		{
			ParametersSelector selector = new ParametersSelector(GetControls());
			DialogResult result = selector.ShowDialog(owner);
			if (result == DialogResult.OK) wasSubmitted = true;
			return result;
		}
	
		public ActionChain Chain
		{
			get
			{
				if (!wasSubmitted) throw new ActionException("Not all Parameters was submitted");
				ActionChain chain = new ActionChain();
				chain.AddActionRange(path);
				return chain;
			}
		}

	}
}
