using EugenePetrenko.Gui2.MorseKernel2;

namespace EugenePetrenko.Gui2.Actions.ActionImpl.HomotopAction
{
  /// <summary>
  /// Summary description for HomotopParametersImpl.
  /// </summary>
  public class HomotopParametersImpl : IIsolatedSetParameters
  {
    private IGraphResult result;
    private bool publishGraph;

    public HomotopParametersImpl(IGraphResult result, bool publishGraph)
    {
      this.result = result;
      this.publishGraph = publishGraph;
    }

    public bool PublishGraph
    {
      get { return publishGraph; }
    }

    public IGraphResult GetStartSet()
    {
      return result;
    }
  }
}