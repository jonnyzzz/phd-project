using DSIS.Core.Builders;
using DSIS.IntegerCoordinates;

namespace DSIS.CellImageBuilder.Shared
{
  public abstract class IntegerCoordinateMethodBase
  {
    protected IntegerCoordinateSystem mySystem;
    protected ICellConnectionBuilder<IntegerCoordinate> myBuilder;
    protected int myDim;

    public virtual void Bind(CellImageBuilderContext<IntegerCoordinate> context)
    {
      mySystem = (IntegerCoordinateSystem) context.System;
      myBuilder = context.ConnectionBuilder;
      myDim = context.System.SystemSpace.Dimension;
    }
  }
}