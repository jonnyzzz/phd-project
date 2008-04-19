namespace DSIS.GnuplotDrawer
{
  public class GnuplotScriptParameters
  {
    public readonly string OutputFile;
    public readonly int Width = 1000;
    public readonly int Height = 1000;
    public readonly string Title;
    public bool ShowKeyHistory = false;
    public bool ForcePoints = false;

    public GnuplotScriptParameters(string outputFile, string title)
    {
      OutputFile = outputFile;
      Title = title;
    }
  }

  public class GnuplotScriptParameters3d : GnuplotScriptParameters
  {
    public float RotX = 60;
    public float RotZ = 30;
    public double? XYPane = null;

    public GnuplotScriptParameters3d(string outputFile, string title) : base(outputFile, title)
    {
    }
  }
}