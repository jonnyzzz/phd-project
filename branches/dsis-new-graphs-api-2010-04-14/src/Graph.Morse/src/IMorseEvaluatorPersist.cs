using System;

namespace DSIS.Graph.Morse
{
  public interface IMorseEvaluatorPersist<N> 
    where N : class
  {
    void SaveGraph(IMorseEvaluatorGraph<N> graph, Func<N, double> weight);

    string Name { get; }
  }
}