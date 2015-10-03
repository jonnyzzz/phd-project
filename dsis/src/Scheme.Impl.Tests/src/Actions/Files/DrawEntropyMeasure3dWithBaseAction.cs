using System.Collections.Generic;
using DSIS.GnuplotDrawer;
using DSIS.Graph.Entropy.Impl.Entropy;
using DSIS.Scheme.Ctx;

namespace DSIS.Scheme.Impl.Actions.Files
{
  public class DrawEntropyMeasure3dWithBaseAction : DrawEntropyMeasureActionBase
  {
    protected override ICollection<ContextMissmatchCheck> Check<T, Q>(T system, Context ctx)
    {
      return ColBase(base.Check<T, Q>(system, ctx), Create(Keys.GraphComponents<Q>()));
    }

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

    protected override int SystemDimension
    {
      get { return 2; }
    }
    
    protected override IGnuplotEntropyScriptGen CreateScriptGen(string file, GnuplotScriptParameters ps)
    {
      return new GnuplotEntropy3dWithBaseScriptGen(file, ps);
    }
  }
}