using System;
using DSIS.CellImageBuilder.Shared;
using DSIS.Core.Builders;
using DSIS.IntegerCoordinates;

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
    public int From { get; set; }
    public int To { get; set; }
    public ICellImageBuilderIntegerCoordinatesSettings Settings { get; set; }
  }
}