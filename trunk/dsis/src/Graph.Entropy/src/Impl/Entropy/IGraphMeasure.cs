using System.Collections.Generic;
using DSIS.Core.Builders;
using DSIS.Core.Coordinates;
using DSIS.Graph.Entropy.Impl.Util;
using DSIS.Persistance;
using DSIS.Utils;

namespace DSIS.Graph.Entropy.Impl.Entropy
{
  public interface IGraphEntropy
  {
    double GetEntropy();    
  }

  public interface IGraphMeasure<T> : IGraphEntropy where T : ICellCoordinate
  {
    string Method { get; }
    ICellCoordinateSystem<T> CoordinateSystem { get;}

    IEnumerable<Pair<PairBase<T>, double>> Measure { get; }    
    IDictionary<T, double> GetMeasureNodes();
    IGraphMeasure<T> Project(ICellCoordinateSystemProjector<T> projector);
  }

  public class GraphMasurePersistance<Q> where Q : ICellCoordinate
  {
    private static string Key() {
      return "GRAPH_MEASURE_PERSISTANCE"; 
    }

    public void Save(IGraphMeasure<Q> measure, IBinaryWriter writer)
    {
      writer.WriteString(Key());
      
      

    }
  }
}