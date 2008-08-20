using EugenePetrenko.Gui2.Logging;
using EugenePetrenko.Gui2.MorseKernel2;

namespace EugenePetrenko.Gui2.Actions.ActionImpl.Tarjan
{
  /// <summary>
  /// Summary description for TarjanParametersImpl.
  /// </summary>
  public class TarjanParametersImpl : ITarjanParameters
  {
    private bool needResolve;

    public TarjanParametersImpl(bool needResolve)
    {
      Logger.LogMessage("Tarjan Parameters [NeedResolve = {0} ]", needResolve);
      this.needResolve = needResolve;
    }

    public bool NeedEdgeResolve()
    {
      Logger.LogMessage("Tarjan Parameters Call [NeedResolve = {0} ]", needResolve);
      return needResolve;
    }
  }
}