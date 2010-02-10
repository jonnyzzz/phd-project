using DSIS.Core.Visualization;

namespace DSIS.GnuplotDrawer
{
  public class GnuplotEntropy2dWithBaseScriptGen : PngWriterBase, IGnuplotScriptGen, IGnuplotEntropyScriptGen
  {
    private bool myIsFirstFile = true;

    public GnuplotEntropy2dWithBaseScriptGen(string filename, GnuplotScriptParameters @params)
      : base(filename, @params)
    {
      myWriter.WriteLine("set yrange [0.00001:*];");
      myWriter.Write("plot ");
    }

    public void AddPointsFile(GnuplotPointsFileWriter entropy, GnuplotPointsFileWriter @base)
    {
      if (myIsFirstFile)
        myIsFirstFile = false;
      else
        myWriter.WriteLine(", \\");

      string lines = entropy.Filename + ".lines";
      string bases = entropy.Filename + ".bases";

      using (var linesWriter = new GnuplotPointsFileWriter(lines, 2))
      {
        foreach (ImagePoint point in new GnuplotPointsFileReader(entropy.Filename).Read())
        {
          var bs = new ImagePoint(point.Point[0], 0);

          linesWriter.WritePoint(bs);
          linesWriter.WritePoint(point);
          linesWriter.WritePoint(bs);
        }
      }

      using (var zeroPlane = new GnuplotPointsFileWriter(bases, 2))
      {
        foreach (ImagePoint point in new GnuplotPointsFileReader(@base.Filename).Read())
        {
          var bs = new ImagePoint(point.Point[0], 0.00002);

          zeroPlane.WritePoint(bs);
        }
      }

      myWriter.Write(" '{1}' with dots, '{0}' with lines ", lines, bases);
    }

    public override void Dispose()
    {
      myWriter.WriteLine(" ;");
      base.Dispose();
    }
  }
}