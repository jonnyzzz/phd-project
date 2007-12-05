using System.Collections.Generic;
using DSIS.Core.Coordinates;
using DSIS.Graph.Entropy.Impl.Entropy;
using DSIS.Scheme.Ctx;

namespace DSIS.Scheme.Impl.Actions.Console
{
  public abstract class DumpEntropyAction : IntegerCoordinateSystemActionBase2
  {
    protected sealed override ICollection<ContextMissmatchCheck> Check<T, Q>(T system, Context ctx)
    {
      return Col(base.Check<T, Q>(system, ctx),
                 Create(Keys.GraphMeasure<Q>()));
      
    }

    protected sealed override void Apply<T, Q>(T system, Context input, Context output)
    {
      Dump(Keys.GraphMeasure<Q>().Get(input));      
    }

    protected abstract void Dump<Q>(IGraphMeasure<Q> measure) where Q : ICellCoordinate<Q>;
  }

  public class DumpEntropyValueAction : DumpEntropyAction
  {
    protected override void Dump<Q>(IGraphMeasure<Q> measure)
    {
      System.Console.Out.WriteLine("Entropy: {0}", measure.GetEntropy());
    }
  }
   
}