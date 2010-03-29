using DSIS.Persistance.Streams;

namespace DSIS.Graph.FS
{
  public interface IFSObjectPersister<TObj>
  {
    TObj LoadObject(IInputStreamData stream);
    void SaveObject(IOutputStreamData stream, TObj obj);

    long Size { get; }
  }
}