using DSIS.Core.Coordinates;
using DSIS.Graph.Entropy.Impl.Entropy;

namespace DSIS.Graph.Entropy.Impl.JVR
{
  public class JVREvaluator<T>
    where T : ICellCoordinate
  {
    private const double EPS = 1e-3;

    private readonly JVRMeasureOptions myOpts;


    public JVREvaluator(JVRMeasureOptions opts)
    {
      myOpts = opts;
    }

    public IGraphMeasure<T> Measure(IGraph<T> graph, IGraphStrongComponents<T> comps)
    {
      var j = new JVRMeasure<T>(graph, comps, myOpts);
      j.FillGraph();      
      j.Iterate(EPS);

      return j.CreateEvaluator();
    }
  }
}