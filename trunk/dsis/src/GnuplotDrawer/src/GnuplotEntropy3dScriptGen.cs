
using DSIS.Core.Visualization;

namespace DSIS.GnuplotDrawer
{
  public class GnuplotEntropy3dScriptGen : PngWriterBase, IGnuplotPhaseScriptGen
  {
    private bool myIsFirstFile = true;

    public GnuplotEntropy3dScriptGen(string filename, GnuplotScriptParameters @params)
      : base(filename, @params)
    {      
      myWriter.Write("splot ");
    }

    public void AddPointsFile(GnuplotPointsFileWriter file)
    {
      if (myIsFirstFile)
        myIsFirstFile = false;
      else
        myWriter.WriteLine(", \\");

      string lines = file.Filename + ".lines";
      string white = file.Filename + ".zero";

      using(GnuplotPointsFileWriter linesWriter = new GnuplotPointsFileWriter(lines, 3))
      {        
        using(GnuplotPointsFileWriter zeroPlane = new GnuplotPointsFileWriter(white, 3))
        {
          foreach (ImagePoint point in new GnuplotPointsFileReader(file.Filename).Read())
          {
            ImagePoint bs = new ImagePoint(point.Point[0], point.Point[1], 0);
            zeroPlane.WritePoint(bs);

            linesWriter.WritePoint(bs);
            linesWriter.WritePoint(point);
            linesWriter.WritePoint(bs);
          }
        }
      }

      myWriter.Write(" '{0}' with lines, '{1}' with lines lc rgb \"#ffffff\" ", lines, white);
    }

    public override void Dispose()
    {
      myWriter.WriteLine(" ;");
      base.Dispose();
    }

  }
}