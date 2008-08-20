using System;
using EugenePetrenko.Gui2.Actions.Actions;
using EugenePetrenko.Gui2.Actions.Parameters;
using EugenePetrenko.Gui2.Kernell2.ActionFactory;
using EugenePetrenko.Gui2.Kernell2.ActionFactory.ActionImpl;
using EugenePetrenko.Gui2.Kernell2.Node;
using EugenePetrenko.Gui2.MorseKernel2;

namespace EugenePetrenko.Gui2.Actions.ActionImpl
{
  [ActionMapping(typeof (IDisabledActionInterface), typeof (IParameters))]
  public class DisabledAction : Action, IDisabledAction, IDisabledActionInterface
  {
    public string comment;

    public DisabledAction(string caption, bool isChainLeaf) : base(caption, isChainLeaf)
    {
    }

    public void SetComment(string comment)
    {
      this.comment = comment;
    }

    public string Comment
    {
      get { return comment; }
    }

    public string Caption
    {
      get { return base.ActionName; }
    }

    public void SetActionParameters(IParameters parameters)
    {
    }

    public void SetProgressBarInfo(IProgressBarInfo pinfo)
    {
    }

    public bool CanDo(IResultSet result)
    {
      return false;
    }

    public IResultSet Do(IResultSet input)
    {
      throw new ArgumentException("Unable to perform action for Disabled Elemet");
    }

    protected override ParametersControl GetParametersControlInternal(KernelNode node)
    {
      throw new ArgumentException("Unable to perform action for Disabled Elemet");
    }

    protected override IAction CreateAction()
    {
      return this;
    }
  }
}