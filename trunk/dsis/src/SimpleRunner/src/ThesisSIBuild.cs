using System;
using System.Collections.Generic;
using System.Linq;

namespace DSIS.SimpleRunner
{
  public class ThesisSIBuild : SIBuild
  {
    protected override IEnumerable<IEnumerable<ComputationData>> GetSystemsToRun2()
    {
      yield return
        new[] {0.02, 0.04, 0.06, 0.08}
          .Select(d =>
                  new ComputationData
                    {
                      system = SystemInfoFactory.Osipenko_2011_1(d),
                      ExecutionTimeout = TimeSpan.FromMinutes(30),
                      MemoryLimit = 5*1024*1024*1024L,
                      CoordinateSystemType = CoordinateSystemType.Generated
                    })

          .ForBuildser(ComputationDataBuilder.Box)
          .ForSteps(6)
          .ToArray();
//      yield return
//        (
//          from step in new[] {/*0.1, 0.05, 0.025, */0.01 /*, 0.005, 0.0025, 0.001, 0.0005, 0.00025, 0.0001, 0.00005*/}
//          from times in new[] {/*5, 10, 15, */17 /*, 25*/}
//          select new ComputationData
//                   {
//                     system = SystemInfoFactory.LeonovSystemEx(step, times, new LeonovP50_2Parameters
//                                                                              {
//                                                                                A1 = 1.041,
//                                                                                A2 = -0.717,
//                                                                                B2 = 0.067
//                                                                              }), 
//                     ExecutionTimeout = TimeSpan.FromMinutes(30),
//                     MemoryLimit = (long)(2 * 1024 * 1024 * 1024L),
//                     CoordinateSystemType = CoordinateSystemType.Generated
//                   }
//        ).ToArray()
//        .ForBuilders(ComputationDataBuilder.Box)
//        .ForSteps(8, 9, 10, 11, 12, 13, 14, 15, 16, 17, 18/*, 11, 12, 13, 14, 15, 16, 17, 18, 19, 20, 21, 22, 23, 24, 25*/);

//      yield return new ComputationData { system = SystemInfoFactory.OsipenkoBio3()}
//        .Enum()
//        .ForBuilders(ComputationDataBuilder.Box, ComputationDataBuilder.Point)
//        .ForSteps(3,4,5,6,7,8,9,10,12,13,14,15,16,17,18,19,20,21,22,23,24,25);
//      yield return new ComputationData { system = SystemInfoFactory.DuffingRunge(1.5, 100, 0.013)}.Enum().ForBuilders(ComputationDataBuilder.Box).ForSteps(10);

//      yield return new ComputationData { system = SystemInfoFactory.DuffingRunge(1.4, 1300, 0.001)}.Enum().ForBuilders(ComputationDataBuilder.Box).ForSteps(10);
/*
      yield return
        new ComputationData { system = SystemInfoFactory.Ref9(.5) }.Enum().ForBuilders(ComputationDataBuilder.Point, ComputationDataBuilder.Adaptive).ForSteps(10);
*/
    }

    /*protected override; IEnumerable<IEnumerable<ComputationData>> GetSystemsToRun2()
    {
      yield return GetSystemsToRun3().ForAllBuilders().ForSteps(2,2,2, 4, 6, 8, 10, 12, 14, 16).ForAllCoordinateSystems();
    }

    private static IEnumerable<ComputationData> GetSystemsToRun3()
    {
      yield return new ComputationData {system = SystemInfoFactory.AlphaX(0.45)};
      yield return new ComputationData {system = SystemInfoFactory.Ref9(0.5)};
      yield return new ComputationData {system = SystemInfoFactory.ChuaRunge2()};
      yield return new ComputationData {system = SystemInfoFactory.Delayed(2.27)};
      yield return new ComputationData {system = SystemInfoFactory.Delayed(2.21)};
      yield return new ComputationData {system = SystemInfoFactory.VanDerPolRunge()};      
      yield return new ComputationData {system = SystemInfoFactory.Duffing1_3x1_3Runge()};
      yield return new ComputationData {system = SystemInfoFactory.FoodChainDanny()};
      yield return new ComputationData {system = SystemInfoFactory.Henon1_4()};
      yield return new ComputationData {system = SystemInfoFactory.Ikeda()};
    }*/
  }
}