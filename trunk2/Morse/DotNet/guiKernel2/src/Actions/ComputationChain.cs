using System;
using System.Collections;
using MorseKernel2;

namespace guiKernel2.src.Actions
{
	/// <summary>
	/// Summary description for ComputationChain.
	/// </summary>
	public class ComputationChain
	{
		private IProgressBar progressBar;
		ArrayList actions = new ArrayList();

		public ComputationChain(IProgressBar progressBar)
		{
			this.progressBar = progressBar;
		}

		public void AddAction(IAction action)
		{
			actions.Add(action);
		}

		public int Count
		{
			get
			{
				return actions.Count;
			}
		}

		public IResult Do(IResult result)
		{
			IResultBase tmp = result;
			foreach (IAction action in actions)
			{
				if (!action.CanDo(tmp)) throw new ActionException("Action Does Not supports such result");
				tmp = action.Do(result);
			}

			return (IResult)tmp;
		}
	}
}
