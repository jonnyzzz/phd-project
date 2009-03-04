using System.IO;

namespace DSIS.GnuplotDrawer
{
  public class PngWriterBase : GnuplotFileWriterBase
  {
    protected readonly GnuplotScriptParameters myParams;

    public PngWriterBase(string filename, GnuplotScriptParameters @params) : base(filename)
    {
      myParams = @params;

      if (myParams.Title != null)
        myWriter.WriteLine("set title \"{0}\"; ", myParams.Title);

      myWriter.WriteLine("set terminal png size {0},{1}; ", myParams.Width, myParams.Height);

      SetOutput("");

      if (myParams.ShowKeyHistory)
        myWriter.WriteLine("set key below; ");
      else
        myWriter.WriteLine("set key off;");
    }

    protected void SetOutput(string suffix)
    {
      string file = myParams.OutputFile;
      var name = Path.GetFileNameWithoutExtension(file) + suffix + ".png";
      var dest = Path.Combine(Path.GetDirectoryName(file), name);
      myWriter.WriteLine("set output '{0}';", dest);
    }

    public virtual void Finish()
    {
      Dispose();
    }
  }
}