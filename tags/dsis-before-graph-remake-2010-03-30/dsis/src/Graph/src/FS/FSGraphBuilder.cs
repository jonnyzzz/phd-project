using System;
using System.Collections.Generic;
using DSIS.Core.Coordinates;
using DSIS.Persistance.Streams;

namespace DSIS.Graph.FS
{
  public class FSGraphBuilder<TCell> : IGraphBuilder<TCell>, IGraghNodeWriter<TCell>
    where TCell : ICellCoordinate
  {
    private readonly IEqualityComparer<TCell> myComparer;

    private readonly ICellCoordinateSystemPersist<TCell> myPersist;
    private readonly IOutputStream myOutputFile;
    private readonly IIndexOutputStream myIndexFile;
    private readonly ICellCoordinateSystem<TCell> mySystem;
    private readonly IFSGraphObjectManager myResources;

    private bool myIsDisposed;
    private int myEdgesCount;
    private int myNodesCount;

    public FSGraphBuilder(ICellCoordinateSystemPersist<TCell> persist, ICellCoordinateSystem<TCell> system, IFSGraphObjectManager resources)
    {
      myPersist = persist;
      mySystem = system;
      myResources = resources;
      myOutputFile = myResources.CreateNodesWriteStream();
      myIndexFile = myResources.CreateIndexOutputStream();
      myComparer = system.Comparer;
    }

    public void Dispose()
    {
      if (!myIsDisposed)
      {
        myIsDisposed = true;
        myIndexFile.Dispose();
      }
    }

    public IGraghNodeWriter<TCell> GetWriter()
    {
      return this;
    }

    public void AddEdges(TCell from, IEnumerable<TCell> tos)
    {
      myNodesCount++;
      long beginPos = myOutputFile.Position;
      
      WriteNodeCoord(from);

      var set = new HashSet<TCell>(myComparer);
      set.UnionWith(tos);
      var isLoop = set.Contains(from);
      
      myEdgesCount += set.Count;

      foreach (var w in set)
        WriteNodeCoord(w);

      long dataPos = myOutputFile.Position;
      var data = new FSData{IsSelfLoop = isLoop};
      data.Save(myOutputFile);

      var indexEntry = new IndexEntry { Begin = beginPos, Data = dataPos };
//      Console.Out.WriteLine("gadd @ {2} : {0} --> {1}", (from), set.JoinString(x => x.ToString(), ", "), indexEntry);
      myIndexFile.WriteBlockStartLocation(indexEntry);
    }

    private void WriteNodeCoord(TCell node)
    {      
      myPersist.Save(myOutputFile, node);
    }

    public IReadonlyGraph<TCell> BuildFinished()
    {
      if (!myIsDisposed)
        throw new ArgumentException("Call Dispose first");

      var reader = myResources.CreateNodeReader(myOutputFile, myPersist, myComparer);

      var indexImpl = myResources.CreateNodeIndex(myIndexFile, reader, myPersist, myComparer);
      return new FSReadonlyGraph<TCell>(myResources, reader, mySystem, myNodesCount, myEdgesCount, indexImpl);
    }
  }
}