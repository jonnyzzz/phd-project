namespace DSIS.Persistance.Streams
{
  public interface IInputStream : IStream
  {
    long Position { get;  set; }
    long Length { get; }
    int Read(byte[] buffer, int offset, int count);
  }
}