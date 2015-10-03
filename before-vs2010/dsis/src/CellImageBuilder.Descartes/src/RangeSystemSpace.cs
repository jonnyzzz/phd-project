using DSIS.Core.System;
using DSIS.Core.System.Impl;

namespace DSIS.CellImageBuilder.Descartes
{
  public class RangeSystemSpace : ISystemSpace
  {
    private readonly ISystemSpace myHostSpace;
    private readonly int myFrom;
    private readonly int myTo;

    private readonly DefaultSystemSpace mySpace;

    public RangeSystemSpace(ISystemSpace hostSpace, int from, int to)
    {
      myHostSpace = hostSpace;
      myFrom = from;
      myTo = to;

      mySpace = new DefaultSystemSpace(myTo - myFrom + 1, Slice(myHostSpace.AreaLeftPoint), Slice(myHostSpace.AreaRightPoint), Slice(myHostSpace.InitialSubdivision));
    }

    public double[] AreaLeftPoint
    {
      get { return mySpace.AreaLeftPoint; }
    }

    public double[] AreaRightPoint
    {
      get { return mySpace.AreaRightPoint; }
    }

    public bool Contains(double[] point)
    {
      return mySpace.Contains(point);
    }

    public bool ContainsRect(double[] left, double[] right)
    {
      return mySpace.ContainsRect(left, right);
    }

    public bool ContainedRect(double[] left, double[] right)
    {
      return mySpace.ContainedRect(left, right);
    }

    public int Dimension
    {
      get { return mySpace.Dimension; }
    }

    public long[] InitialSubdivision
    {
      get { return mySpace.InitialSubdivision; }
    }

    public T[] Slice<T>(T[] point)
    {
      var r = new T[myTo - myFrom + 1];
      for (int i = myFrom; i <= myTo; i++)
      {
        r[i] = point[i];
      }
      return r;
    }

  }
}