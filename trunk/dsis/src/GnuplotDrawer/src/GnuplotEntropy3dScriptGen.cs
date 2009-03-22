
using DSIS.Core.Visualization;

namespace DSIS.GnuplotDrawer
{
  public class GnuplotEntropy3dScriptGen : PngWriter3dBase, IGnuplotPhaseScriptGen
  {
    private bool myIsFirstFile = true;

    public GnuplotEntropy3dScriptGen(string filename, GnuplotScriptParameters @params)
      : base(filename, @params)
    {
      myWriter.WriteLine("set zrange [0.00001:*];");
      myWriter.Write("splot ");
    }

    protected override void BeforeFileClosed()
    {
      myWriter.WriteLine(" ;");
      base.BeforeFileClosed();
    }

    public void AddPointsFile(IGnuplotPointsFile file)
    {
      if (myIsFirstFile)
        myIsFirstFile = false;
      else
        myWriter.WriteLine(", \\");

      string lines = file.FileName + ".lines";
      string white = file.FileName + ".zero";

      using(var linesWriter = new GnuplotPointsFileWriter(lines, 3))
      {        
        using(var zeroPlane = new GnuplotPointsFileWriter(white, 3))
        {
          foreach (ImagePoint point in new GnuplotPointsFileReader(file.FileName).Read())
          {
            var bs = new ImagePoint(point.Point[0], point.Point[1], 0);
            zeroPlane.WritePoint(new ImagePoint(point.Point[0], point.Point[1], 0.00002));

            linesWriter.WritePoint(bs);
            linesWriter.WritePoint(point);
            linesWriter.WritePoint(bs);
          }
        }
      }

      myWriter.Write(" '{1}' with dots, '{0}' with lines ", lines, white);
    }
  }
}