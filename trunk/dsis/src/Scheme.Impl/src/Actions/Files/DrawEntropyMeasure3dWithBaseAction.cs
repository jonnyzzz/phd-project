using DSIS.Core.Ioc;
using DSIS.GnuplotDrawer;
using DSIS.Graph.Entropy.Impl.Entropy;
using DSIS.Utils;

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
    
    protected override IGnuplotEntropyScriptGen CreateScriptGen(ITempFileFactory factory, GnuplotScriptParameters ps)
    {
      return new GnuplotEntropy3dWithBaseScriptGen(factory, ps);
    }
  }
}