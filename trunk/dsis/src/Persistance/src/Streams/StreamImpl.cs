using System;
using System.IO;

namespace DSIS.Persistance.Streams
{
  public class StreamImpl : IStream
  {
    protected readonly Stream myStream;
    private readonly Action myDispose;

    protected StreamImpl(Stream stream, Action dispose)
    {
      myStream = stream;
      myDispose = dispose;
    }

    public void Dispose()
    {
      myDispose();
    }

    public long Position
    {
      get { return myStream.Position; }
      set { myStream.Position = value; }
    }

    public long Length
    {
      get { return myStream.Length; }
    }
  }
}