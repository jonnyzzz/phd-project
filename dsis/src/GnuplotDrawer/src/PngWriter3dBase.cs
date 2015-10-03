using DSIS.Utils;

namespace DSIS.GnuplotDrawer
{
  public class PngWriter3dBase : PngWriterBase
  {
    private readonly GnuplotScriptParameters3d my3DParams;

    protected PngWriter3dBase(ITempFileFactory factory, GnuplotScriptParameters @params)
      : base(factory, @params)
    {
      my3DParams = @params as GnuplotScriptParameters3d;
      if (my3DParams == null) return;

      ChangeView(my3DParams.RotX, my3DParams.RotZ);

      if (my3DParams.XYPane != null)
        myWriter.WriteLine("set xyplane at {0};", my3DParams.XYPane);
    }

    private void ChangeView(float rotX, float rotZ)
    {
      myWriter.WriteLine("set view {0},{1};", rotX, rotZ);
    }

    private void RotateZ(int rotX, int rotZ)
    {      
      SetOutput(string.Format("-{0}-{1}", rotX, rotZ));
      ChangeView(rotX, rotZ);
      myWriter.WriteLine("replot;");      
    }

    protected override void BeforeFileClosed()
    {
      if ((myParams as IScanDraw).DrawScans)
      {
        for (int x = 0; x < 80; x += 15)
        {
          for (int z = 0; z < 360; z += 15)
          {
            RotateZ(x, z);
          }
        }
      }
      base.BeforeFileClosed();
    }
  }
}