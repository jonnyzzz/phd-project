using System;
using System.Collections.Generic;
using System.Linq;
using DSIS.SimpleRunner.Data;

namespace DSIS.SimpleRunner.Computation
{
  public static class ComputationDataUtil
  {
    public static IEnumerable<T> ForBuildser<T>(this IEnumerable<T> data, params ComputationDataBuilder[] bld)
      where T : ComputationData, ICloneable<T>
    {
      var d = new List<T>();
      foreach (var computationData in data)
      {
        foreach (var b in bld)
        {
          var dd = computationData.Clone();
          dd.builder = b;
          d.Add(dd);
        }
      }
      return d;
    }

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

    public static IEnumerable<T> ForCoordinateSystems<T>(this IEnumerable<T> data, params CoordinateSystemType[] types)
      where T : BuilderData, ICloneable<T>
    {
      foreach (var d in data)
      {
        foreach (var type in types)
        {
          var c = d.Clone();
          c.CoordinateSystemType = type;
          yield return c;
        }
      }
    }

    public static IEnumerable<T> ForAllCoordinateSystems<T>(this IEnumerable<T> data)
      where T : BuilderData, ICloneable<T>
    {
      return data.ForCoordinateSystems(
        Enum.GetValues(typeof (CoordinateSystemType)).Cast<CoordinateSystemType>().ToArray());
    }
  }
}