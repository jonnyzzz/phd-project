using System.Collections.Generic;
using DSIS.Utils;
using System.Linq;

namespace DSIS.SimpleRunner
{
  public class ThesisCurveBuild : CurveBuild
  {
    protected override IEnumerable<IEnumerable<CurveBuilderData>> GetSystemsToRun2()
    {
      /*
            yield return new CurveBuilderData
                           {
                             eps = 0.001,
                             Point1 = new[] {0.54890950520833448, -0.75236002604166552},
                             Point2 = new[] {0.53588867187500056, -0.74991861979166552},
                             system = SystemInfoFactory.Henon1_4(),
                           }.Enum().ForSteps(5,10,15,20,25,26,27,28,29,30,31,32,33,34,35,36,37,38,39,40);
            yield return new CurveBuilderData
                           {
                             eps = 0.001,
                             Point1 = new[] { 0.7779947916666673, - 2.4446614583333326 },
                             Point2 = new[] { 0.7789947916666673, - 2.4448614583333326 },
                             system = SystemInfoFactory.Ikeda(),
                           }.Enum().ForSteps(20,30,40,45,46,47,48,49,50,51,52,53,54,55);
      */

/*
      yield return new CurveBuilderData
                     {
                       eps = 0.001,
                       Point1 = new[] {-1.59, -1.6},
                       Point2 = new[] {-1.58, -1.61},
                       system = SystemInfoFactory.Henon1_4_InfSpace(),
                     }.Enum().ForSteps(1,2,3);
*/
      yield return new CurveBuilderData //Froyland, Junge, Ochs 2001
                     {
                       eps = 0.001,
                       Point1 = new[] {0.3, 1.0, 0.3},
                       Point2 = new[] {0.31, 1.01, 0.31 },
                       system = SystemInfoFactory.Ref9_Inf(1.2),
                     }.Enum().ForSteps(3.To(100));
    }
  }
}