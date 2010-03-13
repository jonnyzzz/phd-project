﻿using System;
using System.Collections.Generic;
using DSIS.Persistance.Streams;
using DSIS.Utils;

namespace DSIS.Graph.FS
{
  public class IndexInputStream : IDisposable
  {
    private readonly long myCount;
    private readonly IInputStream myInputStream;

    public IndexInputStream(IInputStream inputStream)
    {
      myInputStream = inputStream;
      myInputStream.Position = myInputStream.Length - LongConverter.Size;
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
      var buff = new byte[LongConverter.Size];
      myInputStream.Read(buff, 0, buff.Length);
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
      myInputStream.Position = 0;
      for (var i = 0; i < myCount; i++)
      {
        yield return ReadIndex();
      }
    }

    public IndexEntry GetAt(long index)
    {
      //TODO: No checks are done here!
      myInputStream.Position = LongConverter.Size*index;
      return ReadIndex();
    }
  }
}