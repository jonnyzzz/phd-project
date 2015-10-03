using System.Collections;
using System.Text;
using System.Windows.Forms;
using EugenePetrenko.Gui2.Actions.Actions;
using EugenePetrenko.Gui2.Actions.Parameters;
using EugenePetrenko.Gui2.Application.Forms;
using EugenePetrenko.Gui2.Application.TreeNodes;
using EugenePetrenko.Gui2.Kernell2.Actions;

namespace EugenePetrenko.Gui2.Application.ActionPerformer
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
      return (ParametersControl[]) controls.ToArray(typeof (ParametersControl));
    }


    public DialogResult ShowParametersSelectionDialog(IWin32Window owner)
    {
      ParametersSelector selector = new ParametersSelector(GetControls());
      DialogResult result = selector.ShowDialogOptimized(owner);
      if (result == DialogResult.OK)
        wasSubmitted = true;
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

    public string GetActionCaption()
    {
      StringBuilder sb = new StringBuilder();
      foreach (Action action in path)
      {
        sb.Append(action.ActionName);
        sb.Append(" ");
      }
      return sb.ToString();
    }
  }
}