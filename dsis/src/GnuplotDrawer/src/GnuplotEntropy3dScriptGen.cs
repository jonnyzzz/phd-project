using DSIS.Core.Visualization;
using DSIS.Utils;

namespace DSIS.GnuplotDrawer
{
  public class GnuplotEntropy3dScriptGen : PngWriter3dBase, IGnuplotMeasureDensityScriptGen
  {
    private readonly ITempFileFactory myFactory;
    private bool myIsFirstFile = true;

    public GnuplotEntropy3dScriptGen(ITempFileFactory factory, GnuplotScriptParameters @params)
      : base(factory, @params)
    {
      myFactory = factory;
      myWriter.WriteLine("set zrange [0.00001:*];");
      myWriter.Write("splot ");
    }

    protected override void BeforeFileClosed()
    {
      myWriter.WriteLine(" ;");
      base.BeforeFileClosed();
    }

    public void AddPointsFile(IGnuplotMeasureDensityFile file)
    {
      if (myIsFirstFile)
        myIsFirstFile = false;
      else
        myWriter.WriteLine(", \\");

      var linesWriter = new GnuplotPointsFileWriter(myFactory, ".lines", 3);
      var zeroPlane = new GnuplotPointsFileWriter(myFactory, ".zero", 3);
      foreach (var point in new GnuplotPointsFileReader(file.FileName).Read())
      {
        var bs = new ImagePoint(point.Point[0], point.Point[1], 0);
        zeroPlane.WritePoint(new ImagePoint(point.Point[0], point.Point[1], 0.00002));

        linesWriter.WritePoint(bs);
        linesWriter.WritePoint(point);
        linesWriter.WritePoint(bs);
      }

      myWriter.Write(" '{1}' with dots, '{0}' with lines ", linesWriter.CloseFile().FileName, zeroPlane.CloseFile().FileName);
    }
  }
}