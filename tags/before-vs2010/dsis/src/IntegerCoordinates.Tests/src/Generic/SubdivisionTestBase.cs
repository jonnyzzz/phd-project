using System;
using System.Collections.Generic;
using DSIS.Core.Coordinates;
using DSIS.IntegerCoordinates.Tests;
using DSIS.Utils;
using NUnit.Framework;

namespace DSIS.IntegerCoordinates.Tests.Generic
{
  public class SubdivisionTestBase<T,Q>
    where T : IIntegerCoordinateSystem<Q>
    where Q : IIntegerCoordinate
  {
    protected static void DoTest(double[] l, double[] r, long[] g, long[] div)
    {
      T ics = IntegerCoordinateSystemFactory.CreateCoordinateSystem<T,Q>(new MockSystemSpace(l.Length, l, r, g));
      List<Q> coords = new List<Q>(ics.InitialSubdivision);

      ICellCoordinateSystemConverter<Q, Q> converter = ics.Subdivide(div);

      Hashset<Q> ass = new Hashset<Q>();
      foreach (Q coord in coords)
      {
        try
        {
          foreach (Q coordinate in converter.Subdivide(coord))
          {
            try
            {
              Assert.IsFalse(ass.Contains(coordinate));
            }
            catch
            {
              Console.Out.WriteLine("coordinate = {0}", coordinate);
              throw;
            }
            ass.Add(coordinate);
          }
        }
        catch
        {
          Console.Out.WriteLine("coord = {0}", coord);
          throw;
        }
      }

      long m = 1;
      foreach (long ll in div)
      {
        m *= ll;
      }

      long n = 1;
      foreach (long l1 in g)
      {
        n *= l1;
      }

      Assert.AreEqual(n*m, ass.Count);
    }
  }
}