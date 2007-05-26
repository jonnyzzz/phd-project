/*
 * Created by: Eugene Petrenko
 * Created: 21 ����� 2007 �.
 */

using System.Collections.Generic;
using DSIS.Core.Coordinates;
using DSIS.Core.Util;
using DSIS.Graph;
using DSIS.Graph.Abstract;

namespace DSIS.Graph.Entropy.Impl
{
  internal class EntropyEvaluatorImpl : IEntropyEvaluator
  {
    private static T GetFirst<T>(IEnumerable<T> ts) where T : class
    {
      foreach (T t in ts)
      {
        return t;
      }
      return null;
    }

    public double ComputeEntropy<T>(IProgressInfo progress, IGraph<T> graph, IGraphStrongComponents<T> comps)
      where T : ICellCoordinate<T>
    {
      double entropy = 0;
      foreach (IStrongComponentInfo info in comps.Components)
      {
        EntropyGraphWeightCallback<T> cb = new EntropyGraphWeightCallback<T>();
        LoopIterator<T, NonDuplicatedLoopIteratorCallback<T, EntropyGraphWeightCallback<T>>> search =
          new LoopIterator<T, NonDuplicatedLoopIteratorCallback<T, EntropyGraphWeightCallback<T>>>(
          new NonDuplicatedLoopIteratorCallback<T, EntropyGraphWeightCallback<T>>(cb), graph, comps, info);

        search.WidthSearch(progress, info.NodesCount, GetFirst(comps.GetNodes(new IStrongComponentInfo[] {info})));

        entropy += cb.ComputeAntropy(progress);
      }
      return entropy;
    }
  }
}