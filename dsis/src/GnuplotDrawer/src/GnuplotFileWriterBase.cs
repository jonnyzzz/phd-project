using System;
using System.IO;
using System.Text;

namespace DSIS.GnuplotDrawer
{
  public class GnuplotFileWriterBase : IDisposable
  {
    private readonly string myFilename;
    internal TextWriter myWriter;

    public GnuplotFileWriterBase(string filename)
    {
      myFilename = Path.GetFullPath(filename);
      myWriter = new StreamWriter(filename, true, Encoding.ASCII);
    }

    public virtual void Dispose()
    {
      if (myWriter != null)
      {
        myWriter.Close();
        myWriter = null;
      }
    }

    public string Filename
    {
      get { return myFilename; }
    }

    public TextWriter Writer
    {
      get { return myWriter; }
    }
  }
}