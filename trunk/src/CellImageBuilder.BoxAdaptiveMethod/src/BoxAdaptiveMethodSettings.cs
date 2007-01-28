using DSIS.Core.Coordinates;

namespace DSIS.CellImageBuilder.BoxAdaptiveMethod
{
  public enum BoxAdaptiveMethodStategy
  {
    Simple
  }

  public class BoxAdaptiveMethodSettings : ICellImageBuilderSettings
  {
    public static readonly BoxAdaptiveMethodSettings Default = new BoxAdaptiveMethodSettings(65535, BoxAdaptiveMethodStategy.Simple, 0.2);

    private readonly int myTaskLimit;
    private readonly BoxAdaptiveMethodStategy myStategy;
    private readonly double myOverlaping;

    public BoxAdaptiveMethodSettings(int taskLimit, BoxAdaptiveMethodStategy stategy, double overlaping)
    {
      myTaskLimit = taskLimit;
      myStategy = stategy;
      myOverlaping = overlaping;
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
  }
}