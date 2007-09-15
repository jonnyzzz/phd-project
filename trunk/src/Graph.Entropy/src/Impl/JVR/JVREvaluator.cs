using DSIS.Core.Coordinates;
using DSIS.Graph.Entropy.Impl.Entropy;

namespace DSIS.Graph.Entropy.Impl.JVR
{
  internal class JVREvaluator<T> : EntropyEvaluatorBase<T> 
    where T : ICellCoordinate<T>
  {
    private const double EPS = 1e-6;

    protected override IEntropyProcessor<T> Measure(IEntropyEvaluatorInput<T> data)
    {
      JVRMeasure<T> j = new JVRMeasure<T>(data.Graph, data.Components);
      j.FillGraph();
      j.Norm();
      j.Iterate(EPS);
      return j.CreateEvaluator();
    }
  }
}