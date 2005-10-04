using System;
using System.Threading;
using gui2.TreeNodes;
using guiKernel2.Actions;
using guiKernel2.Node;

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

			if (NewNode != null && chain.PublishResults)
			{
				KernelNode[] nodes = resultSet.ToNodes;
				foreach (KernelNode kernelNode in nodes)
				{
					NewNode(new Node(kernelNode, Runner.Runner.Instance.Document.KernelDocument.Function.Iterations));					
				}					
			}
			inProcess = false;
			Logger.Logger.LogMessage("Computation Finished");
		}

		public bool InProcess
		{
			get { return inProcess; }
		}
	}
}
