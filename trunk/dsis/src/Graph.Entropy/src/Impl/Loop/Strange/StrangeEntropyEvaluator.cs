using DSIS.Core.Coordinates;
using DSIS.Graph.Entropy.Impl.Entropy;

namespace DSIS.Graph.Entropy.Impl.Loop.Strange
{
  public class StrangeEntropyEvaluator<T>
    where T : ICellCoordinate
  {    
    public IGraphMeasure<T> Measure(IGraph<T> graph, IGraphStrongComponents<T> comps, StrangeEntropyEvaluatorParams @params)
    {
      //TODO: Refactor to use components.AsGraph
//      comps = new CachedGraphStrongComponents<T>(comps);
      
      var cb = new EntropyGraphWeightCallback<T>(@params.LoopWeight, graph.CoordinateSystem);
      foreach (IStrongComponentInfo info in comps.Components)
      {
        @params.CreateIterator(cb, comps, info).WidthSearch();
      }

      return cb.Entropy();
    }    
  }
}