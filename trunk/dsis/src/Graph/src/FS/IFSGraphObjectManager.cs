using System.Collections.Generic;
using DSIS.Core.Coordinates;
using DSIS.Persistance.Streams;

namespace DSIS.Graph.FS
{
  public interface IFSGraphObjectManager
  {
    IOutputStream CreateNodesWriteStream();
    IIndexOutputStream CreateIndexOutputStream();

    SimpleNodeReader<TCell> CreateNodeReader<TCell>(IOutputStream nodesOutputStream,
                                                    ICellCoordinateSystemPersist<TCell> persist,
                                                    IEqualityComparer<TCell> comparer)
      where TCell : ICellCoordinate;

    IFSNodeIndex<TCell> CreateNodeIndex<TCell>(IIndexOutputStream indexInputStream,
                                               SimpleNodeReader<TCell> reader,
                                               ICellCoordinateSystemPersist<TCell> persist,
                                               IEqualityComparer<TCell> comparer)
      where TCell : ICellCoordinate;
  }
}