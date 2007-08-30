/*
 * Created by: Eugene Petrenko
 * Created: 21 ����� 2007 �.
 */

using System.Collections.Generic;
using DSIS.Core.Coordinates;
using DSIS.Core.Util;

namespace DSIS.Graph.Entropy
{
  public interface IEntropyEvaluator<T>
    where T : ICellCoordinate<T>
  { 
    void ComputeEntropy(IEntropyEvaluatorController<T> controller, IProgressInfo progressInfo);
  }

  public interface IEntropyListener<T> 
    where T : ICellCoordinate<T>
  {
    void OnResult(double result, IDictionary<T, double> measure);
  }

  public interface IEntropyEvaluatorInput<T>
    where T : ICellCoordinate<T>
  {
    IGraph<T> Graph { get;}
    IGraphStrongComponents<T> Components { get; }    
  }

  public interface IEntropyEvaluatorController<T> : IEntropyListener<T>, IEntropyEvaluatorInput<T>
    where T : ICellCoordinate<T>
  {
    bool SubdivideNext(ICellCoordinateSystem<T> system);
    void SetCoordinateSystem(ICellCoordinateSystem<T> system);
  }
}