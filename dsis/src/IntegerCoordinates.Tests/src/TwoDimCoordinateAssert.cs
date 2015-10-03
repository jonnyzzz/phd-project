using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DSIS.Utils;

namespace DSIS.IntegerCoordinates.Tests
{
  public static class TwoDimCoordinateAssert
  {
    private static string Write<Q>(IIntegerCoordinateSystem<Q> ics, IEnumerable<Q> list)
      where Q : IIntegerCoordinate
    {
      var hs = new HashSet<Q>(list, EqualityComparerFactory<Q>.GetComparer());

      var sb = new StringBuilder();
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

    private static string FixTestGold(string s)
    {
      return
        s.Split(new[] {Environment.NewLine}, StringSplitOptions.RemoveEmptyEntries)
          .Select(x => x.Trim())
          .Where(x => x.Length > 0)
          .JoinString(Environment.NewLine) + Environment.NewLine;
    }

    private static IEnumerable<string> SetLineLen(string s, string sep)
    {
      const string baseSep = "   ";

      var lines = s.Split(new[] {Environment.NewLine}, StringSplitOptions.None);
      var max = lines.FoldLeft(baseSep.Length, (x, v) => Math.Max(x.Length, v));
      return lines.Select(x => x + new string(' ', max - x.Length) + sep + baseSep);
    }

    private static string TwoCol(string s1, string s2)
    {
      var lines1 = SetLineLen(s1, " | ");
      var lines2 = SetLineLen(s2, "");

      return CollectionUtil.Merge(lines1, lines2, (x1, x2) => x1 + x2).JoinString(Environment.NewLine);
    }

    public static void Assert<Q>(IIntegerCoordinateSystem<Q> ics, IEnumerable<Q> list, string expected)
      where Q : IIntegerCoordinate
    {
      expected = FixTestGold(expected);

      string actual = Write(ics, list);
      try
      {
        NUnit.Framework.Assert.AreEqual(expected, actual);
      }
      catch
      {
        Console.Out.WriteLine("TwoCol(s, assert) = {1}{0}",
                              TwoCol(
                                      "Actual: " + Environment.NewLine + actual,
                                      "Expected: " + Environment.NewLine + expected),
                              Environment.NewLine);

        Console.Out.WriteLine("-----");
        Console.Out.WriteLine(actual);
        Console.Out.WriteLine("but expected was: ");
        Console.Out.WriteLine(expected);

        throw;
      }
    }
  }
}