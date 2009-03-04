namespace DSIS.GnuplotDrawer
{
  public class PngWriter3dBase : PngWriterBase
  {
    private new readonly GnuplotScriptParameters3d myParams;

    protected PngWriter3dBase(string filename, GnuplotScriptParameters @params)
      : base(filename, @params)
    {
      myParams = @params as GnuplotScriptParameters3d;
      var p3d = @params as GnuplotScriptParameters3d;
      if (p3d == null)
        return;
      ChangeView(0, 0);
    }

    private void ChangeView(int rotX, int rotZ)
    {
      var bX = myParams != null ? myParams.RotX : 0f;
      var bZ = myParams != null ? myParams.RotZ : 0f;
      myWriter.WriteLine("set view {0},{1};", bX + rotX, bZ + rotZ);

      if (myParams != null && myParams.XYPane != null)
        myWriter.WriteLine("set xyplane at {0};", myParams.XYPane);      
    }

    private void RotateZ(int rotX, int rotZ)
    {
      ChangeView(rotX, rotZ);
      myWriter.WriteLine("replot;");
      SetOutput(string.Format("-{0}-{1}", rotX, rotZ));
    }

    public override void Dispose()
    {      
      for (int x = 0; x < 180; x += 10)
      {
        for (int z = 0; z < 360; z += 10)
        {
          RotateZ(x, z);
        }
      }

      base.Dispose();
    }
  }
}