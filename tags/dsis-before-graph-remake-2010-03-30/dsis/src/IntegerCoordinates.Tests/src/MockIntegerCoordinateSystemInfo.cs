using DSIS.Core.Coordinates;
using DSIS.Core.System;

namespace DSIS.IntegerCoordinates.Tests
{
  public class MockIntegerCoordinateSystemInfo : IIntegerCoordinateSystem
  {
    private readonly double[] myCellSize;
    private readonly double[] myCellSizeHalf;

    public MockIntegerCoordinateSystemInfo(int dim, double eps)
    {
      myCellSize = new double[dim];
      myCellSizeHalf = new double[dim];

      for(int i=0; i<dim; i++)
      {
        myCellSize[i] = eps;
        myCellSizeHalf[i] = eps/2.0;
      }
    }

    public double[] CellSize
    {
      get { return myCellSize; }
    }

    public double[] CellSizeHalf
    {
      get { return myCellSizeHalf; }
    }

    public long[] Subdivision
    {
      get { throw new System.NotImplementedException(); }
    }

    public ISystemSpace SystemSpace
    {
      get { throw new System.NotImplementedException(); }
    }

    public int Dimension
    {
      get { throw new System.NotImplementedException(); }
    }

    public void DoGeneric(ICellCoordinateWith with)
    {
      throw new System.NotImplementedException();
    }

    public bool IsGenerated
    {
      get { return false; }
    }

    public void DoGeneric(IIntegerCoordinateSystemWith with)
    {
      throw new System.NotImplementedException();
    }
  }
}