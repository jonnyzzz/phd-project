namespace DSIS.Persistance.Streams
{
  public interface IInputStream : IStream
  {
    int Read(byte[] buffer, int offset, int count);
  }
}