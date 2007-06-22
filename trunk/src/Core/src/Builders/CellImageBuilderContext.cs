using DSIS.Core.Coordinates;
using DSIS.Core.System;

namespace DSIS.Core.Builders
{
  public struct CellImageBuilderContext<TCell> where TCell : ICellCoordinate<TCell>
  {
    private readonly IDiscreteSystemInfo myFunction;
    private readonly ICellImageBuilderSettings mySettings;
    private readonly ICellCoordinateSystem<TCell> mySystem;
    private readonly ICellConnectionBuilder<TCell> myConnectionBuilder;

    public CellImageBuilderContext(IDiscreteSystemInfo function, ICellImageBuilderSettings settings,
                                   ICellCoordinateSystem<TCell> system, ICellConnectionBuilder<TCell> connectionBuilder)
    {
      myFunction = function;
      mySettings = settings;
      mySystem = system;
      myConnectionBuilder = connectionBuilder;
    }

    public IDiscreteSystemInfo Function
    {
      get { return myFunction; }
    }

    public ICellImageBuilderSettings Settings
    {
      get { return mySettings; }
    }

    public ICellCoordinateSystem<TCell> System
    {
      get { return mySystem; }
    }

    public ICellConnectionBuilder<TCell> ConnectionBuilder
    {
      get { return myConnectionBuilder; }
    }
  }
}