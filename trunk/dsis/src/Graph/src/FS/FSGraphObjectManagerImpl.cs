using System.Collections.Generic;
using DSIS.Core.Coordinates;
using DSIS.Persistance.Streams;

namespace DSIS.Graph.FS
{
  public class FSGraphObjectManagerImpl : IFSGraphObjectManager
  {
    private readonly IFSGraphResourceManager myResources;

    public FSGraphObjectManagerImpl(IFSGraphResourceManager resources)
    {
      myResources = resources;
    }

    public IOutputStream CreateNodesWriteStream()
    {
      return myResources.CreateWriteStream("nodes");
    }

    public IIndexOutputStream CreateIndexOutputStream()
    {
      return new IndexOutputStream(myResources.CreateWriteStream("raw-index"));
    }

    public SimpleNodeReader<TCell> CreateNodeReader<TCell>(IOutputStream nodesOutputStream,
                                                           ICellCoordinateSystemPersist<TCell> persist,
                                                           IEqualityComparer<TCell> comparer)
      where TCell : ICellCoordinate
    {
      nodesOutputStream.Dispose();
      return new SimpleNodeReader<TCell>(myResources.CreateReadStream(nodesOutputStream), persist);
    }

    public IFSNodeIndex<TCell> CreateNodeIndex<TCell>(IIndexOutputStream indexInputStream,
                                                      SimpleNodeReader<TCell> reader,
                                                      ICellCoordinateSystemPersist<TCell> persist,
                                                      IEqualityComparer<TCell> comparer) where TCell : ICellCoordinate
    {
      var idx = new FSNodeInMemoryIndexImpl<TCell>(comparer);
      indexInputStream.Dispose();
      var stream = ((IndexOutputStream) indexInputStream).OutputStream;
      using (var i = new IndexInputStream(myResources.CreateReadStream(stream)))
      {
        idx.LoadIndex(i, reader);
      }
      return idx;
    }
  }
}