using DSIS.Core.Coordinates;
using DSIS.Graph.Entropy.Impl.Entropy;

namespace DSIS.Graph.Entropy.Impl.JVR
{
  public class JVREvaluator<T>
    where T : ICellCoordinate<T>
  {
    private const double EPS = 1e-3;

    public IGraphMeasure<T> Measure(IGraph<T> graph, IGraphStrongComponents<T> comps)
    {
      JVRMeasure<T> j = new JVRMeasure<T>(graph, comps);
      j.FillGraph();      
      j.Iterate(EPS);

//      using(TextWriter tw = File.CreateText(string.Format(@"e:\graph{0}.txt", ++cmt)))
//        j.Dump(tw);

      return j.CreateEvaluator();
    }
  }
}