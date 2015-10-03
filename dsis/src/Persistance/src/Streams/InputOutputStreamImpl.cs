using System;
using System.IO;

namespace DSIS.Persistance.Streams
{
  public class InputOutputStreamImpl<S> : StreamImpl<S>, IInputOutputStream
    where S : Stream
  {
    public InputOutputStreamImpl(S stream, Action<S> dispose) : base(stream, dispose)
    {
    }
  }
}