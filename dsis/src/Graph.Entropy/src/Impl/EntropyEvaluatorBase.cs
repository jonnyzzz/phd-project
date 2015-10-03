using System;
using DSIS.Core.Coordinates;
using DSIS.Core.Util;
using DSIS.Graph.Entropy.Impl.Entropy;
using DSIS.Utils;

namespace DSIS.Graph.Entropy.Impl
{
  [Obsolete]
  public abstract class EntropyEvaluatorBase<T> : IEntropyEvaluator<T>
    where T : ICellCoordinate
  {
    protected abstract IEntropyProcessor<T> Measure(IEntropyEvaluatorInput<T> data);

    public void ComputeEntropy(IEntropyEvaluatorController<T> controller, IProgressInfo progressInfo)
    {
      IEntropyProcessor<T> measure = Measure(controller);

      ICellCoordinateSystem<T> system = controller.Graph.CoordinateSystem;          
      int dim = system.Dimension;
      ICellCoordinateSystemProjector<T> project = null;

      while (controller.SubdivideNext(system))
      {
        if (project != null) 
          measure = measure.Divide(project);

        controller.SetCoordinateSystem(system);
        measure.ComputeEntropy(controller);        
      
        project = system.Project(2L.Fill(dim));
        if (project == null)
          return;
        system = project.ToSystem;        
      }
    }
  }
}