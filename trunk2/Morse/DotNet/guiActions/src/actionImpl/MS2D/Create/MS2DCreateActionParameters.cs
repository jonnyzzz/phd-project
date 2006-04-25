using EugenePetrenko.Gui2.MorseKernel2;

namespace EugenePetrenko.Gui2.Actions.ActionImpl.MS2D.Create
{
  /// <summary>
  /// Summary description for MS2DActionParameters.
  /// </summary>
  public class MS2DCreateActionParameters : ActionParameters
  {
    protected override IParameters LoadParameters(int[] factor)
    {
      return new MS2DCreateActionParametersImpl(factor);
    }
  }
}