using DSIS.Core.System;
using DSIS.IntegerCoordinates;
using DSIS.IntegerCoordinates.Impl;

namespace DSIS.Scheme.Impl.Actions
{
  public class CreateRealCoordinateSystemAction : CreateCoordinateSystemActionBase
  {
    protected override IIntegerCoordinateSystem CreateSystem(ISystemSpace info)
    {
      return new IntegerCoordinateSystem(info, info.InitialSubdivision);
    }
  }
}