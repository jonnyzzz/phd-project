using System.Collections.Generic;
using DSIS.Persistance.Streams;
using DSIS.Utils;

namespace DSIS.Graph.FS
{
  public class IndexInputStream : IIndexInputStream
  {
    private readonly long myCount;
    private readonly IInputStream myInputStream;

    public IndexInputStream(IInputStream inputStream)
    {
      myInputStream = inputStream;
      myInputStream.Position = myInputStream.Length - LongConverter.Size;
      myCount = ReadLong();
    }

    public void Dispose()
    {
      myInputStream.Dispose();
    }

    private long ReadLong()
    {
      var buff = new byte[LongConverter.Size];
      myInputStream.Read(buff, 0, buff.Length);
      return LongConverter.FromBytes(buff, 0);
    }

    private IndexEntry ReadIndex(long id)
    {
      return new IndexEntry
               {
                 EntryId = id,
                 Begin = ReadLong(),
                 Data = ReadLong()
               };
    }


    public IEnumerable<IndexEntry> ReadData()
    {
      myInputStream.Position = 0;
      for (var i = 0; i < myCount; i++)
      {
        yield return ReadIndex(i);
      }
    }

    public long Count
    {
      get { return myCount; }
    }

    public IndexEntry GetAt(long index)
    {
      myInputStream.Position = LongConverter.Size*index;
      var indexEntry = ReadIndex(index);
      return indexEntry;
    }
  }
}