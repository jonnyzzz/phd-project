using System.IO;
using EugenePetrenko.Shared.Core.Ioc.Api;

namespace DSIS.Persistance
{
  [ComponentImplementation]
  public class PersistanceFactory : IPersistanceFactory
  {
    public IBinaryWriter CreateWriter(string file)
    {
      return new BinaryWriterImpl(new BinaryWriter(File.Create(file)));
    }

    public IBinaryReader CreateReader(string file)
    {
      return new BinaryReaderImpl(new BinaryReader(File.OpenRead(file)));
    }
  }
}