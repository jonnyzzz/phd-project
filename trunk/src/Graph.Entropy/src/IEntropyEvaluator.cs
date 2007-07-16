/*
 * Created by: 
 * Created: 21 ����� 2007 �.
 */

using DSIS.Core.Coordinates;
using DSIS.Core.Util;

namespace DSIS.Graph.Entropy
{
  public interface IEntropyEvaluator
  {
    double ComputeEntropy<T>(IProgressInfo progress, IGraph<T> graph, IGraphStrongComponents<T> comps)
      where T : ICellCoordinate<T>;

    double[] ComputeEntropyWithBackSteps<T>(IProgressInfo progress, IGraph<T> graph, IGraphStrongComponents<T> comps)
      where T : ICellCoordinate<T>;

    double[] ComputeEntropyWithBackSteps<T>(IProgressInfo progress, IGraph<T> graph, IGraphStrongComponents<T> comps, int limit)
      where T : ICellCoordinate<T>;
  }
}