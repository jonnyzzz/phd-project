using System;
using System.IO;
using DSIS.Utils;

namespace DSIS.Graph.FS
{
  public class IndexOutputStream : IDisposable
  {
    private readonly Stream myOutputStream;
    private long myItemsCount = 0;

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
      myOutputStream.Write(LongConverter.ToBytes(position), 0, 8);
    }

    public IndexInputStream Reader()
    {
      myOutputStream.Flush();
      return new IndexInputStream(myOutputStream);
    }
  }
}