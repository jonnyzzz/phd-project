using EugenePetrenko.Gui2.Actions.Actions;
using EugenePetrenko.Gui2.Actions.Parameters;
using EugenePetrenko.Gui2.Kernell2.ActionFactory;
using EugenePetrenko.Gui2.Kernell2.ActionFactory.ActionImpl;
using EugenePetrenko.Gui2.Kernell2.Node;
using EugenePetrenko.Gui2.MorseKernel2;

namespace EugenePetrenko.Gui2.Actions.ActionImpl
{
  /// <summary>
  /// Summary description for Group.
  /// </summary>
  /// 
  [ActionMapping(typeof (IGroupAction), typeof (IParameters))]
  public class Group : Action, IGroup, IGroupAction
  {
    public Group(string caption, bool isChainLeaf) : base(caption, isChainLeaf)
    {
    }

    public void SetActionParameters(IParameters parameters)
    {
    }

    public void SetProgressBarInfo(IProgressBarInfo pinfo)
    {
    }

    public bool CanDo(IResultSet result)
    {
      return true;
    }

    public IResultSet Do(IResultSet input)
    {
      return input;
    }

    protected override ParametersControl GetParametersControlInternal(KernelNode node)
    {
      return new GroupParametersControl();
    }

    protected override IAction CreateAction()
    {
      return this;
    }
  }

  public class GroupParametersControl : ParametersControl, IParameters
  {
    protected override IParameters SubmitDataInternal()
    {
      return this;
    }

    public override string BoxCaption
    {
      get { return "GroupParameters"; }
    }

    public override bool NeedShowForm
    {
      get { return false; }
    }
  }
}