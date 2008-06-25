using System;
using DSIS.Core.System;
using DSIS.Persistance;
using DSIS.Spring.Attributes;

namespace DSIS.IntegerCoordinates.Generated
{
  [SpringBean]
  public class IntegerCoordinatePersistance : IPersistance<IIntegerCoordinateSystemInfo>
  {
    private readonly IPersistance<ISystemSpace> mySpacePersistance;
    private readonly GeneratedIntegerCoordinateSystemManager myManager;

    public IntegerCoordinatePersistance(IPersistance<ISystemSpace> spacePersistance, GeneratedIntegerCoordinateSystemManager manager)
    {
      mySpacePersistance = spacePersistance;
      myManager = manager;
    }

    private static string SerializeKey()
    {
      return "INTEGER_COORDINATE_GENERATED";
    }

    public IIntegerCoordinateSystemInfo Load(IBinaryReader reader)
    {
      if (SerializeKey() != reader.ReadString())
        throw new ArgumentException("Failed to load. String token was not found");

      int dim = reader.ReadInt();

      IIntegerCoordinateFactoryEx factory = myManager.CreateSystem(dim);

      var space = mySpacePersistance.Load(reader);
      return factory.Create(space, space.InitialSubdivision);
    }

    public void Save(IIntegerCoordinateSystemInfo info, IBinaryWriter writer)
    {
      writer.WriteString(SerializeKey());

      writer.WriteInt(info.Dimension);

      mySpacePersistance.Save(info.SystemSpace, writer);
    }

  }
}