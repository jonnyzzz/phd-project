using DSIS.Core.System.Impl;

namespace DSIS.IntegerCoordinates.Tests
{
  public class MockSystemSpace : DefaultSystemSpace
  {
    public MockSystemSpace(int dimension, double[] areaLeftPoint, double[] areaRightPoint, long[] initialSubdivision)
      : base(dimension, areaLeftPoint, areaRightPoint, initialSubdivision)
    {
    }

    public MockSystemSpace(int dimension, double areaLeft, double areaRight, long init) :
      this(dimension, FillArray(dimension, areaLeft), FillArray(dimension, areaRight), FillArray(dimension, init))
    {
    }

    private static T[] FillArray<T>(int count, T value)
    {
      T[] t = new T[count];
      for (int i = 0; i < count; i++)
      {
        t[i] = value;
      }
      return t;
    }
  }
}