using System;
using System.Collections.Generic;
using System.Linq;

namespace DSIS.SimpleRunner
{
  public static class ComputationDataUtil
  {
    public static IEnumerable<T> ForBuilders<T>(this IEnumerable<T> data, params ComputationDataBuilder[] bld)
      where T : ComputationData, ICloneable<T>
    {
      foreach (var computationData in data)
      {
        foreach (var b in bld)
        {
          var d = computationData.Clone();
          d.builder = b;
          yield return d;
        }
      }
    }

    public static IEnumerable<ComputationData> ForAllBuilders(this IEnumerable<ComputationData> data)
    {
      return data.ForBuilders(Enum.GetValues(typeof (ComputationDataBuilder)).Cast<ComputationDataBuilder>().ToArray());
    }

    public static IEnumerable<T> ForSteps<T>(this IEnumerable<T> data, IEnumerable<int> steps)
            where T : BuilderData, ICloneable<T>
    {
      foreach (var computationData in data)
      {
        foreach (var b in steps)
        {
          var d = computationData.Clone();
          d.repeat = b;
          yield return d;
        }
      }
    }

    public static IEnumerable<T> ForSteps<T>(this IEnumerable<T> data, params int[] steps)
      where T : BuilderData, ICloneable<T>
    {
      return ForSteps(data, (IEnumerable<int>) steps);
    }
  }
}