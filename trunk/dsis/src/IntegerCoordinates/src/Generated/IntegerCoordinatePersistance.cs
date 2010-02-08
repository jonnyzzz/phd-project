using System;
using DSIS.Core.Ioc;
using DSIS.Core.System;
using DSIS.Persistance;

namespace DSIS.IntegerCoordinates.Generated
{
  [SpringBean]
  public class IntegerCoordinatePersistance : IPersistance<IIntegerCoordinateSystem>
  {
    private readonly IPersistance<ISystemSpace> mySpacePersistance;
    private readonly GeneratedIntegerCoordinateFactory myManager;

    public IntegerCoordinatePersistance(IPersistance<ISystemSpace> spacePersistance, GeneratedIntegerCoordinateFactory manager)
    {
      mySpacePersistance = spacePersistance;
      myManager = manager;
    }

    private static string SerializeKey()
    {
      return "INTEGER_COORDINATE_GENERATED";
    }

    public IIntegerCoordinateSystem Load(IBinaryReader reader)
    {
      if (SerializeKey() != reader.ReadString())
        throw new ArgumentException("Failed to load. String token was not found");

      //This is for compatibility
      reader.ReadInt();

      var space = mySpacePersistance.Load(reader);
      return myManager.Create(space, space.InitialSubdivision);
    }

    public void Save(IIntegerCoordinateSystem info, IBinaryWriter writer)
    {
      writer.WriteString(SerializeKey());

      writer.WriteInt(info.Dimension);

      mySpacePersistance.Save(info.SystemSpace, writer);
    }

  }
}