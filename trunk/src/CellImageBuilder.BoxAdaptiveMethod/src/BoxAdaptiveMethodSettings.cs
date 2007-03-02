using DSIS.Core.Coordinates;

namespace DSIS.CellImageBuilder.BoxAdaptiveMethod
{
  public class BoxAdaptiveMethodSettings : ICellImageBuilderSettings
  {
    public static readonly BoxAdaptiveMethodSettings Default = new BoxAdaptiveMethodSettings();

    private readonly int myTaskLimit = 200;
    private readonly double myOverlaping = 0.2;
    private readonly double myCellSizePercent = 0.7;

    public BoxAdaptiveMethodSettings(int taskLimit, double overlaping)
    {
      myTaskLimit = taskLimit;
      myOverlaping = overlaping;
    }

    public BoxAdaptiveMethodSettings(int taskLimit, double overlaping, double cellSizePercent)
    {
      myTaskLimit = taskLimit;
      myOverlaping = overlaping;
      myCellSizePercent = cellSizePercent;
    }

    public BoxAdaptiveMethodSettings()
    {
    }

    public int TaskLimit
    {
      get { return myTaskLimit; }
    }

    public double Overlaping
    {
      get { return myOverlaping; }
    }

    public double CellSizePercent
    {
      get { return myCellSizePercent; }
    }
  }
}