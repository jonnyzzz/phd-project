using DSIS.CellImageBuilder.BoxAdaptiveMethod;
using DSIS.Scheme.Ctx;
using DSIS.Utils;

namespace DSIS.Scheme.Impl.Actions
{
  [Used]
  public class DefaultBoxAdaptiveMethodSettings : IntegerCoordinateSystemActionBase3
  {
    protected override void Apply<T, Q>(Context input, Context output)
    {
      Keys.SubdivisionKey.Set(output, 2L.Fill(Dimension));
      Keys.CellImageBuilderKey.Set(output, new BoxAdaptiveMethodSettings
                                             {
                                               myAddRadiusFactor = 0.7,
                                               myCellSizePercent = 0.7,
                                               myOverlaping = 0.2,
                                               myTaskLimit = 200
                                             });
    }
  }
}