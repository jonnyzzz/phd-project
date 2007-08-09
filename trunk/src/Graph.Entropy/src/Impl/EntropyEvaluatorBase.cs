using System.Collections.Generic;
using DSIS.Core.Coordinates;
using DSIS.Core.Util;
using DSIS.Graph.Abstract;

namespace DSIS.Graph.Entropy.Impl
{
  internal abstract class EntropyEvaluatorBase<T> : IEntropyEvaluator<T>
    where T : ICellCoordinate<T>
  {
    public void ComputeEntropy(IEntropyEvaluatorController<T> controller, IProgressInfo progressInfo)
    {
      EntropyBackStepGraphWeightCallback<T> cb =
        new EntropyBackStepGraphWeightCallback<T>(controller.Graph.CoordinateSystem);

      foreach (IStrongComponentInfo info in controller.Components.Components)
      {
        ILoopIterator<T> it = CreateIterator(cb, controller.Components, controller.Graph, info, progressInfo);
        it.WidthSearch(progressInfo);
      }

      controller.SetCoordinateSystem(cb.System);
      cb.ComputeAntropy(progressInfo, controller);

      int dim = cb.System.SystemSpace.Dimension;

      while (controller.SubdivideNext(cb.System))
      {
        controller.SetCoordinateSystem(cb.System);
        cb = cb.BackStep(FillArray(2, dim));
        if (cb == null)
          break;
        
        cb.ComputeAntropy(progressInfo, controller);
      }
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

    protected abstract ILoopIterator<T> CreateIterator<C>(
      C callback, IGraphStrongComponents<T> comps, IGraph<T> graph,
      IStrongComponentInfo info, IProgressInfo progress)
      where C : ILoopIteratorCallback<T>;
  }
}