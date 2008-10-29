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
    public int[] Points { get; set;}
    [IncludeGenerate(Title = "Use overlapping")]
    public bool UseOverlapping { get; set;}
    [IncludeGenerate(Title = "Relative overlap value", Description = "1.0 means full cell size. By degault 0.2")]
    public double Overlap { get; set;}

    [Used]
    public PointMethodSettings()
    {
    }

    public PointMethodSettings(int[] points)
    {
      Points = points;
      UseOverlapping = false;
      Overlap = 0;
    }

    public PointMethodSettings(int[] points, double overlap)
    {
      Points = points;
      Overlap = overlap;
      UseOverlapping = false;
    }

    public string PresentableName
    {
      get { return string.Format("Point Method[{0}{1}]", Points.JoinString(","), (UseOverlapping ? ",overlap=" + Overlap : "")); }
    }

    public ICellImageBuilder<TCell> Create<TCell>()       
      where TCell : IIntegerCoordinate
    {
      return new PointMethod<TCell>();
    }
  }
}