namespace DSIS.Persistance.Streams
{
  public interface IInputStreamData
  {
    int Read(byte[] buffer, int offset, int count);
  }

  public interface IInputStream : IStream, IInputStreamData
  {
    long Position { get;  set; }
    long Length { get; }
    
  }
}