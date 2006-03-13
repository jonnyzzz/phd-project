using System;
using System.Threading;
using System.Windows.Forms;
using EugenePetrenko.Gui2.Actions.Actions;
using EugenePetrenko.Gui2.Application.TreeNodes;
using EugenePetrenko.Gui2.Kernell2.ActionFactory;
using EugenePetrenko.Gui2.Kernell2.Actions;
using EugenePetrenko.Gui2.Kernell2.Container;
using EugenePetrenko.Gui2.Kernell2.Node;
using EugenePetrenko.Gui2.Logging;
using ProgressBar = EugenePetrenko.Gui2.Kernell2.Actions.ProgressBarInfo;

namespace EugenePetrenko.Gui2.Application.ActionPerformer
{
    /// <summary>
    /// Summary description for ChainParformer.
    /// </summary>
    /// 
    public delegate void ChainStart();
    public delegate void ChainFinish();

    public class ChainPerformer
    {
        private readonly ResultSet resultSet;
        private readonly ProgressBarInfo info;
        private readonly Node node;
        private ActionChainParameters parameters;

		public event StateEvent Started;
		public event StateEvent Finished;

        public ChainPerformer(Node node, Action[] path, ProgressBarInfo info)
        {
            this.resultSet = node.ResultSet;
            this.info = info;
            this.node = node;
            parameters = new ActionChainParameters(node, path);
        }

        public void DoActionsWithDialog(IWin32Window owner)
        {
            if (parameters.ShowParametersSelectionDialog(owner) != DialogResult.OK)
                return;

            Performer performer = new Performer(resultSet, parameters.Chain, info);
            performer.NewNode += new NewNodesEvent(NewNode);
			performer.Exception += new StateException(OnExceptionOccours);
			performer.Started += Started;
			performer.Finished += Finished;

            Runner.Runner.Instance.RunThread(performer.ThreadedDo());
        }

        private void OnExceptionOccours(Exception e)
		{
			MessageBox.Show(Runner.Runner.Instance.ComputationForm, "Action performings failed with error " + e.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
			Logger.LogException(e);
		}

        private void NewNode(Node[] node)
        {
            this.node.AddResultChild(node, parameters.GetActionCaption());
        }
    }
}