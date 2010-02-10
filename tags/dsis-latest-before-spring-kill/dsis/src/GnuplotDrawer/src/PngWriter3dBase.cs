namespace DSIS.GnuplotDrawer
{
  public class PngWriter3dBase : PngWriterBase
  {
    protected PngWriter3dBase(string filename, GnuplotScriptParameters @params) : base(filename, @params)
    {
      var p3d = @params as GnuplotScriptParameters3d;
      if (p3d == null) 
        return;
      myWriter.WriteLine("set view {0},{1};", p3d.RotX, p3d.RotZ);

      if (p3d.XYPane != null)
        myWriter.WriteLine("set xyplane at {0};", p3d.XYPane);
    }
  }
}