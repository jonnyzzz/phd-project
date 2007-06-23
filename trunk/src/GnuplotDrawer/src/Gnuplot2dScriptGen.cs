namespace DSIS.GnuplotDrawer
{
  public class Gnuplot2dScriptGen : GnuplotFileWriterBase, IGnuplotScriptGen
  {
    private readonly GnuplotScriptParameters myParams;
    private bool myIsFirstFile = true;
    private int myFilesCount = 0;

    public Gnuplot2dScriptGen(string filename, GnuplotScriptParameters @params) : base(filename)
    {
      myParams = @params;

      myWriter.WriteLine("set title \"{0}\"; ", myParams.Title);
      myWriter.WriteLine("set terminal png size {0},{1}; ", myParams.Width, myParams.Height);
      myWriter.WriteLine("set output '{0}';", myParams.OutputFile);
     
      if (myParams.ShowKeyHistory && myFilesCount < 20)
        myWriter.WriteLine("set key below; ");
      else
        myWriter.WriteLine("set key off;");

      myWriter.Write("plot ");
    }

    #region IGnuplotScriptGen Members

    public void AddPointsFile(GnuplotPointsFileWriter file)
    {
      myFilesCount++;
      
      if (myIsFirstFile)
        myIsFirstFile = false;
      else
        myWriter.WriteLine(", \\");

      myWriter.Write(" '{0}' title \"{1}\" with ", file.Filename, string.Format(myParams.KeyFormat, file.PointsCount));

      if (file.PointsCount >= 300)
        myWriter.Write(" dots ");
      else
        myWriter.Write(" points ");
    }

    public override void Dispose()
    {
      myWriter.WriteLine(" ;");
      base.Dispose();
    }

    #endregion
  }
}