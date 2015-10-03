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
    public int TaskLimit { get; set;}
    [IncludeGenerate(Title = "Overlap")]
    public double Overlaping { get; set; }
    [IncludeGenerate(Title = "Cell size percentage")]
    public double CellSizePercent { get; set; }
    [IncludeGenerate(Title = "Add radius factory")]
    public double AddRadiusFactor { get; set; }

    [Obsolete]
    public BoxAdaptiveMethodSettings(int taskLimit, double overlaping) : this()
    {
      TaskLimit = taskLimit;
      Overlaping = overlaping;
    }

    public BoxAdaptiveMethodSettings()
    {
      AddRadiusFactor = 0.7;
      CellSizePercent = 0.7;
      Overlaping = 0.2;
      TaskLimit = 500;
    }

    public string PresentableName
    {
      get { return string.Format("Box Addaptive[overlap={0},radius={1},limit={2},sz={3}]", Overlaping,  AddRadiusFactor, TaskLimit, CellSizePercent); }
    }

    public ICellImageBuilder<TCell> Create<TCell>()
      where TCell : IIntegerCoordinate
    {
      return new BoxAdaptiveMethod<TCell>();
    }
  }
}