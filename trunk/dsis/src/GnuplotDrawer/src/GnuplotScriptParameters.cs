namespace DSIS.GnuplotDrawer
{
  public class GnuplotScriptParameters
  {
    public readonly string OutputFile;
    public readonly int Width = 1000;
    public readonly int Height = 1000;
    public readonly string Title;
    
    public bool ShowKeyHistory{ get; set;}
    public bool ForcePoints{ get; set;}

    public GnuplotScriptParameters(string outputFile, string title)
    {
      OutputFile = outputFile;
      Title = title;
      ForcePoints = false;      
    }
  }
}