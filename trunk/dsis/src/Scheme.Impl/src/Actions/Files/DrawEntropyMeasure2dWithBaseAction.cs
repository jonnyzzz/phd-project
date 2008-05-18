using System.Collections.Generic;
using DSIS.GnuplotDrawer;
using DSIS.Graph.Entropy.Impl.Entropy;
using DSIS.Scheme.Ctx;

namespace DSIS.Scheme.Impl.Actions.Files
{
  public class DrawEntropyMeasure2dWithBaseAction : DrawEntropyMeasureActionBase
  {
    protected override ICollection<ContextMissmatchCheck> Check<T, Q>(T system, Context ctx)
    {
      return ColBase(base.Check<T, Q>(system, ctx), Create(Keys.GraphComponents<Q>()));
    }

    protected override int SystemDimension
    {
      get { return 1; }
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