using System.IO;

namespace DSIS.Persistance
{
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