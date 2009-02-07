using System.Collections.Generic;
using DSIS.Core.Coordinates;
using DSIS.Core.System;
using DSIS.Core.Util;
using DSIS.Graph;
using DSIS.Graph.Morse;
using DSIS.Scheme.Ctx;
using DSIS.Graph.Abstract;
using System.Linq;

namespace DSIS.Scheme.Impl.Actions.Entropy
{
  public class JVRMorseAction : IntegerCoordinateSystemActionBase3
  {
    private readonly MorseEvaluatorOptions myOptions;

    public JVRMorseAction(MorseEvaluatorOptions options)
    {
      myOptions = options;
    }

    protected override ICollection<ContextMissmatchCheck> Check<T, Q>(Context ctx)
    {
      return ColBase(base.Check<T,Q>(ctx), Create(Keys.IntegerCoordinateSystemInfo),
        Create(Keys.SystemInfoKey), Create(Keys.GraphComponents<Q>()));
    }

    protected override void Apply<T, Q>(Context input, Context output)
    {
      var system = Keys.IntegerCoordinateSystemInfo.Get(input);
      var function = Keys.SystemInfoKey.Get(input).GetFunction<double>(system.CellSizeHalf);
      var comps = Keys.GraphComponents<Q>().Get(input);

      var diffFunction = (IDetDiffFunction<double>) function;
      var dic = new Dictionary<IStrongComponentInfo, JVRMorseMinMax<Q>>();
      foreach (var comp in comps.Components)
      {
        var evaluator = new DetDiffMorseEvaluator<Q>(myOptions, diffFunction, comps, comp);
        var max = evaluator.Compute(true);
        var min = evaluator.Compute(false);

        dic.Add(comp, new JVRMorseMinMax<Q>(max, min));
      }
      Keys.Morse<Q>().Set(output, new JVRMorseResult<Q>(dic));
    }
  }

  public class JVRMorseMinMax<Q> where Q : ICellCoordinate
  {    
    public readonly ComputationResult<Q> Max;
    public readonly ComputationResult<Q> Min;

    public JVRMorseMinMax(ComputationResult<Q> max, ComputationResult<Q> min)
    {
      Max = max;
      Min = min;
    }
  }

  public class JVRMorseResult<Q> where Q : ICellCoordinate
  {
    private readonly Dictionary<IStrongComponentInfo, JVRMorseMinMax<Q>> myResults;

    public JVRMorseResult(Dictionary<IStrongComponentInfo, JVRMorseMinMax<Q>> results)
    {
      myResults = results;
    }

    public IEnumerable<IStrongComponentInfo> Components { get { return myResults.Keys; } }

    public JVRMorseMinMax<Q> Get(IStrongComponentInfo comp)
    {
      return myResults[comp];
    }
  }
}