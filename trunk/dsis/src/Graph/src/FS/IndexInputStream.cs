using System;
using System.Collections.Generic;
using System.IO;
using DSIS.Utils;

namespace DSIS.Graph.FS
{
  public class IndexInputStream : IDisposable
  {
    private readonly long myCount;
    private readonly Stream myInputStream;

    public IndexInputStream(Stream inputStream)
    {
      myInputStream = inputStream;
      myInputStream.Seek(-8, SeekOrigin.End);
      myCount = ReadLong();
    }

    #region IDisposable Members

    public void Dispose()
    {
      myInputStream.Dispose();
    }

    #endregion

    private long ReadLong()
    {
      var buff = new byte[8];
      myInputStream.Read(buff, 0, 8);
      return LongConverter.FromBytes(buff);
    }

    private IndexEntry ReadIndex()
    {
      return new IndexEntry
               {
                 Begin = ReadLong(),
                 Data = ReadLong()
               };
    }


    public IEnumerable<IndexEntry> ReadData()
    {
      myInputStream.Seek(0, SeekOrigin.Begin);
      for (var i = 0; i < myCount; i++)
      {
        yield return ReadIndex();
      }
    }

    public IndexEntry GetAt(long index)
    {
      //TODO: No checks are done here!
      myInputStream.Seek(16*index, SeekOrigin.Begin);
      return ReadIndex();
    }
  }
}