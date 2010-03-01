using System;
using System.IO;

namespace DSIS.Graph.FS
{
  public class FSBlocker : IDisposable
  {
    private readonly string myFilePath;
    private readonly int blockSize;
    private readonly Stream myStream;

    public FSBlocker(string myFilePath, int blockSize)
    {
      this.myFilePath = myFilePath;
      this.blockSize = blockSize;

      myStream = new FileStream(myFilePath, FileMode.Create, FileAccess.ReadWrite, FileShare.Read);

      if (!myStream.CanSeek)
      {
        throw new IOException("Stream should support seek");
      }
    }

    public void WriteBlock(int offset, byte[] block)
    {
      
    }

    public byte[] ReadBlock(int offset)
    {
      return null;
    }

    public void Dispose()
    {
      myStream.Close();
    }
  }
}