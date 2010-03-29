using System;
using System.IO;

namespace DSIS.Persistance.Streams
{
  public class OutputStreamImpl<S> : StreamImpl<S>, IOutputStream
    where S : Stream
  {
    public OutputStreamImpl(S stream, Action<S> dispose) : base(stream, dispose)
    {
    }
  }
}