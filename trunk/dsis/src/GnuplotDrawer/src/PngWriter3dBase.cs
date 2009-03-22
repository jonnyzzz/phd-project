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
      var p3d = @params as GnuplotScriptParameters3d;
      if (p3d == null)
        return;

      if (my3DParams != null)
      {
        ChangeView(my3DParams.RotX, my3DParams.RotZ);

        if (my3DParams.XYPane != null)
          myWriter.WriteLine("set xyplane at {0};", my3DParams.XYPane);      
      }
    }

    private void ChangeView(float rotX, float rotZ)
    {
      myWriter.WriteLine("set view {0},{1};", rotX, rotZ);
    }

    private void RotateZ(int rotX, int rotZ)
    {
      ChangeView(rotX, rotZ);
      myWriter.WriteLine("replot;");
      SetOutput(string.Format("-{0}-{1}", rotX, rotZ));
    }

    protected override void BeforeFileClosed()
    {
      if ((myParams as IScanDraw).DrawScans)
      {
        for (int x = 0; x < 180; x += 10)
        {
          for (int z = 0; z < 360; z += 10)
          {
            RotateZ(x, z);
          }
        }
      }
      base.BeforeFileClosed();
    }
  }
}