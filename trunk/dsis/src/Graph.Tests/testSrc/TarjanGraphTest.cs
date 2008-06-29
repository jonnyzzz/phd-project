using DSIS.Graph.Abstract;
using DSIS.IntegerCoordinates.Impl;
using NUnit.Framework;

namespace DSIS.Graph.Tests
{
  [TestFixture]
  public class TarjanGraphTest : GraphTestBase<TarjanGraph<IntegerCoordinate>>
  {
    protected override TarjanGraph<IntegerCoordinate> CreateGraph(IntegerCoordinateSystem ics)
    {
      return new TarjanGraph<IntegerCoordinate>(ics);
    }
  }
}