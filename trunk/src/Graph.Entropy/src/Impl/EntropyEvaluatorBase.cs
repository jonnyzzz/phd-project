using System.Collections.Generic;
using DSIS.Core.Coordinates;
using DSIS.Core.Util;
using DSIS.Graph.Abstract;

namespace DSIS.Graph.Entropy.Impl
{
  internal abstract class EntropyEvaluatorBase
  {
    public double ComputeEntropy<T>(IProgressInfo progress, IGraph<T> graph, IGraphStrongComponents<T> comps)
      where T : ICellCoordinate<T>
    {
      EntropyGraphWeightCallback<T> cb = new EntropyGraphWeightCallback<T>();
      foreach (IStrongComponentInfo info in comps.Components)
      {
        ILoopIterator<T> it = CreateIterator(cb, comps, graph, info, progress);
        it.WidthSearch(
          progress,
          info.NodesCount,
          GetFirst(comps.GetNodes(new IStrongComponentInfo[] {info})));
      }

      return cb.ComputeAntropy(progress);
    }

    public double[] ComputeEntropyWithBackSteps<T>(IProgressInfo progress, IGraph<T> graph,
                                                   IGraphStrongComponents<T> comps) where T : ICellCoordinate<T>
    {
      return ComputeEntropyWithBackSteps(progress, graph, comps, 1 << 30);
    }

    public double[] ComputeEntropyWithBackSteps<T>(IProgressInfo progress, IGraph<T> graph,
                                                   IGraphStrongComponents<T> comps, int limit)
      where T : ICellCoordinate<T>
    {
      List<double> results = new List<double>();

      EntropyBackStepGraphWeightCallback<T> cb =
        new EntropyBackStepGraphWeightCallback<T>(graph.CoordinateSystem);

      foreach (IStrongComponentInfo info in comps.Components)
      {
        ILoopIterator<T> it = CreateIterator(cb, comps, graph, info, progress);
        it.WidthSearch(
          progress,
          info.NodesCount,
          GetFirst(comps.GetNodes(new IStrongComponentInfo[] {info})));
      }

      results.Add(cb.ComputeAntropy(progress));

      while (limit -- > 0)
      {
        cb = cb.BackStep(FillArray(2, graph.CoordinateSystem.SystemSpace.Dimension));
        if (cb == null)
          break;
        results.Add(cb.ComputeAntropy(progress));
      }

      return results.ToArray();
    }

    private static long[] FillArray(long l, long dim)
    {
      long[] result = new long[dim];
      for (int i = 0; i < dim; i++)
      {
        result[i] = l;
      }
      return result;
    }

    protected abstract ILoopIterator<T> CreateIterator<T, C>(
      C callback, IGraphStrongComponents<T> comps, IGraph<T> graph,
      IStrongComponentInfo info, IProgressInfo progress)
      where T : ICellCoordinate<T>
      where C : ILoopIteratorCallback<T>;

    private static T GetFirst<T>(IEnumerable<T> ts) where T : class
    {
      foreach (T t in ts)
      {
        return t;
      }
      return null;
    }
  }
}