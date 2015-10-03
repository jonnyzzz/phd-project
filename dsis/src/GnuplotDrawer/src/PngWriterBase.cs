namespace DSIS.GnuplotDrawer
{
  public class PngWriterBase : GnuplotFileWriterBase
  {
    protected readonly GnuplotScriptParameters myParams;

    public PngWriterBase(string filename, GnuplotScriptParameters @params) : base(filename)
    {
      myParams = @params;

      myWriter.WriteLine("set title \"{0}\"; ", myParams.Title);
      myWriter.WriteLine("set terminal png size {0},{1}; ", myParams.Width, myParams.Height);
      myWriter.WriteLine("set output '{0}';", myParams.OutputFile);

      if (myParams.ShowKeyHistory)
        myWriter.WriteLine("set key below; ");
      else
        myWriter.WriteLine("set key off;");
    }

    public void Finish()
    {
      Dispose();
    }
  }
}