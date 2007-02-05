using System;
using System.IO;

namespace DSIS.GnuplotDrawer
{
  public class GnuplotFileWriterBase : IDisposable
  {
    public readonly string Filename;
    protected TextWriter myWriter;

    public GnuplotFileWriterBase(string filename)
    {
      Filename = filename;
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
  }  
}