using DSIS.Core.Visualization;

namespace DSIS.GnuplotDrawer
{
  public class GnuplotEntropy3dWithBaseScriptGen : PngWriter3dBase, IGnuplotScriptGen, IGnuplotEntropyScriptGen
  {
    private bool myIsFirstFile = true;

    public GnuplotEntropy3dWithBaseScriptGen(string filename, GnuplotScriptParameters @params)
      : base(filename, @params)
    {
      myWriter.WriteLine("set zrange [0.00001:*];");
      myWriter.Write("splot ");
    }

    public void AddPointsFile(GnuplotPointsFileWriter entropy, GnuplotPointsFileWriter @base)
    {
      if (myIsFirstFile)
        myIsFirstFile = false;
      else
        myWriter.WriteLine(", \\");

      string lines = entropy.Filename + ".lines";
      string bases = entropy.Filename + ".bases";

      using (var linesWriter = new GnuplotPointsFileWriter(lines, 3))
      {
        foreach (ImagePoint point in new GnuplotPointsFileReader(entropy.Filename).Read())
        {
          var bs = new ImagePoint(point.Point[0], point.Point[1], 0);

          linesWriter.WritePoint(bs);
          linesWriter.WritePoint(point);
          linesWriter.WritePoint(bs);
        }
      }

      using (var zeroPlane = new GnuplotPointsFileWriter(bases, 3))
      {
        foreach (ImagePoint point in new GnuplotPointsFileReader(@base.Filename).Read())
        {
          ImagePoint bs = new ImagePoint(point.Point[0], point.Point[1], 0.00002);

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