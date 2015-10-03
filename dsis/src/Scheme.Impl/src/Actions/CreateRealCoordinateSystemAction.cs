using DSIS.Core.System;
using DSIS.IntegerCoordinates;
using DSIS.IntegerCoordinates.Impl;
using DSIS.Utils;

namespace DSIS.Scheme.Impl.Actions
{
  [Used]
  public class CreateRealCoordinateSystemAction : CreateCoordinateSystemActionBase
  {
    protected override IIntegerCoordinateSystem CreateSystem(ISystemSpace info)
    {
      return new IntegerCoordinateSystem(info, info.InitialSubdivision);
    }
  }
}