namespace DSIS.GnuplotDrawer
{
  public class Gnuplot3dScriptGen : PngWriter3dBase, IGnuplotPhaseScriptGen
  {
    private bool myIsFirstFile = true;

    public Gnuplot3dScriptGen(string filename, GnuplotScriptParameters @params) : base(filename, @params)
    {
      myWriter.Write("splot ");
    }

    public virtual void AddPointsFile(GnuplotPointsFileWriter file)
    {
      if (myIsFirstFile)
        myIsFirstFile = false;
      else
        myWriter.WriteLine(", \\");

      myWriter.Write(" '{0}' title \"{1}\" with ", file.Filename, string.Format("Count {0}", file.PointsCount));

      if (myParams.ForcePoints || file.PointsCount < 300)
        myWriter.Write(" points ");
      else
        myWriter.Write(" dots ");
    }

    public override void Dispose()
    {
      myWriter.WriteLine(" ;");
      if (myParams is GnuplotScriptParameters3d)
        myWriter.WriteLine("show view;");

      base.Dispose();
    }
  }
}