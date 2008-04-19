using System.Collections.Generic;
using System.Globalization;
using System.IO;
using DSIS.Core.Coordinates;
using DSIS.Graph.Entropy.Impl.Entropy;
using DSIS.Graph.Entropy.Impl.Util;
using DSIS.Scheme.Ctx;
using DSIS.Scheme.Impl.Actions.Files;
using DSIS.Utils;

namespace DSIS.Scheme.Impl.Actions.Console
{
  public abstract class DumpEntropyAction : IntegerCoordinateSystemActionBase2
  {
    protected override ICollection<ContextMissmatchCheck> Check<T, Q>(T system, Context ctx)
    {
      return ColBase(base.Check<T, Q>(system, ctx),
                     Create(Keys.GraphMeasure<Q>()));      
    }

    protected sealed override void Apply<T, Q>(T system, Context input, Context output)
    {
      Dump(Logger.Instance(input), Keys.GraphMeasure<Q>().Get(input));      
    }

    protected abstract void Dump<Q>(Logger logger, IGraphMeasure<Q> measure) 
      where Q : ICellCoordinate;
  }
}