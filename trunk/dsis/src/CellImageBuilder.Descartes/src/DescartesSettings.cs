using System;
using DSIS.CellImageBuilder.Shared;
using DSIS.Core.Builders;
using DSIS.IntegerCoordinates;
using DSIS.Utils;

namespace DSIS.CellImageBuilder.Descartes
{
  [Serializable]
  public class DescartesSettings : ICellImageBuilderIntegerCoordinatesSettings
  {
    public CellImageBuilderAndRange[] Builders {get; set;}
    public string PresentableName
    {
      get { return "Decartes settings"; }
    }

    public ICellImageBuilder<TCell> Create<TCell>() where TCell : IIntegerCoordinate
    {
      throw new NotImplementedException();
    }
  }

  public class CellImageBuilderAndRange
  {
    [Used]
    public int From { get; private set; }
    [Used]
    public int To { get; private set; }
    [Used]
    public ICellImageBuilderIntegerCoordinatesSettings Settings { get; private set; }

    public CellImageBuilderAndRange(int from, int to, ICellImageBuilderIntegerCoordinatesSettings settings)
    {
      From = from;
      To = to;
      Settings = settings;
    }
  }
}