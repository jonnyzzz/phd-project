using EugenePetrenko.Gui2.Actions.Parameters;
using EugenePetrenko.Gui2.Kernell2.Container;
using EugenePetrenko.Gui2.MorseKernel2;

namespace EugenePetrenko.Gui2.Actions.ActionImpl.SIRom
{
  /// <summary>
  /// Summary description for SIRomActionParameters.
  /// </summary>
  public class SIRomActionParameters : ParametersControl
  {
    public SIRomActionParameters()
    {
    }

    protected override IParameters SubmitDataInternal()
    {
      return new SIRomActionParametersImpl(Core.Instance.KernelDocument.Function);
    }

    public override string BoxCaption
    {
      get { return "SIRom parameters"; }
    }

    public override bool NeedShowForm
    {
      get { return false; }
    }
  }
}