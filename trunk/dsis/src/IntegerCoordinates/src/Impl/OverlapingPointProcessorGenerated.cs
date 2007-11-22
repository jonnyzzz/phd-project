using System.Collections.Generic;
using DSIS.CodeCompiler;

namespace DSIS.IntegerCoordinates.Impl
{
  //todo:
  internal static class OverlapingPointProcessorGenerated<T, Q>
    where T : IIntegerCoordinateSystem<Q>
    where Q : IIntegerCoordinate<Q>
  {
    private static readonly Dictionary<int, IPointProcessor<Q>> myCache = new Dictionary<int, IPointProcessor<Q>>();

    private static string CreateOverlapingProcessorCode(int dim, string clazz)
    {
      return string.Format(
        @"
            public class {0} : IPointProcessor<{1}> {{
              {2}
              public IEnumerable<{1}> AddPoint(double[] value) {{
                 {3}
              }}
            }}         
", clazz,
        GeneratorTypeUtil.GenerateFQTypeName<Q>());
    }    
  }
}