using System;
using System.Collections.Generic;
using System.Text;
using DSIS.Utils;

namespace DSIS.IntegerCoordinates.Tests
{
  public static class OneDimCoordinateAssert
  {
    private static string Render<Q>(IIntegerCoordinateSystem<Q> ics, IEnumerable<Q> list)
      where Q : IIntegerCoordinate
    {
      var hs = new HashSet<Q>(list, EqualityComparerFactory<Q>.GetComparer());

      var sb = new StringBuilder();
      for (long i = 0; i < ics.Subdivision[0]; i++)
      {
        sb.Append(hs.Contains(ics.Create(i.Fill(1))) ? "x" : " ");
      }
      return sb.ToString();
    }

    public static void Assert<Q>(IIntegerCoordinateSystem<Q> ics, IEnumerable<Q> list, string expected)
      where Q : IIntegerCoordinate
    {
      expected = expected.Trim();


      string actual = Render(ics, list);
      try
      {
        NUnit.Framework.Assert.AreEqual(expected, actual);
      }
      catch
      {
        Console.Out.WriteLine("Expected:");
        Console.Out.WriteLine(expected);
        Console.Out.WriteLine("-----");
        Console.Out.WriteLine("Actual:");
        Console.Out.WriteLine(actual);

        throw;
      }
    }
  }
}