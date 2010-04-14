using System;
using System.Collections.Generic;

namespace DSIS.Graph.Morse
{
  public interface IMorseEvaluatorGraph<N> 
    where N : class
  {
    IEnumerable<N> GetNodes(N node);
    IEnumerable<N> GetNodes();

    long Count { get;}

    IEqualityComparer<N> Comparer { get; }


    IGraphDataHolder<T, N> AllocDataHolder<T>(Func<N,T> def);
  }
}