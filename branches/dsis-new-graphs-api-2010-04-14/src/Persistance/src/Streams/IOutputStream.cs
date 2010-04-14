namespace DSIS.Persistance.Streams
{
  public interface IOutputStreamData
  {
    void Write(byte[] buffer, int offset, int count);
  }

  public interface IOutputStream : IStream, IOutputStreamData
  {
    long Position { get; }
  }
}