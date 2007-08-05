/*
 * Created by: Eugene Petrenko
 * Created: 21 марта 2007 г.
 */

using System.Collections.Generic;
using DSIS.Core.Coordinates;
using DSIS.Core.Util;
using DSIS.IntegerCoordinates;

namespace DSIS.Graph.Entropy
{
  public interface IEntropyEvaluator<T>
    where T : ICellCoordinate<T>
  { 
    void ComputeEntropy(IEntropyEvaluatorController<T> controller, IProgressInfo progressInfo);
  }

  public interface IEntropyListener<T> where T : ICellCoordinate<T>
  {
    void OnResult(double result, IDictionary<T, double> measure);
  }

  public interface IEntropyEvaluatorController<T> : IEntropyListener<T> where T : ICellCoordinate<T>
  {
    IGraph<T> Graph { get;}
    IGraphStrongComponents<T> Components { get; }

    bool SubdivideNext(ICellCoordinateSystem<T> system);
    void SetCoordinateSystem(ICellCoordinateSystem<T> system);
  }
}