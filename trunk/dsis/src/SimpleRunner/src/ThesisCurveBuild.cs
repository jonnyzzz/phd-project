using System.Collections.Generic;
using DSIS.Utils;

namespace DSIS.SimpleRunner
{
  public class ThesisCurveBuild : CurveBuild
  {
    protected override IEnumerable<IEnumerable<CurveBuilderData>> GetSystemsToRun2()
    {
/*      yield return new CurveBuilderData
                     {
                       eps = 0.001,
                       Point1 = new[] {0.54890950520833448, -0.75236002604166552},
                       Point2 = new[] {0.53588867187500056, -0.74991861979166552},
                       system = SystemInfoFactory.Henon1_4(),
                       repeat = 20-5
                     }.Enum();*/
      yield return new CurveBuilderData
                     {
                       eps = 0.001,
                       Point1 = new[] { 0.7779947916666673, - 2.4446614583333326 },
                       Point2 = new[] { 0.7789947916666673, - 2.4448614583333326 },
                       system = SystemInfoFactory.Ikeda(),
                       repeat = 55
                     }.Enum();
    }
  }
}