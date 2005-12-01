using EugenePetrenko.Gui2.Application.TreeNodes;
using EugenePetrenko.Gui2.Kernell2.Actions;
using EugenePetrenko.Gui2.Kernell2.Container;
using EugenePetrenko.Gui2.Kernell2.Node;
using EugenePetrenko.Gui2.Logging;

namespace EugenePetrenko.Gui2.Application.ActionPerformer
{
    /// <summary>
    /// Summary description for Performer.
    /// </summary>
    /// 
    public delegate void NewNodeEvent(Node node);

    public class Performer
    {
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
            Logger.LogMessage("Computation Started");
            ResultSet resultSet = chain.Do(result, progressBarInfo);
            Logger.LogMessage("Comutation result set = {0}", resultSet.ToString());

            if (NewNode != null && chain.PublishResults)
            {
                KernelNode[] nodes = resultSet.ToNodes;
                foreach (KernelNode kernelNode in nodes)
                {
                    NewNode(new Node(kernelNode, Runner.Runner.Instance.Document.KernelDocument.Function.Iterations));
                }
            }
            inProcess = false;
            Logger.LogMessage("Computation Finished");
        }

        public bool InProcess
        {
            get { return inProcess; }
        }
    }
}