using System;
using System.IO;
using JetBrains.Annotations;

namespace DSIS.Persistance.Streams
{
  public static class StreamUtilities
  {
    public static IInputStream asInputStream([NotNull] this Stream stream, [CanBeNull] Action dispose)
    {
      if (stream == null) throw new ArgumentNullException("stream");
      if (!stream.CanRead) throw new ArgumentException("Stream should be writable", "stream");

      return new InputStreamImpl(stream, dispose);
    }

    public static IOutputStream asOutputStream([NotNull] this Stream stream, [CanBeNull] Action dispose)
    {
      if (stream == null) throw new ArgumentNullException("stream");
      if (!stream.CanWrite) throw new ArgumentException("Stream should be writable", "stream");

      return new OutputStreamImpl(stream, dispose);
    }
  }
}