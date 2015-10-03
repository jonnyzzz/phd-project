using DSIS.Core.Coordinates;
using DSIS.Graph.Entropy.Impl.Entropy;

namespace DSIS.Graph.Entropy.Impl.JVR
{
  public class JVREvaluator<T> where T : ICellCoordinate
  {
    protected readonly JVRMeasureOptions myOpts;

    public JVREvaluator(JVRMeasureOptions opts)
    {
      myOpts = opts;
    }

    public IGraphMeasure<T> Measure(IReadonlyGraph<T> graph, IGraphStrongComponents<T> comps)
    {
      var j = CreateMeasure(graph, comps);
      j.FillGraph();      
      j.Iterate(myOpts.EPS);

      return j.CreateEvaluator();
    }

    protected virtual JVRMeasure<T> CreateMeasure(IReadonlyGraph<T> graph, IGraphStrongComponents<T> comps)
    {
      return new JVRMeasure<T>(graph, comps, myOpts);
    }
  }
}