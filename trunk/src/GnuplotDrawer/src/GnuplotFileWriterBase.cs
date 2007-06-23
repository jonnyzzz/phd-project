using System;
using System.IO;

namespace DSIS.GnuplotDrawer
{
  public class GnuplotFileWriterBase : IDisposable
  {
    private readonly string myFilename;
    protected TextWriter myWriter;

    public GnuplotFileWriterBase(string filename)
    {
      myFilename = filename;
      myWriter = File.CreateText(filename);
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
  }
}