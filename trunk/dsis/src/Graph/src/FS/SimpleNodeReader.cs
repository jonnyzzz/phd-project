using System.Collections.Generic;
using System.Linq;
using DSIS.Core.Coordinates;
using DSIS.Persistance.Streams;

namespace DSIS.Graph.FS
{
  public class SimpleNodeReader<TCell> where TCell : ICellCoordinate
  {
    private readonly IInputStream myInputStream;
    private readonly ICellCoordinateSystemPersist<TCell> myPersist;
    
    public SimpleNodeReader(IInputStream inputStream, ICellCoordinateSystemPersist<TCell> persist)
    {
      myInputStream = inputStream;
      myPersist = persist;
    }

    public FSReadonlyNode<TCell> ReadNode(IndexEntry entry)
    {
      TCell id = ReadCell(entry);

      myInputStream.Position = entry.Data;
      var d = new byte[1];
      myInputStream.Read(d, 0, 1);

      return new FSReadonlyNode<TCell>(id)
               {
                 ComponentId = 0,
                 Entry = entry,
                 IsSelfLoop = d[0] == 42
               };
    }

    public TCell ReadCell(IndexEntry entry)
    {
      myInputStream.Position = entry.Begin;
      return myPersist.Load(myInputStream);
    }

    public IEnumerable<TCell> ReadEdges(IndexEntry entry)
    {
      myInputStream.Position = entry.Begin;
      //Skip self
      myPersist.Load(myInputStream);
      while(myInputStream.Position < entry.Data)
      {
        yield return myPersist.Load(myInputStream);
      }
    }

    public IEnumerable<FSReadonlyNode<TCell>> ReadAllNodes(IEnumerable<IndexEntry> entries)
    {
      return entries.Select(ReadNode);
    }
  }
}