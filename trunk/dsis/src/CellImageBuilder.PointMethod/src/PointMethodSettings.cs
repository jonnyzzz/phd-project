using System;
using DSIS.CellImageBuilder.Shared;
using DSIS.Core.Builders;
using DSIS.IntegerCoordinates;
using DSIS.Utils;
using DSIS.Utils.Bean;

namespace DSIS.CellImageBuilder.PointMethod
{
  [Serializable]
  public class PointMethodSettings : ICellImageBuilderIntegerCoordinatesSettings
  {
    [IncludeGenerate(Title = "Number of point on each axis")]
    public int Points { get; set;}
    [IncludeGenerate(Title = "Use overlapping")]
    public bool UseOverlapping { get; set;}
    [IncludeGenerate(Title = "Relative overlap value", Description = "1.0 means full cell size. By degault 0.2")]
    public double Overlap { get; set;}

    [Used]
    public PointMethodSettings()
    {
      Points = 3;
      UseOverlapping = false;
      Overlap = 0.2;
    }

    public string PresentableName
    {
      get { return string.Format("Point Method[{0}{1}]", Points, (UseOverlapping ? ",overlap=" + Overlap : "")); }
    }

    public ICellImageBuilder<TCell> Create<TCell>()       
      where TCell : IIntegerCoordinate
    {
      return new PointMethod<TCell>();
    }
  }
}