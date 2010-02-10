using System;
using DSIS.Core.Coordinates;

namespace DSIS.Graph.Morse
{
  public interface IMorseEvaluatorPersist<T> where T : ICellCoordinate
  {
    void SaveGraph(IMorseEvaluatorGraph<T> graph, Func<INode<T>, double> weight);
    string Name { get; }
  }
}