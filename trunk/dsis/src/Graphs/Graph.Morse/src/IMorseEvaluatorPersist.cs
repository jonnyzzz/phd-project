using System;

namespace DSIS.Graph.Morse
{
  public interface IMorseEvaluatorPersist<T>
  {
    void SaveGraph(IMorseEvaluatorGraph<T> graph, Func<T, double> weight);    
  }
}