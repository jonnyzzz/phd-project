using System;
using System.Threading;
using gui2.TreeNodes;
using guiKernel2.Actions;
using guiKernel2.Node;
using guiKernel2.src.Actions;
using guiKernel2.src.Node;

namespace gui2.ActionPerformer
{
	/// <summary>
	/// Summary description for Performer.
	/// </summary>
	/// 

	public delegate void NewNodeEvent(Node node);

	public class Performer {
		private readonly ActionChain chain;
		private readonly ProgressBarInfo progressBarInfo;
		private readonly ResultSet result;

		public event NewNodeEvent NewNode;

		private volatile bool inProcess = false;

		public Performer(ResultSet result, ActionChain chain, ProgressBarInfo progressBarInfo)
		{
			this.chain = chain;
			this.progressBarInfo = progressBarInfo;
			this.result = result;
		}

		public void Do()
		{
			inProcess = true;
			Logger.Logger.LogMessage("Computation Started");
			ResultSet resultSet = chain.Do(result, progressBarInfo);
			Logger.Logger.LogMessage("Comutation result set = {0}", resultSet.ToString());

			if (NewNode != null)
			{
				KernelNode[] nodes = resultSet.ToNodes;
				foreach (KernelNode kernelNode in nodes)
				{
					NewNode(new Node(kernelNode));
				}					
			}
			inProcess = false;
			Logger.Logger.LogMessage("Computation Finished");
		}

		public bool InProcess
		{
			get { return inProcess; }
		}

		private void ThreadedDo()
		{
			Thread thread = new Thread(new ThreadStart(Do));
			thread.Name = "ActionChainPerformer";
			thread.Priority = ThreadPriority.BelowNormal;
			thread.Start();
		}
	}
}
