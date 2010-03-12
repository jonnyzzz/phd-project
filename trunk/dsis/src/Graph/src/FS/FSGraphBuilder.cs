using System;
using System.Collections.Generic;
using System.IO;
using DSIS.Core.Coordinates;
using DSIS.Persistance.Streams;

namespace DSIS.Graph.FS
{
  public class FSGraphBuilder<TCell> : IGraphBuilder<TCell>
    where TCell : ICellCoordinate
  {
    private readonly IEqualityComparer<TCell> myComparer;

    private readonly ICellCoordinateSystemPersist<TCell> myPersist;
    private readonly IOutputStream myOutputFile;
    private readonly IndexOutputStream myIndexFile;
    private readonly ICellCoordinateSystem<TCell> mySystem;
    private readonly Stream myStream;

    private bool myIsDisposed;
    private int myEdgesCount;
    private int myNodesCount;

    public FSGraphBuilder(ICellCoordinateSystemPersist<TCell> persist, Stream outputFile, IndexOutputStream index, ICellCoordinateSystem<TCell> system)
    {
      myPersist = persist;
      mySystem = system;
      myOutputFile = outputFile.asOutputStream(outputFile.Dispose);
      myIndexFile = index;
      myComparer = system.Comparer;
      myStream = outputFile;
    }

    public void Dispose()
    {
      if (!myIsDisposed)
      {
        myIsDisposed = true;
        myIndexFile.Dispose();
      }
    }

    public void AddEdges(TCell from, IEnumerable<TCell> tos)
    {
      myNodesCount++;
      var e = new IndexEntry {Begin = myOutputFile.Position};
      WriteNodeCoord(from);

      var set = new HashSet<TCell>(myComparer);
      set.UnionWith(tos);
      var isLoop = set.Contains(from);
      
      myEdgesCount += set.Count;

      foreach (var w in set)
        WriteNodeCoord(w);

      e.Data = myOutputFile.Position;
      if (isLoop)
        myOutputFile.Write(new byte[]{1}, 0, 1);

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
      
      return new FSReadonlyGraph<TCell>(new SimpleNodeReader<TCell>(myIndexFile.Reader(), myStream, myPersist), mySystem, myNodesCount, myEdgesCount);
    }
  }
}