using System.Globalization;
using DSIS.Core.Visualization;

namespace DSIS.GnuplotDrawer
{
  public abstract class GnuplotPointsFileWriter<T> : GnuplotFileWriterBase<T>
    where T : IGnuplotFile
  {
    private readonly int myDim;
    private int myPointsCount;

    public GnuplotPointsFileWriter(string filename, int dim) : base(filename)
    {
      myDim = dim;
    }

    public void WritePoint(ImagePoint pt)
    {
      AssertDisposed();

      for (int i = 0; i < myDim; i++)
      {
        myWriter.Write(DoubleToString(pt.Point[i]));
        myWriter.Write(' ');
      }
      myWriter.WriteLine();
      myPointsCount++;
    }

    private static string DoubleToString(double d)
    {
      return d.ToString("R", CultureInfo.InvariantCulture);
    }

    protected int PointsCount
    {
      get { return myPointsCount; }
    }
  }
}