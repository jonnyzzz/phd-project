namespace DSIS.GnuplotDrawer
{
  public class GnuplotEntropy3dScriptGen : Gnuplot3dScriptGen
  {
    private bool myIsFirstFile = true;

    public GnuplotEntropy3dScriptGen(string filename, GnuplotScriptParameters @params)
      : base(filename, @params)
    {      
    }

    public override void AddPointsFile(GnuplotPointsFileWriter file)
    {
      if (myIsFirstFile)
        myIsFirstFile = false;
      else
        myWriter.WriteLine(", \\");

      myWriter.Write(" '{0}' using 1:2:(0):1:2:3 with line title \"{1}\" with ", file.Filename, string.Format("Count {0}", file.PointsCount));

      if (myParams.ForcePoints || file.PointsCount < 300)
        myWriter.Write(" points ");
      else
        myWriter.Write(" dots ");
    }    
  }
}