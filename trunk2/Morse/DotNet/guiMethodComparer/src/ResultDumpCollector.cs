using System;
using System.Collections;
using System.IO;
using System.Runtime.Remoting.Messaging;
using System.Text;

namespace Eugene.Petrenko.Gui2.MethodComparer
{
	/// <summary>
	/// Summary description for ResultDumpCollector.
	/// </summary>
	public class ResultDumpCollector
	{
        private Hashtable/*id -> ArrayList*/ log = new Hashtable();        
	    private IAttachableSimpleWriter writer;

	    public ResultDumpCollector(IAttachableSimpleWriter writer)
	    {
	        this.writer = writer;
	    }

	    public ResultDumper CreateDumper(string name)
		{            
		    return new ResultDumper(writer, name);
		}

        public void Dump()
        {
            writer.WriteLine("Dumping summarised stats");
        }


        public void AddLogItem(string id, string mid, double time)
        {
            ArrayList data = (ArrayList) log[mid];
            if (data == null)
            {
                data = new ArrayList();
                log[mid] = data;
            }            
            data.Add(new LogItem(id, mid, time));
        }

        private class LogItem
        {
            private string id;
            private string message;
            private double ms;

            public LogItem(string id, string message, double ms)
            {
                this.id = id;
                this.message = message;
                this.ms = ms;
            }

            public string Id
            {
                get { return id; }
            }

            public string Message
            {
                get { return message; }
            }

            public double Ms
            {
                get { return ms; }
            }
        }
	}
}
