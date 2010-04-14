namespace DSIS.Persistance.Streams
{
  public interface IInputOutputStream : IInputStreamData, IOutputStreamData, IStream
  {
    long Position { get; set; }
    long Length { get; }
  }
}