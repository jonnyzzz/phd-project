using System;
using System.Collections.Generic;
using System.IO;
using DSIS.Persistance.Streams;

namespace DSIS.Graph.FS
{
  public class SimpleFSGraphResourceManagerImpl : IFSGraphResourceManager
  {
    private readonly string myTempFolder;
    private readonly Dictionary<IOutputStream, string> myWriters = new Dictionary<IOutputStream, string>();

    public SimpleFSGraphResourceManagerImpl(string tempFolder)
    {
      myTempFolder = tempFolder;
    }

    private string AllocFilename(string name)
    {
      if (!Directory.Exists(myTempFolder))
        Directory.CreateDirectory(myTempFolder);

      string file = Path.Combine(myTempFolder, "stream-" + name + ".stream");
      if (!File.Exists(file))
        return file;

      while (true)
      {
        file = Path.Combine(myTempFolder, "stream-" + name + "-" + new Guid() + ".stream");
        if (!File.Exists(file))
          return file;
      }
    }

    public IOutputStream CreateWriteStream(string name)
    {
      var file = AllocFilename(name);
      var fileStream = File.OpenWrite(file);
      var stream = fileStream.AsOutputStream(x=>x.Close());
      myWriters[stream] = file;
      return stream;
    }

    public IInputStream CreateReadStream(IOutputStream stream)
    {
      var file = myWriters[stream];
      stream.Dispose();
      var fileStream = File.OpenRead(file);
      return fileStream.AsInputStream(x=>x.Close());
    }
  }
}