using System;
using System.IO;
using JetBrains.Annotations;

namespace DSIS.Persistance.Streams
{
  public static class StreamUtilities
  {
    public static IInputStream AsInputStream<S>([NotNull] this S stream, [CanBeNull] Action<S> dispose)
      where S : Stream
    {
      if (stream == null) throw new ArgumentNullException("stream");
      if (!stream.CanRead) throw new ArgumentException("Stream should be writable", "stream");

      return new InputStreamImpl<S>(stream, dispose);
    }

    public static IOutputStream AsOutputStream<S>([NotNull] this S stream, [CanBeNull] Action<S> dispose)
      where S : Stream
    {
      if (stream == null) throw new ArgumentNullException("stream");
      if (!stream.CanWrite) throw new ArgumentException("Stream should be writable", "stream");

      return new OutputStreamImpl<S>(stream, dispose);
    }
  }
}