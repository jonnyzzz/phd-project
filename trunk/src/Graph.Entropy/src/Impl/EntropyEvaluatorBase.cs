using DSIS.Core.Coordinates;
using DSIS.Core.Util;
using DSIS.Graph.Entropy.Impl.Entropy;

namespace DSIS.Graph.Entropy.Impl
{
  internal abstract class EntropyEvaluatorBase<T> : IEntropyEvaluator<T>
    where T : ICellCoordinate<T>
  {
    protected abstract IEntropyProcessor<T> Measure(IEntropyEvaluatorInput<T> data);

    public void ComputeEntropy(IEntropyEvaluatorController<T> controller, IProgressInfo progressInfo)
    {
      IEntropyProcessor<T> measure = Measure(controller);

      ICellCoordinateSystem<T> system = controller.Graph.CoordinateSystem;      
      int dim = system.SystemSpace.Dimension;
      ICellCoordinateSystemProjector<T> project = null;

      while (controller.SubdivideNext(system))
      {
        if (project != null) 
          measure = measure.Divide(project);        

        measure.ComputeEntropy(controller);        
      
        project = system.Project(FillArray(2, dim));
        if (project == null)
          return;
        system = project.ToSystem;
        controller.SetCoordinateSystem(system);        
      }
    }

    protected static long[] FillArray(long l, long dim)
    {
      long[] result = new long[dim];
      for (int i = 0; i < dim; i++)
      {
        result[i] = l;
      }
      return result;
    }
  }
}