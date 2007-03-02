/*
 * Created by: Eugene Petrenko
 * Created: 18 ������ 2006 �.
 */

using DSIS.Core.Coordinates;

namespace DSIS.Core.Builders
{
  public interface ICellImageBuilder<TCell>
    where TCell : ICellCoordinate<TCell>
  {
    void Bind(CellImageBuilderContext<TCell> cellImageBuilderContext);

    void BuildImage(TCell coord);

    /// <summary>
    /// Prototype pattern for using in multythreaded context.
    /// </summary>
    /// <returns>CellImage builder. Bind it before use</returns>
    ICellImageBuilder<TCell> Clone();
  }
}