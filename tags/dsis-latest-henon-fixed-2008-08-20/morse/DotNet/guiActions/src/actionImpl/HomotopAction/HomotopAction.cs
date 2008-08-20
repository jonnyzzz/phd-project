using EugenePetrenko.Gui2.Actions.Actions;
using EugenePetrenko.Gui2.Actions.Parameters;
using EugenePetrenko.Gui2.Kernell2.ActionFactory;
using EugenePetrenko.Gui2.Kernell2.Node;
using EugenePetrenko.Gui2.MorseKernel2;

namespace EugenePetrenko.Gui2.Actions.ActionImpl.HomotopAction
{
  /// <summary>
  /// Summary description for HomotopAction.
  /// </summary>
  /// 
  [ActionMapping(typeof (IIsolatedSetAction), typeof (IIsolatedSetParameters))]
  public class HomotopAction : Action
  {
    public HomotopAction(string caption, bool isChainLeaf) : base(caption, isChainLeaf)
    {
    }

    protected override IAction CreateAction()
    {
      return new CIsolatedSetActionClass();
    }

    protected override ParametersControl GetParametersControlInternal(KernelNode node)
    {
      return new HomotopParameters(node);
    }

    protected override ResultSet DoActionInteranl(ResultSet input)
    {
      HomotopParametersImpl param = (HomotopParametersImpl) Parameters;
      if (!param.PublishGraph)
      {
        return base.DoActionInteranl(input);
      }
      else
      {
        ResultSet resultSet = base.DoActionInteranl(input);
        return ResultSet.Merge(resultSet, param.GetStartSet());
      }
    }
  }
}