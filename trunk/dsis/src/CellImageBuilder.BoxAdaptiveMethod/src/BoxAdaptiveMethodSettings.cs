using DSIS.CellImageBuilder.Shared;
using DSIS.Core.Builders;
using DSIS.IntegerCoordinates;

namespace DSIS.CellImageBuilder.BoxAdaptiveMethod
{
  public class BoxAdaptiveMethodSettings : ICellImageBuilderIntegerCoordinatesSettings
  {
    public static readonly BoxAdaptiveMethodSettings Default = new BoxAdaptiveMethodSettings();

    private readonly int myTaskLimit = 200;
    private readonly double myOverlaping = 0.2;
    private readonly double myCellSizePercent = 0.7;
    private readonly double myAddRadiusFactor = 0.7;

    public BoxAdaptiveMethodSettings(int taskLimit, double overlaping)
    {
      myTaskLimit = taskLimit;
      myOverlaping = overlaping;
    }

    public BoxAdaptiveMethodSettings()
    {
    }

    public BoxAdaptiveMethodSettings(int taskLimit, double overlaping, double cellSizePercent)
    {
      myTaskLimit = taskLimit;
      myOverlaping = overlaping;
      myCellSizePercent = cellSizePercent;
    }

    public BoxAdaptiveMethodSettings(int taskLimit, double overlaping, double cellSizePercent, double addRadiusFactor)
    {
      myTaskLimit = taskLimit;
      myOverlaping = overlaping;
      myCellSizePercent = cellSizePercent;
      myAddRadiusFactor = addRadiusFactor;
    }

    public int TaskLimit
    {
      get { return myTaskLimit; }
    }

    public double AddRadiusFactor
    {
      get { return myAddRadiusFactor; }
    }

    public double Overlaping
    {
      get { return myOverlaping; }
    }

    public double CellSizePercent
    {
      get { return myCellSizePercent; }
    }

    public ICellImageBuilder<TCell> Create<TSys, TCell>() where TSys : IIntegerCoordinateSystem<TCell>
      where TCell : IIntegerCoordinate
    {
      return new BoxAdaptiveMethod<TSys, TCell>();
    }
  }
}