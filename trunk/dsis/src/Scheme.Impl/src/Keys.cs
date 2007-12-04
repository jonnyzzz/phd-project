using DSIS.CellImageBuilder.Shared;
using DSIS.Core.Coordinates;
using DSIS.Core.System;
using DSIS.Core.Util;
using DSIS.Graph;
using DSIS.IntegerCoordinates;
using DSIS.Scheme.Impl.Actions.Entropy;

namespace DSIS.Scheme.Impl
{
  public static class Keys
  {
    public static readonly Key<ISystemSpace> SystemSpaceKey = new Key<ISystemSpace>("SystemSpace");
    public static readonly Key<long[]> SubdivisionKey = new Key<long[]>("Subdivision");

    public static readonly Key<IIntegerCoordinateSystemInfo> IntegerCoordinateSystemInfo =
      new Key<IIntegerCoordinateSystemInfo>("Info");

    public static readonly Key<ISystemInfo> SystemInfoKey = new Key<ISystemInfo>("Function");

    public static readonly Key<ICellImageBuilderIntegerCoordinatesSettings> CellImageBuilderKey =
      new Key<ICellImageBuilderIntegerCoordinatesSettings>("Builder");

    public static Key<ICountEnumerable<Q>> CellsEnumerationKey<Q>()
      where Q : ICellCoordinate<Q>
    {
      return new Key<ICountEnumerable<Q>>("Cells");
    }

    public static Key<IGraphWithStrongComponent<Q>> Graph<Q>() where Q : ICellCoordinate<Q>
    {
      return new Key<IGraphWithStrongComponent<Q>>("graph");
    }

    public static Key<IGraphStrongComponents<Q>> GraphComponents<Q>() where Q : ICellCoordinate<Q>
    {
      return new Key<IGraphStrongComponents<Q>>("comps");
    }    

//    public static Key<StarangeEntropyActionParams> StrangeEntropyParamsKey = new Key<StarangeEntropyActionParams>("");
  }
}