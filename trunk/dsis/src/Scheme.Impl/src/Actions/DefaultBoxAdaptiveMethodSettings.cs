using System;
using DSIS.CellImageBuilder.BoxAdaptiveMethod;
using DSIS.Scheme.Ctx;
using DSIS.Utils;

namespace DSIS.Scheme.Impl.Actions
{
  [Used]
  public class DefaultBoxAdaptiveMethodSettings : IntegerCoordinateSystemActionBase2Ex
  {
    protected override void Apply<T, Q>(T system, Context input, Context output)
    {
      Keys.SubdivisionKey.Set(output, 2L.Fill(system.Dimension));
      Keys.CellImageBuilderKey.Set(output, new BoxAdaptiveMethodSettings
                                             {
                                               AddRadiusFactor = 0.7,
                                               CellSizePercent = 0.7,
                                               Overlaping = 0.2,
                                               TaskLimit = 500
                                             });
    }
  }
}