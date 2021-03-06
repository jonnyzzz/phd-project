﻿using System.Collections.Generic;
using DSIS.Core.Coordinates;

namespace DSIS.Graph.FS
{
  public class FSNodeInMemoryIndexImpl<TCell> : IFSNodeIndex<TCell>
    where TCell : ICellCoordinate
  {
    private readonly IEqualityComparer<TCell> myCellsComparer;
    private readonly Dictionary<TCell, IndexEntry> myMap;

    public FSNodeInMemoryIndexImpl(IEqualityComparer<TCell> cellsComparer)
    {
      myCellsComparer = cellsComparer;
      myMap = new Dictionary<TCell, IndexEntry>(myCellsComparer);
    }

    public void LoadIndex(IIndexInputStream index, SimpleNodeReader<TCell> reader)
    {
      foreach (var entry in index.ReadData())
      {
        myMap.Add(reader.ReadCell(entry), entry);
      }
    }

    public void Dispose()
    {
      myMap.Clear();
    }

    public IndexEntry? FindNode(TCell node)
    {
      IndexEntry e;
      return myMap.TryGetValue(node, out e) ? (IndexEntry?)e : null;
    }

    public IEnumerable<IndexEntry> Entries
    {
      get { return myMap.Values; }
    }
  }
}