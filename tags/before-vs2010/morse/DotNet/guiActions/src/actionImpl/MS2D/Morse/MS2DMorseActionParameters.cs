using EugenePetrenko.Gui2.Actions.Parameters;
using EugenePetrenko.Gui2.Kernell2.Document;
using EugenePetrenko.Gui2.MorseKernel2;

namespace EugenePetrenko.Gui2.Actions.ActionImpl.MS2D.Morse
{
  /// <summary>
  /// Summary description for MS2DMorseActionParameters.
  /// </summary>
  public class MS2DMorseActionParameters : ParametersControl
  {
    private Function function;

    public MS2DMorseActionParameters(Function function)
    {
      this.function = function;
    }

    protected override IParameters SubmitDataInternal()
    {
      return new ComputationParametersImpl(function);
    }

    public override string BoxCaption
    {
      get { return "Morse Spectrum estimation"; }
    }

    public override bool NeedShowForm
    {
      get { return false; }
    }
  }
}