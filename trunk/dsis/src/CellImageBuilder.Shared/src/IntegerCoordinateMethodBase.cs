using DSIS.Core.Builders;
using DSIS.Core.Coordinates;
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


  /// <summary>
  /// Base Interface for cell Image Builder settings. 
  /// No common parameters. Used as the base interface 
  /// for the hierarchy
  /// </summary>
  public interface ICellImageBuilderIntegerCoordinatesSettings : ICellImageBuilderSettings
  {
    ICellImageBuilder<TCell> Create<TSys, TCell>()
      where TSys : IIntegerCoordinateSystem<TCell>
      where TCell : IIntegerCoordinate<TCell>;
  }
}