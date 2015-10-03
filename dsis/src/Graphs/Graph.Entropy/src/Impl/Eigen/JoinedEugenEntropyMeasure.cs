using System.Collections.Generic;
using System.Linq;
using DSIS.Core.Coordinates;
using DSIS.Graph.Entropy.Impl.Entropy;
using DSIS.Graph.Entropy.Impl.Util;
using DSIS.Utils;

namespace DSIS.Graph.Entropy.Impl.Eigen
{
  public class JoinedEugenEntropyMeasure<T> : IGraphMeasure<T> 
    where T : ICellCoordinate
  {
    private readonly List<EigenEntropyMeasure<T>> myMeasures = new List<EigenEntropyMeasure<T>>();

    public JoinedEugenEntropyMeasure(IEnumerable<EigenEntropyMeasure<T>> measures) 
    {
      myMeasures.AddRange(measures);
    }

    public string Method
    {
      get { return "Eigen"; }
    }

    public double GetEntropy()
    {
      return myMeasures.Max(x => x.GetEntropy());
    }

    public void DoCallback(IGraphMeasureWith measure)
    {
      AMeasure.DoCallback(measure);
    }

    private EigenEntropyMeasure<T> AMeasure
    {
      get { return myMeasures[0]; }
    }

    public double[] CellSize
    {
      get { return AMeasure.CellSize; }
    }

    public int EdgesCount
    {
      get { return myMeasures.Sum(x => x.EdgesCount); }
    }

    public int NodesCount
    {
      get { return myMeasures.Sum(x => x.NodesCount); }
    }

    public ICellCoordinateSystem<T> CoordinateSystem
    {
      get { return AMeasure.CoordinateSystem; }
    }

    public IEnumerable<Pair<PairBase<T>, double>> Measure
    {
      get { yield break; }
    }

    public double ComputeRelativeEntropy(IGraphMeasure<T> initialMeasure)
    {
      throw new System.NotImplementedException();
    }

    public IDictionary<T, double> GetMeasureNodes()
    {
      return new Dictionary<T, double>();
    }

    public IGraphMeasure<T> Project(ICellCoordinateSystemProjector<T> projector)
    {
      return new JoinedEugenEntropyMeasure<T>(myMeasures.Select(x => x.ProjectInternal(projector)));
    }
  }
}