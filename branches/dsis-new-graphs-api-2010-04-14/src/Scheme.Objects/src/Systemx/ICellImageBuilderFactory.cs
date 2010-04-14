using DSIS.Core.Builders;
using DSIS.Core.Coordinates;
using DSIS.Core.Ioc;

namespace DSIS.Scheme.Objects.Systemx
{
  public class CellImageBuilderComponentAttribute : ComponentImplementationAttribute
  {    
  }

  public interface ICellImageBuilderFactory : IOptionsBasedFactory
  {
    ICellImageBuilder<Q> CreateSystem<Q>(ICellImageBuilderSettings settings) 
      where Q : ICellCoordinate;

    bool IsDefault { get; }
  }
}