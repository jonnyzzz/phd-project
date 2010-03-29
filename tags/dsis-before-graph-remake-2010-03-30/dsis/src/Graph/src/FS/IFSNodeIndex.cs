﻿using System;
using System.Collections.Generic;
using DSIS.Core.Coordinates;

namespace DSIS.Graph.FS
{
  public interface IFSNodeIndex<in TCell> : IDisposable
    where TCell : ICellCoordinate
  {
    IndexEntry? FindNode(TCell node);

    IEnumerable<IndexEntry> Entries { get; }
  }
}