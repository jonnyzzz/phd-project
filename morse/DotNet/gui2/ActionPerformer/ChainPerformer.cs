using System.Windows.Forms;
using gui2.TreeNodes;
using guiActions.Actions;
using guiKernel2.Actions;
using guiKernel2.Node;
using ProgressBar = guiKernel2.Actions.ProgressBarInfo;

namespace gui2.ActionPerformer
{
	/// <summary>
	/// Summary description for ChainParformer.
	/// </summary>
	/// 

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
			if (parameters.ShowParametersSelectionDialog(owner) != DialogResult.OK) return false;
			
			Performer performer = new Performer(resultSet, parameters.Chain, info );

			performer.NewNode += new NewNodeEvent(NewNode);

			performer.Do();

			return true;

		}

		private void NewNode(Node node)
		{
			this.node.AddChild(node);			
		}
	}
}
