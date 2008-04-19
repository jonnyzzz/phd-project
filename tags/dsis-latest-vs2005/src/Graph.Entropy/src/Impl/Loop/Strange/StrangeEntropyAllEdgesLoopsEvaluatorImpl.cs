using System;
using DSIS.Core.Coordinates;
using DSIS.Graph.Abstract;
using DSIS.Graph.Entropy.Impl.Loop.Iterators;
using DSIS.Graph.Entropy.Impl.Loop.Weight;

namespace DSIS.Graph.Entropy.Impl.Loop.Strange
{
  [Obsolete]
  internal class StrangeEntropyAllEdgesLoopsEvaluatorImpl<T> : EntropyEvaluatorLoopBase<T>
    where T : ICellCoordinate
  {
    public StrangeEntropyAllEdgesLoopsEvaluatorImpl(IEntropyLoopWeightCallback loopCallback) : base(loopCallback)
    {
    }


    protected override ILoopIterator<T> CreateIterator(ILoopIteratorCallback<T> callback,
                                                       IGraphStrongComponents<T> comps, IGraph<T> graph,
                                                       IStrongComponentInfo info)
    {
      return new AllEngesOnALoopGraphSearch<T>(callback, comps, info);
    }
  }
}