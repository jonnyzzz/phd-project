using DSIS.Core.Coordinates;
using DSIS.Graph.Entropy.Impl.Entropy;

namespace DSIS.Graph.Entropy.Impl.JVR
{
  internal class JVREvaluator<T> : EntropyEvaluatorBase<T> 
    where T : ICellCoordinate<T>
  {
    private const double EPS = 1e-3;

//    private static int cmt;

    protected override IEntropyProcessor<T> Measure(IEntropyEvaluatorInput<T> data)
    {
      JVRMeasure<T> j = new JVRMeasure<T>(data.Graph, data.Components);
      j.FillGraph();      
      j.Iterate(EPS);

//      using(TextWriter tw = File.CreateText(string.Format(@"e:\graph{0}.txt", ++cmt)))
//        j.Dump(tw);

      return new EntropyProcessorAdapter<T>(j.CreateEvaluator());
    }
  }
}