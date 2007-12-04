using System.Collections.Generic;
using DSIS.Core.Coordinates;
using DSIS.Graph.Entropy.Impl.Util;
using DSIS.Utils;

namespace DSIS.Graph.Entropy.Impl.Entropy
{
  public class DividingEntropyEvaluator<T, TPair> : EntropyEvaluator<T, TPair>, IEntropyProcessor<T>
    where T : ICellCoordinate<T>
    where TPair : PairBase<T>
  {
    public DividingEntropyEvaluator(IDictionary<TPair, double> m, double norm, IEqualityComparer<T> comparer) : base(m, norm, comparer)
    {
    }

    public IEntropyProcessor<T> Divide(ICellCoordinateSystemProjector<T> projector)
    {
      return new DividingEntropyEvaluator<T, NodePair<T>>(
        Project(myM, projector),
        myNorm,
        EqualityComparerFactory<T>.GetComparer());
    }

    private static Dictionary<NodePair<T>, double> Project(IEnumerable<KeyValuePair<TPair, double>> m, ICellCoordinateSystemProjector<T> projector)
    {
      Dictionary<NodePair<T>, double> ret = new Dictionary<NodePair<T>, double>(EqualityComparerFactory<NodePair<T>>.GetComparer());

      foreach (KeyValuePair<TPair, double> pair in m)
      {
        T pFrom = projector.Project(pair.Key.From);
        T pTo = projector.Project(pair.Key.To);

        if (pFrom != null && pTo != null)
        {
          Add(ret, new NodePair<T>(pFrom, pTo), pair.Value);
        }
      }
      return ret;
    }

  }
}