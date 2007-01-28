using DSIS.Core.Coordinates;
using DSIS.IntegerCoordinates;

namespace DSIS.CellImageBuilder.Shared
{
  public abstract class IntegerCoordinateMethodBase
  {
    protected IIntegerCoordinateSystem mySystem;
    protected ICellConnectionBuilder<IntegerCoordinate> myBuilder;
    protected IIntegerCoordinateCellImageBuilderAdapter myAdapter;
    protected int myDim;


    public virtual void Bind(CellImageBuilderContext<IntegerCoordinate> context)
    {
      mySystem = (IIntegerCoordinateSystem)context.System;
      myBuilder = context.ConnectionBuilder;
      myAdapter = mySystem.CreateAdapter(myBuilder);
      myDim = context.System.SystemSpace.Dimension;
    }
  }
}
