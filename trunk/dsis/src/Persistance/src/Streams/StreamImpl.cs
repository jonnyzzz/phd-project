using System;
using System.IO;

namespace DSIS.Persistance.Streams
{
  public class StreamImpl<S> : IStream where S : Stream
  {
    private readonly S myStream;
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

    public int Read(byte[] buffer, int offset, int count)
    {
      return myStream.Read(buffer, offset, count);
    }

    public void Write(byte[] buffer, int offset, int count)
    {
      myStream.Write(buffer, offset, count);
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