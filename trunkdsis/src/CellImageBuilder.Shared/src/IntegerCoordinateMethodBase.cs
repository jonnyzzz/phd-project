using DSIS.Core.Builders;
using DSIS.IntegerCoordinates;

namespace DSIS.CellImageBuilder.Shared
{
  public abstract class IntegerCoordinateMethodBase<T, Q> 
    where T : IIntegerCoordinateSystem<Q>
    where Q : IIntegerCoordinate<Q>
  {
    protected T mySystem;
    protected ICellConnectionBuilder<Q> myBuilder;
    protected int myDim;

    public virtual void Bind(CellImageBuilderContext<Q> context)
    {
      mySystem = (T) context.System;
      myBuilder = context.ConnectionBuilder;
      myDim = context.System.SystemSpace.Dimension;
    }
  }
}