using DSIS.Core.Builders;
using DSIS.IntegerCoordinates;

namespace DSIS.CellImageBuilder.Shared
{
  public abstract class IntegerCoordinateMethodBase<Q, S> : IntegerCoordinateMethodBase<Q>, ICellImageBuilder<Q>
    where Q : IIntegerCoordinate
    where S : ICellImageBuilderIntegerCoordinatesSettings
  {
    public sealed override void Bind(CellImageBuilderContext<Q> context)
    {
      base.Bind(context);
      Bind((S) context.Settings, context);
    }

    protected abstract void Bind(S settings, CellImageBuilderContext<Q> context);

    public abstract void BuildImage(Q coord);
    public abstract ICellImageBuilder<Q> Clone();
  }
}