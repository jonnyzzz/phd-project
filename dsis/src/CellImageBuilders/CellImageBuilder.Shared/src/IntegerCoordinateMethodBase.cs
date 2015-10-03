using DSIS.Core.Builders;
using DSIS.IntegerCoordinates;

namespace DSIS.CellImageBuilder.Shared
{
  public abstract class IntegerCoordinateMethodBase<Q>     
    where Q : IIntegerCoordinate
  {
    protected IIntegerCoordinateSystem<Q> mySystem;
    protected ICellConnectionBuilder<Q> myBuilder;
    protected int myDim;
    private string myPresentableName;

    public virtual void Bind(CellImageBuilderContext<Q> context)
    {
      mySystem = (IIntegerCoordinateSystem<Q>)context.System;
      myBuilder = context.ConnectionBuilder;
      myDim = context.System.Dimension;
      myPresentableName = context.Settings.PresentableName;
    }

    public virtual string PresentableName
    {
      get { return myPresentableName; }
    }
  }
}