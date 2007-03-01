using System.Globalization;
using DSIS.Core.Visualization;

namespace DSIS.GnuplotDrawer
{
  public class GnuplotPointsFileWriter : GnuplotFileWriterBase
  {
    private readonly int myDim;
    private int myPointsCount = 0;

    public GnuplotPointsFileWriter(string filename, int dim) : base(filename)
    {
      myDim = dim;
    }

    public void WritePoint(ImagePoint pt)
    {
      for (int i = 0; i < myDim; i++)
      {
        myWriter.Write(pt.Point[i].ToString("E", CultureInfo.InvariantCulture));
        myWriter.Write(' ');
      }
      myWriter.WriteLine();
      myPointsCount++;
    }

    public int PointsCount
    {
      get { return myPointsCount; }
    }
  }
}