using System.Collections.Generic;
using System.IO;
using DSIS.Persistance.Streams;

namespace DSIS.Graph.FS
{
  public class MemoryFSGraphResourceManagerImpl : IFSGraphResourceManager
  {
    private readonly Dictionary<IOutputStream, MemoryStream> myStreams = new Dictionary<IOutputStream, MemoryStream>();
    
    public IOutputStream CreateWriteStream(string name)
    {
      var memoryStream = new MemoryStream();
      var ws = memoryStream.AsOutputStream(x=>x.Flush());
      myStreams[ws] = memoryStream;
      return ws;
    }

    public IInputStream CreateReadStream(IOutputStream stream)
    {
      var s = myStreams[stream];
      myStreams.Remove(stream);
      return s.AsInputStream(x => x.Dispose());
    }
  }
}