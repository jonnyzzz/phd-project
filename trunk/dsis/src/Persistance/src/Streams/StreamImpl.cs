using System;
using System.IO;

namespace DSIS.Persistance.Streams
{
  public class StreamImpl<S> : IStream where S : Stream
  {
    protected readonly S myStream;
    private readonly Action<S> myDispose;

    protected StreamImpl(S stream, Action<S> dispose)
    {
      myStream = stream;
      myDispose = dispose;
    }

    public void Dispose()
    {
      myDispose(myStream);
    }

    public long Position
    {
      get
      {
        myStream.Flush();
        return myStream.Position;
      }
      set
      {
        myStream.Position = value;
      }
    }

    public long Length
    {
      get { return myStream.Length; }
    }
  }
}