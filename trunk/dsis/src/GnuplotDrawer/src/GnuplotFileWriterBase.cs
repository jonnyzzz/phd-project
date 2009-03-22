using System;
using System.IO;
using System.Text;
using DSIS.Utils;
using log4net;

namespace DSIS.GnuplotDrawer
{
  public abstract class GnuplotFileWriterBase<T> : IDisposable
    where T : IGnuplotFile
  {
    private static readonly ILog LOG = LogManager.GetLogger(typeof (GnuplotFileWriterBase<T>));

    private readonly string myFilename;
    protected TextWriter myWriter;

    protected GnuplotFileWriterBase(string filename)
    {
      myFilename = Path.GetFullPath(filename);
      myWriter = new StreamWriter(filename, true, Encoding.ASCII);
    }

    protected void AssertDisposed()
    {
      if (myWriter == null)
      {
        LOG.ErrorFormat("Access to disposed object at:{0}{1}", Environment.NewLine, Environment.StackTrace);
      }
    }

    void IDisposable.Dispose()
    {
      AssertDisposed();
      BeforeFileClosed();
    }

    protected virtual void BeforeFileClosed()
    {      
    }

    private void BeforeFileClosedInternal()
    {
      AssertDisposed();
      LOG.Catch("BeforeFileClosed M", BeforeFileClosed);
    }

    private void CloseFileImpl()
    {
      if (myWriter != null)
      {
        myWriter.Close();
        myWriter = null;
      }
    }

    public T CloseFile()
    {
      AssertDisposed();
      BeforeFileClosedInternal();
      CloseFileImpl();
      return CreateCloseInfo(myFilename);
    }

    protected abstract T CreateCloseInfo(string filename);
  }
}