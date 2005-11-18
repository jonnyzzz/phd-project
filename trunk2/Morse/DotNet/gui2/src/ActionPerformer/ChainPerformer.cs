using System;
using System.Windows.Forms;
using EugenePetrenko.Gui2.Actions.Actions;
using EugenePetrenko.Gui2.Application.TreeNodes;
using EugenePetrenko.Gui2.Kernell2.Actions;
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

        public ChainPerformer(Node node, Action[] path, ProgressBarInfo info)
        {
            this.resultSet = node.ResultSet;
            this.info = info;
            this.node = node;
            parameters = new ActionChainParameters(node, path);
        }

        public bool DoActionsWithDialog(IWin32Window owner)
        {
            try
            {
                if (Start != null) Start();

                if (parameters.ShowParametersSelectionDialog(owner) != DialogResult.OK)
                    return false;

                Performer performer = new Performer(resultSet, parameters.Chain, info);

                performer.NewNode += new NewNodeEvent(NewNode);

                performer.Do();

                return true;
            }
            catch (Exception e)
            {
                MessageBox.Show(owner, "Action performings failed with error " + e.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                Logger.LogException(e);
                return false;
            }
            finally
            {
                if (Finish != null) Finish();
            }
        }

        public event ChainStart Start;
        public event ChainFinish Finish;

        private void NewNode(Node node)
        {
            this.node.AddNodeChild(node);
        }
    }
}