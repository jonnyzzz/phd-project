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
  }
}