namespace DSIS.IntegerCoordinates.Tests
{
  public class MockIntegerCoordinateSystemInfo : IIntegerCoordinateSystemInfo
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

    public void DoGeneric(IIntegerCoordinateSystemWith with)
    {
      throw new System.NotImplementedException();
    }
  }
}