namespace DSIS.Persistance.Streams
{
  public interface IOutputStream : IStream
  {
    void Write(byte[] buffer, int offset, int count);
  }
}