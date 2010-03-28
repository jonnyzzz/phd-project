using System.IO;
using DSIS.Utils;
using DSIS.Persistance.Streams;

namespace DSIS.Graph.FS
{
  public class IndexOutputStream : IIndexOutputStream
  {
    private readonly IOutputStream myOutputStream;
    private long myItemsCount;

    public IndexOutputStream(IOutputStream outputStream)
    {
      myOutputStream = outputStream;
    }

    public IOutputStream OutputStream
    {
      get { return myOutputStream; }
    }

    public void Dispose()
    {
      WriteLong(myItemsCount);
      myOutputStream.Dispose();
    }

    public void WriteBlockStartLocation(IndexEntry position)
    {
      myItemsCount++;
      WriteLong(position.Begin);
      WriteLong(position.Data);
    }

    private void WriteLong(long position)
    {
      var buffer = LongConverter.ToBytes(position);
      myOutputStream.Write(buffer, 0, buffer.Length);
    }
  }
}