using System;
using System.IO;
using DSIS.Utils;
using DSIS.Persistance.Streams;

namespace DSIS.Graph.FS
{
  public class IndexOutputStream : IDisposable
  {
    private readonly Stream myOutputStream;
    private long myItemsCount;

    public IndexOutputStream(Stream outputStream)
    {
      myOutputStream = outputStream;
    }

    public void Dispose()
    {
      WriteLong(myItemsCount);
      myOutputStream.Flush();
    }

    public void WriteBlockStartLocation(IndexEntry position)
    {
      myItemsCount++;
      WriteLong(position.Begin);
      WriteLong(position.Data);
    }

    private void WriteLong(long position)
    {
      var buffer = LongConverter.ToBytes(position);
      myOutputStream.Write(buffer, 0, buffer.Length);
    }

    public IndexInputStream Reader()
    {
      myOutputStream.Flush();
      return new IndexInputStream(myOutputStream.asInputStream(myOutputStream.Dispose));
    }
  }
}