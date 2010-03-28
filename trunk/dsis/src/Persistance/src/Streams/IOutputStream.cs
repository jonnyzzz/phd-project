namespace DSIS.Persistance.Streams
{
  public interface IOutputStream : IStream
  {
    long Position { get; }
    
    void Write(byte[] buffer, int offset, int count);
  }
}