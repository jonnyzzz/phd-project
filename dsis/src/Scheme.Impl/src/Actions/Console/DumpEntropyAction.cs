using System.Collections.Generic;
using DSIS.Core.Coordinates;
using DSIS.Graph.Entropy.Impl.Entropy;
using DSIS.Scheme.Ctx;
using DSIS.Scheme.Impl.Actions.Files;

namespace DSIS.Scheme.Impl.Actions.Console
{
  public abstract class DumpEntropyAction : IntegerCoordinateSystemActionBase3
  {
    protected override ICollection<ContextMissmatchCheck> Check<T, Q>(Context ctx)
    {
      return ColBase(base.Check<T, Q>(ctx),
                     Create(Keys.GraphMeasure<Q>()));      
    }

    protected sealed override void Apply<T, Q>(Context input, Context output)
    {
      Dump(Logger.Instance(input), Keys.GraphMeasure<Q>().Get(input));      
    }

    protected abstract void Dump<Q>(Logger logger, IGraphMeasure<Q> measure) 
      where Q : ICellCoordinate;
  }
}