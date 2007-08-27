using System;
using DSIS.Core.Coordinates;
using DSIS.Core.Util;
using DSIS.Graph.Abstract;

namespace DSIS.Graph.Entropy.Impl
{
  internal abstract class EntropyEvaluatorBase<T> : IEntropyEvaluator<T>
    where T : ICellCoordinate<T>
  {
    private readonly IEntropyLoopWeightCallback myLoopCallback;

    protected EntropyEvaluatorBase(IEntropyLoopWeightCallback loopCallback)
    {
      myLoopCallback = loopCallback;
    }

    public void ComputeEntropy(IEntropyEvaluatorController<T> controller, IProgressInfo progressInfo)
    {
      EntropyBackStepGraphWeightCallback<T> cb =
        new EntropyBackStepGraphWeightCallback<T>(controller.Graph.CoordinateSystem, myLoopCallback);

      Console.Out.WriteLine("Loops search started");
      foreach (IStrongComponentInfo info in controller.Components.Components)
      {
        ILoopIterator<T> it = CreateIterator(cb, controller.Components, controller.Graph, info, progressInfo);
        it.WidthSearch(progressInfo);
      }
      Console.Out.WriteLine("Loops search finished");

      controller.SetCoordinateSystem(cb.System);
      cb.ComputeEntropy(progressInfo, controller);

      int dim = cb.System.SystemSpace.Dimension;

      while (controller.SubdivideNext(cb.System))
      {
        controller.SetCoordinateSystem(cb.System);
        cb = cb.BackStep(FillArray(2, dim));
        if (cb == null)
          break;
        
        cb.ComputeEntropy(progressInfo, controller);
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