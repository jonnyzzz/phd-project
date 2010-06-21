using System.Collections.Generic;

namespace DSIS.Graph.Morse
{
  public interface IMorseEvaluatorGraph<T>
  {
    //TODO: Rename to GetEdges
    IEnumerable<T> GetNodes(T node);
    IEnumerable<T> GetNodes();

    IEqualityComparer<T> Comparer { get; }
  }
}