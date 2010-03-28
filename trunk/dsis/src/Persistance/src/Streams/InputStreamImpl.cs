using System;
using System.IO;

namespace DSIS.Persistance.Streams
{
  public class InputStreamImpl<S> : StreamImpl<S>, IInputStream
    where S : Stream
  {
    public InputStreamImpl(S stream, Action<S> dispose) : base(stream, dispose)
    {
    }

    public int Read(byte[] buffer, int offset, int count)
    {
      return myStream.Read(buffer, offset, count);
    }
  }
}