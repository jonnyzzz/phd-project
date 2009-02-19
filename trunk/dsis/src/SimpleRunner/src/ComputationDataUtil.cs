using System;
using System.Collections.Generic;
using System.Linq;

namespace DSIS.SimpleRunner
{
  public static class ComputationDataUtil
  {
    public static IEnumerable<ComputationData> ForBuilders(this IEnumerable<ComputationData> data, params ComputationDataBuilder[] bld)
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

    public static IEnumerable<ComputationData> ForSteps(this IEnumerable<ComputationData> data, params int[] steps)
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
  }
}