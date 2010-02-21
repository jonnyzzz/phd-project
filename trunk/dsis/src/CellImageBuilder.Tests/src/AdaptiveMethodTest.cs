using DSIS.IntegerCoordinates.Impl;
using NUnit.Framework;

namespace DSIS.CellImageBuilder.Tests
{
  [TestFixture]
  public class AdaptiveMethodTest : AdaptiveMethodTestBase<IntegerCoordinateSystem, IntegerCoordinate>
  {
    protected override IntegerCoordinate Create(IntegerCoordinateSystem ics, long x, long y)
    {
      return ics.Create(x, y);
    }
  }
}