using DSIS.Core.Visualization;
using DSIS.Utils;

namespace DSIS.GnuplotDrawer
{
  public class GnuplotEntropy2dWithBaseScriptGen : PngWriterBase, IGnuplotEntropyScriptGen
  {
    private readonly ITempFileFactory myFactory;
    private bool myIsFirstFile = true;

    public GnuplotEntropy2dWithBaseScriptGen(ITempFileFactory factory, GnuplotScriptParameters @params)
      : base(factory, @params)
    {
      myFactory = factory;
      myWriter.WriteLine("set yrange [0.00001:*];");
      myWriter.Write("plot ");
    }

    protected override void BeforeFileClosed()
    {
      myWriter.WriteLine(" ;");
      base.BeforeFileClosed();
    }

    public void AddPointsFile(IGnuplotPointsFile entropy, IGnuplotPointsFile @base)
    {
      if (myIsFirstFile)
        myIsFirstFile = false;
      else
        myWriter.WriteLine(", \\");

      var linesWriter = new GnuplotPointsFileWriter(myFactory, ".lines", 2);
      foreach (ImagePoint point in new GnuplotPointsFileReader(entropy.FileName).Read())
      {
        var bs = new ImagePoint(point.Point[0], 0);

        linesWriter.WritePoint(bs);
        linesWriter.WritePoint(point);
        linesWriter.WritePoint(bs);
      }

      var zeroPlane = new GnuplotPointsFileWriter(myFactory, ".bases", 2);
      foreach (ImagePoint point in new GnuplotPointsFileReader(@base.FileName).Read())
      {
        var bs = new ImagePoint(point.Point[0], 0.00002);

        zeroPlane.WritePoint(bs);
      }

      myWriter.Write(" '{1}' with dots, '{0}' with lines ", linesWriter.CloseFile().FileName, zeroPlane.CloseFile().FileName);
    }
  }
}