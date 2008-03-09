using System;
using System.Collections.Generic;
using System.IO;
using System.Reflection;
using System.Text;
using DSIS.IntegerCoordinates.Impl;
using DSIS.Utils;

namespace DSIS.IntegerCoordinates
{
  public static class TwoDimCoordinateAssert
  {
    private static string Write<Q>(IIntegerCoordinateSystem<Q> ics, IEnumerable<Q> list)
      where Q : IIntegerCoordinate
    {
      Hashset<Q> hs = new Hashset<Q>();
      hs.AddRange(list);

      StringBuilder sb = new StringBuilder();
      sb.AppendLine("-------------------");
      for (long lx = 0; lx < ics.Subdivision[0]; lx++)
      {
        for (long ly = 0; ly < ics.Subdivision[1]; ly++)
        {
          if (hs.Contains(ics.Create(lx, ly)))
          {
            sb.AppendFormat("x");
          }
          else
          {
            sb.AppendFormat(".");
          }
        }
        sb.AppendLine();
      }
      sb.AppendLine("-------------------");

      return sb.ToString();
    }

    public static void Assert<Q>(IIntegerCoordinateSystem<Q> ics, IList<Q> list, string assert)
      where Q : IIntegerCoordinate
    {
      string s = Write(ics, list);
      try
      {
        NUnit.Framework.Assert.AreEqual(assert, s);
      }
      catch
      {
        Console.Out.WriteLine(s);
        throw;
      }
    }

    public static void AssertResource(IntegerCoordinateSystem ics, IList<IntegerCoordinate> list, string resource)
    {
      string s = Write(ics, list);
      try
      {
        using (
          StreamReader sr =
            new StreamReader(Assembly.GetCallingAssembly().GetManifestResourceStream(resource), Encoding.UTF8))
        {
          NUnit.Framework.Assert.AreEqual(sr.ReadToEnd(), s);
        }
      }
      catch
      {
        Console.Out.WriteLine(s);
      }
    }
  }
}