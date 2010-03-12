using System;

namespace DSIS.Persistance.Streams
{
  public interface IStream : IDisposable
  {
    long Position { get; set; }
    long Length { get; }
  }
}