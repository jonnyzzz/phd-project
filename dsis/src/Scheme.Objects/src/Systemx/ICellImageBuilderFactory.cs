using DSIS.Core.Builders;
using DSIS.Core.Coordinates;
using EugenePetrenko.Shared.Core.Ioc.Api;

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