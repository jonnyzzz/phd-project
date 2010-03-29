using System;
using System.Collections.Generic;
using System.IO;
using DSIS.Persistance.Streams;
using DSIS.Utils;

namespace DSIS.Graph.FS
{
  public class MemoryFSGraphResourceManagerImpl : IFSGraphResourceManager
  {
    private readonly Dictionary<IOutputStream, Pair<MemoryStream, string>> myStreams = new Dictionary<IOutputStream, Pair<MemoryStream, string>>();

    public event Action<MemoryStream, string> OnStreamWritten;

    public IOutputStream CreateWriteStream(string name)
    {
      var memoryStream = new MemoryStream();
      var ws = memoryStream.AsOutputStream(x=>x.Flush());
      myStreams[ws] = Pair.Of(memoryStream, name);
      return ws;
    }

    public IInputStream CreateReadStream(IOutputStream stream)
    {
      var s = myStreams[stream];
      if (OnStreamWritten != null)
        OnStreamWritten(s.First, s.Second);

      myStreams.Remove(stream);
      return s.First.AsInputStream(x => x.Dispose());
    }

    public IInputOutputStream CreateIOStream(string name)
    {
      return new MemoryStream().AsInputOutputStream(x => x.Close());
    }
  }
}