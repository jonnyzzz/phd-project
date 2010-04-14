using System.Collections.Generic;
using DSIS.Core.Coordinates;

namespace DSIS.Graph.Morse
{
  public interface IMorseEvaluatorGraph<T> where T : ICellCoordinate
  {
    IEnumerable<INode<T>> GetNodes(INode<T> node);
    IEnumerable<INode<T>> GetNodes();
  }
}