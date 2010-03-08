using System.Collections.Generic;
using System.IO;
using System.Linq;
using DSIS.Core.Coordinates;

namespace DSIS.Graph.FS
{
  public class SimpleNodeReader<TCell> where TCell : ICellCoordinate
  {
    private readonly IndexInputStream myIndex;
    private readonly Stream myInputStream;
    private readonly ICellCoordinateSystemPersist<TCell> myPersist;
    
    public SimpleNodeReader(IndexInputStream index, Stream inputStream, ICellCoordinateSystemPersist<TCell> persist)
    {
      myIndex = index;
      myInputStream = inputStream;
      myPersist = persist;
    }

    public FSReadonlyNode<TCell> ReadNode(IndexEntry entry)
    {
      myInputStream.Seek(entry.Begin, SeekOrigin.Begin);
      TCell id = myPersist.Load(myInputStream);

      myInputStream.Seek(entry.Data, SeekOrigin.Begin);
      int d = myInputStream.ReadByte();

      return new FSReadonlyNode<TCell>(id)
               {
                 ComponentId = 0,
                 Entry = entry,
                 IsSelfLoop = d == 42
               };
    }

    public IEnumerable<TCell> ReadEdges(IndexEntry entry)
    {
      myInputStream.Seek(entry.Begin, SeekOrigin.Begin);
      //Skip self
      myPersist.Load(myInputStream);
      while(myInputStream.Position < entry.Data)
      {
        yield return myPersist.Load(myInputStream);
      }
    }

    public IEnumerable<FSReadonlyNode<TCell>> ReadAllNodes()
    {
      return myIndex.ReadData().Select(ReadNode);
    }
  }
}