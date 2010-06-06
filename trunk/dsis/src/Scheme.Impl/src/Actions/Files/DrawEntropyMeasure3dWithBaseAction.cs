using DSIS.GnuplotDrawer;
using DSIS.Graph.Entropy.Impl.Entropy;
using DSIS.Utils;
using EugenePetrenko.Shared.Core.Ioc.Api;

namespace DSIS.Scheme.Impl.Actions.Files
{
  [ComponentImplementation]
  public class DrawEntropyMeasure3dWithBaseAction : DrawEntropyMeasureActionBase
  {
    protected override GnuplotScriptParameters CreateProperties<Q>(IGraphMeasure<Q> measure, string outputFile)
    {
      return new GnuplotScriptParameters3d(outputFile, string.Format("Entropy = {0}", measure.GetEntropy().ToString("F6")))
      {
        ForcePoints = true,
        RotX = 75,
        RotZ = 30,
        XYPane = 0
      };
    }

    public override int SystemDimension
    {
      get { return 2; }
    }
    
    protected override IGnuplotMeasureDensityScriptGen2 CreateScriptGen(ITempFileFactory factory, GnuplotScriptParameters ps)
    {
      return new GnuplotEntropy3dWithBaseScriptGen(factory, ps);
    }
  }
}