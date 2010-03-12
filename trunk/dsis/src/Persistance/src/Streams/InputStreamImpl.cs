using System;
using System.IO;

namespace DSIS.Persistance.Streams
{
  public class InputStreamImpl : StreamImpl, IInputStream
  {
    public InputStreamImpl(Stream stream, Action dispose) : base(stream, dispose)
    {
    }

    public int Read(byte[] buffer, int offset, int count)
    {
      return myStream.Read(buffer, offset, count);
    }
  }
}