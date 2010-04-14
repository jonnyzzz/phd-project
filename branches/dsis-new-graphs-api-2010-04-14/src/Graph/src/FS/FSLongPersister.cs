using DSIS.Persistance.Streams;
using DSIS.Utils;

namespace DSIS.Graph.FS
{
  public class FSLongPersister : IFSObjectPersister<long>
  {
    public long LoadObject(IInputStreamData stream)
    {
      byte[] b = new byte[LongConverter.Size];
      stream.Read(b, 0, LongConverter.Size);
      return LongConverter.FromBytes(b, 0);
    }

    public void SaveObject(IOutputStreamData stream, long obj)
    {
      stream.Write(LongConverter.ToBytes(obj), 0, LongConverter.Size);
    }

    public long Size
    {
      get { return LongConverter.Size; }
    }
  }
}