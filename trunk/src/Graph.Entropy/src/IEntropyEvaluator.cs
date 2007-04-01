/*
 * Created by: 
 * Created: 21 марта 2007 г.
 */

using DSIS.Core.Coordinates;
using DSIS.Core.Util;

namespace DSIS.Graph.Entropy
{
  public interface IEntropyEvaluator
  {
    double ComputeEntropy<T>(IProgressInfo progress, IGraph<T> graph, IGraphStrongComponents<T> comps) where T : ICellCoordinate<T>;
  }
}