using System;
using System.Collections.Generic;
using System.IO;
using DSIS.Core.Coordinates;
using DSIS.Utils;

namespace DSIS.Graph.FS
{
  public class FSGraphBuilder<TCell> : IGraphBuilder<TCell>
    where TCell : ICellCoordinate
  {
    private readonly IEqualityComparer<TCell> Comparer = EqualityComparerFactory<TCell>.GetComparer();

    private readonly ICellCoordinateSystemPersist<TCell> myPersist;
    private readonly Stream myOutputFile;
    private readonly IndexOutputStream myIndexFile;
    private readonly ICellCoordinateSystem<TCell> mySystem;

    private bool myIsDisposed;
    private int myEdgesCount;
    private int myNodesCount;

    public FSGraphBuilder(ICellCoordinateSystemPersist<TCell> persist, Stream outputFile, IndexOutputStream index, ICellCoordinateSystem<TCell> system)
    {
      myPersist = persist;
      mySystem = system;
      myOutputFile = outputFile;
      myIndexFile = index;
    }

    public void Dispose()
    {
      if (!myIsDisposed)
      {
        myIsDisposed = true;
        myIndexFile.Dispose();
        myOutputFile.Flush();
      }
    }

    public void AddEdges(TCell from, IEnumerable<TCell> tos)
    {
      myNodesCount++;
      var e = new IndexEntry {Begin = myOutputFile.Position};
      WriteNodeCoord(from);

      var set = new HashSet<TCell>(Comparer);
      set.UnionWith(tos);
      var isLoop = set.Contains(from);
      
      myEdgesCount += set.Count;

      foreach (var w in set)
        WriteNodeCoord(w);

      e.Data = myOutputFile.Position;
      if (isLoop)
        myOutputFile.WriteByte(1);

      myIndexFile.WriteBlockStartLocation(e);
    }

    private void WriteNodeCoord(TCell node)
    {      
      myPersist.Save(myOutputFile, node);
    }

    public IReadonlyGraph<TCell> BuildFinished()
    {
      if (!myIsDisposed)
        throw new ArgumentException("Call Dispose first");
      
      return new FSReadonlyGraph<TCell>(new SimpleNodeReader<TCell>(myIndexFile.Reader(), myOutputFile, myPersist), mySystem, myNodesCount, myEdgesCount);
    }
  }
}