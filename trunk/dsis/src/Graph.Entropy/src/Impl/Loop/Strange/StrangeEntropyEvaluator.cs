using DSIS.Core.Coordinates;
using DSIS.Graph.Entropy.Impl.Entropy;

namespace DSIS.Graph.Entropy.Impl.Loop.Strange
{
  public class StrangeEntropyEvaluator<T,N>
    where T : ICellCoordinate
    where N : class, INode<T>
  {    
    public IGraphMeasure<T> Measure(IReadonlyGraph<T,N> graph, IReadonlyGraphStrongComponents<T,N> comps, StrangeEntropyEvaluatorParams @params)
    {
      //TODO: Refactor to use components.AsGraph
//      comps = new CachedGraphStrongComponents<T>(comps);
      
      var cb = new EntropyGraphWeightCallback<T,N>(@params.LoopWeight, graph.CoordinateSystem);
      foreach (IStrongComponentInfo info in comps.Components)
      {
        @params.CreateIterator(cb, comps, info).WidthSearch();
      }

      return cb.Entropy();
    }    
  }
}