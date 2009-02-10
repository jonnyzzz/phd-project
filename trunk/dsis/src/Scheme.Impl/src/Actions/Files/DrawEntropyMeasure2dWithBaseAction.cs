using DSIS.Core.Ioc;
using DSIS.GnuplotDrawer;
using DSIS.Graph.Entropy.Impl.Entropy;

namespace DSIS.Scheme.Impl.Actions.Files
{
  [ComponentImplementation]
  public class DrawEntropyMeasure2dWithBaseAction : DrawEntropyMeasureActionBase
  {
    public override int SystemDimension
    {
      get { return 1; }
    }

    protected override IGnuplotEntropyScriptGen CreateScriptGen(string file, GnuplotScriptParameters ps)
    {
      return new GnuplotEntropy2dWithBaseScriptGen(file, ps);
    }

    protected override GnuplotScriptParameters CreateProperties<Q>(IGraphMeasure<Q> measure, string outputFile)
    {
      return new GnuplotScriptParameters(outputFile, string.Format("Entropy = {0}", measure.GetEntropy().ToString("F6")))
      {
        ForcePoints = true,
      };
    }
  }
}