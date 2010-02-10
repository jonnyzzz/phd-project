using System;
using DSIS.CellImageBuilder.Shared;
using DSIS.Core.Builders;
using DSIS.Core.System;
using DSIS.IntegerCoordinates;

namespace DSIS.InvatriantSetMethod.src
{
  public class InvariantBuilderSettings : ICellImageBuilderIntegerCoordinatesSettings
  {
    public static readonly InvariantBuilderSettings Default = 
      new InvariantBuilderSettings
        {
          NumberOfIterations = 100, 
          IntersectionSpace = x => x
        };

    public int NumberOfIterations { get; set; }

    public Func<ISystemSpace, ISystemSpace> IntersectionSpace { get; set; }

    public string PresentableName
    {
      get { return "Invariant Set"; }
    }

    public ICellImageBuilder<TCell> Create<TCell>() where TCell : IIntegerCoordinate
    {
      return new InvariantBuilder<TCell>();
    }
  }
}