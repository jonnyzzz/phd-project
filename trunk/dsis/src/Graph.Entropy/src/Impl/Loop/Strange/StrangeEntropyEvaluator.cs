using System;
using DSIS.Core.Coordinates;
using DSIS.Graph.Abstract;
using DSIS.Graph.Entropy.Impl.Entropy;
using DSIS.Graph.Entropy.Impl.Loop.Iterators;
using DSIS.Graph.Entropy.Impl.Loop.Strange;

namespace DSIS.Graph.Entropy.Impl.Loop.Strange
{
  public class StrangeEntropyEvaluator<T>
    where T : ICellCoordinate<T>
  {    
    public IGraphMeasure<T> Measure(IGraph<T> graph, IGraphStrongComponents<T> comps, StrangeEntropyEvaluatorParams @params)
    {
      EntropyGraphWeightCallback<T> cb = new EntropyGraphWeightCallback<T>(@params.LoopWeight);
      foreach (IStrongComponentInfo info in comps.Components)
      {
        ILoopIterator<T> it = @params.CreateIterator(cb, comps, info);
        it.WidthSearch();
      }

      return cb.Entropy();
    }    
  }
}