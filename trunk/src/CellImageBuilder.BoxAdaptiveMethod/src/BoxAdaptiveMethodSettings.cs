using DSIS.Core.Coordinates;

namespace DSIS.CellImageBuilder.BoxAdaptiveMethod
{
  public enum BoxAdaptiveMethodStategy
  {
    Simple
  }

  public class BoxAdaptiveMethodSettings : ICellImageBuilderSettings
  {
    public static readonly BoxAdaptiveMethodSettings Default = new BoxAdaptiveMethodSettings();

    private readonly int myTaskLimit = 63;
    private readonly BoxAdaptiveMethodStategy myStategy = BoxAdaptiveMethodStategy.Simple;
    private readonly double myOverlaping = 0.2;
    private readonly double myCellSizePercent = 0.3;

    public BoxAdaptiveMethodSettings(int taskLimit, BoxAdaptiveMethodStategy stategy, double overlaping)
    {
      myTaskLimit = taskLimit;
      myStategy = stategy;
      myOverlaping = overlaping;
    }
    
    public BoxAdaptiveMethodSettings(int taskLimit, BoxAdaptiveMethodStategy stategy, double overlaping, double cellSizePercent)
    {
      myTaskLimit = taskLimit;
      myStategy = stategy;
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

    public BoxAdaptiveMethodStategy WorkItemStrategy
    {
      get { return myStategy; }
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