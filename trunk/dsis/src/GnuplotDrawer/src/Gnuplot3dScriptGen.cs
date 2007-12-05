namespace DSIS.GnuplotDrawer
{
  public class Gnuplot3dScriptGen : PngWriterBase, IGnuplotPhaseScriptGen
  {
    private bool myIsFirstFile = true;

    public Gnuplot3dScriptGen(string filename, GnuplotScriptParameters @params) : base(filename, @params)
    {
      GnuplotScriptParameters3d p3d = @params as GnuplotScriptParameters3d;
      if (p3d != null)
      {
        myWriter.WriteLine("set view {0},{1};", p3d.RotX, p3d.RotZ);

        if (p3d.XYPane != null)
          myWriter.WriteLine("set xyplane at {0};", p3d.XYPane);
      }
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