/*
 * Created by: Eugene Petrenko
 * Created: 21 ����� 2007 �.
 */

using System;
using System.Collections.Generic;
using DSIS.Core.Coordinates;
using DSIS.Core.Util;
using DSIS.Graph.Entropy.Impl.Entropy;
using DSIS.Graph.Entropy.Impl.Util;

namespace DSIS.Graph.Entropy
{
  [Obsolete]
  public interface IEntropyEvaluator<T>
    where T : ICellCoordinate<T>
  { 
    void ComputeEntropy(IEntropyEvaluatorController<T> controller, IProgressInfo progressInfo);    
  }

  [Obsolete]
  public interface IEntropyListener<T> 
    where T : ICellCoordinate<T>
  {
    void OnResult<Q>(double result, IDictionary<T, double> measure, IDictionary<Q, double> edges) where Q:PairBase<T>;
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


  public interface IEntropyEvaluator2<T> where T : ICellCoordinate<T>
  {
    IGraphMeasure<T> ComputeEntropy();
  }
}