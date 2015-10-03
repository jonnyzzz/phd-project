namespace DSIS.GnuplotDrawer
{
  public class GnuplotScriptParameters3d : GnuplotScriptParameters
  {
    public float RotX { get; set;}
    public float RotZ { get; set;}
    public double? XYPane{ get; set;}

    public GnuplotScriptParameters3d(string outputFile, string title) : base(outputFile, title)
    {
      RotX = 60;
      RotZ = 30;
    }
  }
}