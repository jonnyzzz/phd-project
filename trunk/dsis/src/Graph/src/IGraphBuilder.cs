using System;
using System.Collections.Generic;
using DSIS.Core.Coordinates;
using JetBrains.Annotations;

namespace DSIS.Graph
{
  public interface IGraphBuilder<TCoordinate> : IDisposable
    where TCoordinate : ICellCoordinate
  {
    void AddEdges(TCoordinate from, IEnumerable<TCoordinate> tos);

    [NotNull]
    IReadonlyGraph<TCoordinate> BuildFinished();
  }
}