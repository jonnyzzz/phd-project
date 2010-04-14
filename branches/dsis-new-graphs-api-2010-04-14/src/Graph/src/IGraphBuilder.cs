using System;
using System.Collections.Generic;
using DSIS.Core.Coordinates;
using JetBrains.Annotations;

namespace DSIS.Graph
{
  public interface IGraghNodeWriter<in TCoordinate> : IDisposable
  {
    void AddEdges(TCoordinate from, IEnumerable<TCoordinate> tos);
  }

  public interface IGraphBuilder<TCoordinate>
    where TCoordinate : ICellCoordinate
  {
    /// <summary>
    /// Allocates a writer for graph nodes. 
    /// Only one writer can be allocated now
    /// </summary>
    /// <returns>Writer interface</returns>
    [NotNull]
    IGraghNodeWriter<TCoordinate> GetWriter();

    [NotNull]
    IReadonlyGraph<TCoordinate> BuildFinished();
  }
}