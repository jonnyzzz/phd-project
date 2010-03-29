using System.Collections.Generic;
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
      var data = new FSData();
      data.Load(myInputStream);

      return new FSReadonlyNode<TCell>(id)
               {
                 Entry = entry,
                 IsSelfLoop = data.IsSelfLoop
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
        var read = myPersist.Load(myInputStream);

        long pos = myInputStream.Position;
        //Position may change here!
        yield return read;
        myInputStream.Position = pos;
      }
    }
  }
}