using System.IO;
using DSIS.Utils;

namespace DSIS.GnuplotDrawer
{
  public abstract class PngWriterBase : GnuplotFileWriterBase<IGnuplotScript>, IGnuplotScriptGen
  {
    protected readonly GnuplotScriptParameters myParams;

    protected PngWriterBase(ITempFileFactory factory, GnuplotScriptParameters @params) : base(factory, ".gnuplot")
    {
      myParams = @params;

      if (myParams.Title != null)
        myWriter.WriteLine("set title \"{0}\"; ", myParams.Title);

      myWriter.WriteLine("set terminal png font arial 20 size {0},{1}; ", myParams.Width, myParams.Height);

      SetOutput("");

      if (myParams.ShowKeyHistory)
        myWriter.WriteLine("set key below; ");
      else
        myWriter.WriteLine("set key off;");
    }

    protected void SetOutput(string suffix)
    {
      AssertDisposed();

      string file = myParams.OutputFile;
      var name = Path.GetFileNameWithoutExtension(file) + suffix + ".png";
      var dest = Path.Combine(Path.GetDirectoryName(file), name);
      myWriter.WriteLine("set output '{0}';", dest);
    }

    protected override IGnuplotScript CreateCloseInfo(string filename)
    {
      return new GnuplotScript { FileName = filename };
    }

    private class GnuplotScript : IGnuplotScript
    {
      public string FileName { get; set; }
    }
  }
}