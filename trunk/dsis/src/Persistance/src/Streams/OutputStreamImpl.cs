using System;
using System.IO;

namespace DSIS.Persistance.Streams
{
  public class OutputStreamImpl : StreamImpl, IOutputStream
  {
    public OutputStreamImpl(Stream stream, Action dispose) : base(stream, dispose)
    {
    }

    public void Write(byte[] buffer, int offset, int count)
    {
      myStream.Write(buffer, offset, count);
    }
  }
}