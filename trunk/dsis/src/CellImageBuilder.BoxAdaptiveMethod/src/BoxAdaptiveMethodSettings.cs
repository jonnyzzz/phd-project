using System;
using DSIS.CellImageBuilder.Shared;
using DSIS.Core.Builders;
using DSIS.IntegerCoordinates;
using DSIS.Utils.Bean;

namespace DSIS.CellImageBuilder.BoxAdaptiveMethod
{
  [Serializable]
  public class BoxAdaptiveMethodSettings : ICellImageBuilderIntegerCoordinatesSettings
  {
    public static readonly BoxAdaptiveMethodSettings Default = new BoxAdaptiveMethodSettings();

    [IncludeGenerate(Title = "Subdivision limit")]
    public int myTaskLimit { get; set;}
    [IncludeGenerate(Title = "Overlap")]
    public double myOverlaping { get; set; }
    [IncludeGenerate(Title = "Cell size percentage")]
    public double myCellSizePercent { get; set; }
    [IncludeGenerate(Title = "Add radius factory")]
    public double myAddRadiusFactor { get; set; }

    public BoxAdaptiveMethodSettings(int taskLimit, double overlaping) : this()
    {
      myAddRadiusFactor = 0.7;
      myCellSizePercent = 0.7;
      myOverlaping = 0.2;
      myTaskLimit = 200;
      myTaskLimit = taskLimit;
      myOverlaping = overlaping;
    }

    public BoxAdaptiveMethodSettings()
    {
      myAddRadiusFactor = 0.7;
      myCellSizePercent = 0.7;
      myOverlaping = 0.2;
      myTaskLimit = 200;
    }

    public BoxAdaptiveMethodSettings(int taskLimit, double overlaping, double cellSizePercent) : this()
    {
      myAddRadiusFactor = 0.7;
      myCellSizePercent = 0.7;
      myOverlaping = 0.2;
      myTaskLimit = 200;
      myTaskLimit = taskLimit;
      myOverlaping = overlaping;
      myCellSizePercent = cellSizePercent;
    }

    public BoxAdaptiveMethodSettings(int taskLimit, double overlaping, double cellSizePercent, double addRadiusFactor)
    {
      myAddRadiusFactor = 0.7;
      myCellSizePercent = 0.7;
      myOverlaping = 0.2;
      myTaskLimit = 200;
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

    public string PresentableName
    {
      get { return "Box Addaptive Method"; }
    }

    public ICellImageBuilder<TCell> Create<TCell>()
      where TCell : IIntegerCoordinate
    {
      return new BoxAdaptiveMethod<TCell>();
    }
  }
}