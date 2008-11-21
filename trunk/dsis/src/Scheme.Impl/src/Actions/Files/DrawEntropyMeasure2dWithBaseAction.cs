using System.Collections.Generic;
using DSIS.Core.Ioc;
using DSIS.GnuplotDrawer;
using DSIS.Graph.Entropy.Impl.Entropy;
using DSIS.Scheme.Ctx;

namespace DSIS.Scheme.Impl.Actions.Files
{
  [ComponentImplementation]
  public class DrawEntropyMeasure2dWithBaseAction : DrawEntropyMeasureActionBase
  {
    protected override ICollection<ContextMissmatchCheck> Check<T, Q>(Context ctx)
    {
      return ColBase(base.Check<T, Q>(ctx), Create(Keys.GraphComponents<Q>()));
    }

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