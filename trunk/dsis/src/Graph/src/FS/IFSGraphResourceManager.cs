using DSIS.Persistance.Streams;
using JetBrains.Annotations;

namespace DSIS.Graph.FS
{
  public interface IFSGraphResourceManager
  {
    [NotNull]
    IOutputStream CreateWriteStream(string name);

    [NotNull]
    IInputStream CreateReadStream([NotNull] IOutputStream stream);
  }
}