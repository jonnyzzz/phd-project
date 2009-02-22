using DSIS.Core.Coordinates;
using DSIS.Graph.Entropy.Impl.Entropy;

namespace DSIS.Graph.Entropy.Impl.JVR
{
  public class JVREvaluator<T>
    where T : ICellCoordinate
  {
    private readonly JVRMeasureOptions myOpts;

    public JVREvaluator(JVRMeasureOptions opts)
    {
      myOpts = opts;
    }

    public IGraphMeasure<T> Measure(IGraph<T> graph, IGraphStrongComponents<T> comps)
    {
      var j = new JVRMeasure<T>(graph, comps, myOpts);
      j.FillGraph();      
      j.Iterate(myOpts.EPS);

      return j.CreateEvaluator();
    }
  }
}