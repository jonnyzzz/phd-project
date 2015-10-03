using System;
using System.IO;

namespace DSIS.Utils
{
  public class CollectionWriter : IDisposable
  {
    private readonly TextWriter myWriter;
    private readonly string myCloseBlock;
    private readonly string myDelimiter;
    private bool myHasFirst;

    protected event EventHandler<EventArgs> OnDispose;

    public CollectionWriter(TextWriter writer, string open, string delim, string close)
    {
      myWriter = writer;
      myCloseBlock = close;
      myDelimiter = delim;
      myWriter.Write(open);
    }

    public void Write(string element)
    {
      if(myHasFirst)
      {
        myWriter.Write(myDelimiter);
      } else
      {
        myHasFirst = true;
      }
      myWriter.Write(element);
    }

    public CollectionWriter SubWriter(string open, string delim, string close)
    {
      var sw = new StringWriter();
      var wr = new CollectionWriter(sw, open, delim, close);
      wr.OnDispose += delegate { Write(sw.ToString()); };
      return wr;
    }

    public void Dispose()
    {      
      myWriter.Write(myCloseBlock);
      if (OnDispose != null)
      {
        OnDispose(this, EventArgs.Empty);
      }
    }
  }
}