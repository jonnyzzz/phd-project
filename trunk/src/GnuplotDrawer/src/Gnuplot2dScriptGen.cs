namespace DSIS.GnuplotDrawer
{
  public class GnuplotScriptParameters
  {
    public readonly string OutputFile;
    public readonly int Width = 1000;
    public readonly int Height = 1000;
    public readonly string Title;
    public readonly string KeyFormat = "Count {0}";
    public bool ShowKeyHistory = true;

    public GnuplotScriptParameters(string outputFile, string title)
    {
      OutputFile = outputFile;
      Title = title;
    }
  }

  public class Gnuplot2dScriptGen : GnuplotFileWriterBase
  {
    private GnuplotScriptParameters myParams;
    private bool myIsFirstFile = true;

    public Gnuplot2dScriptGen(string filename, GnuplotScriptParameters @params) : base(filename)
    {
      myParams = @params;

      myWriter.WriteLine("set title \"{0}\"; ", myParams.Title);
      myWriter.WriteLine("set terminal png size {0},{1}; ", myParams.Width, myParams.Height);
      myWriter.WriteLine("set output '{0}';", myParams.OutputFile);
      if (myParams.ShowKeyHistory)
        myWriter.WriteLine("set key below; ");
      else
        myWriter.WriteLine("set key off;");

      myWriter.Write("plot ");
    }

    public void AddPointsFile(GnuplotPointsFileWriter file)
    {
      if (myIsFirstFile)
        myIsFirstFile = false;
      else 
        myWriter.Write(", ");

      myWriter.Write(" '{0}' title \"{1}\" with ", file.Filename, string.Format(myParams.KeyFormat, file.PointsCount));

      if (file.PointsCount < 300)
        myWriter.Write(" dots ");
      else
        myWriter.Write(" points ");
    }

    public override void Dispose()
    {
      myWriter.WriteLine(" ;");
      base.Dispose();
    }
  }
}
