namespace DSIS.GnuplotDrawer
{
  public class GnuplotScriptParameters : IScanDraw
  {
    public readonly string OutputFile;
    public int Width { get; set;}
    public int Height { get; set;}
    public string Title { get; set;}
    
    public bool ShowKeyHistory{ get; set;}
    public bool ForcePoints{ get; set;}

    public GnuplotScriptParameters(string outputFile, string title)
    {
      DrawScans = true;
      Height = Width = 1000;
      OutputFile = outputFile;
      Title = title;
      ForcePoints = false;      
    }

    public bool DrawScans { get; set;}
  }
}