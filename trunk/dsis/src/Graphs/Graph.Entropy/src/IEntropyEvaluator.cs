/*
 * Created by: Eugene Petrenko
 * Created: 21 марта 2007 г.
 */

using System;
using System.Collections.Generic;
using DSIS.Core.Coordinates;
using DSIS.Core.Util;
using DSIS.Graph.Entropy.Impl.Util;

namespace DSIS.Graph.Entropy
{
  [Obsolete]
  public interface IEntropyEvaluator<T>
    where T : ICellCoordinate
  { 
    void ComputeEntropy(IEntropyEvaluatorController<T> controller, IProgressInfo progressInfo);    
  }

  [Obsolete]
  public interface IEntropyListener<T> 
    where T : ICellCoordinate
  {
    void OnResult<Q>(double result, IDictionary<T, double> measure, IDictionary<Q, double> edges) where Q:PairBase<T>;
  }


  public interface IEntropyEvaluatorInput<T>
    where T : ICellCoordinate
  {
    IGraph<T> Graph { get;}
    IGraphStrongComponents<T> Components { get; }    
  }

  public interface IEntropyEvaluatorController<T> : IEntropyListener<T>, IEntropyEvaluatorInput<T>
    where T : ICellCoordinate
  {
    bool SubdivideNext(ICellCoordinateSystem<T> system);
    void SetCoordinateSystem(ICellCoordinateSystem<T> system);
  }
}