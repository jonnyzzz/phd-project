using System.Collections;
using System.IO;
using System.Xml;
using System.Xml.Xsl;

namespace Eugene.Petrenko.Gui2.MethodComparer
{
	/// <summary>
	/// Summary description for ResultDumpCollector.
	/// </summary>
	public class ResultDumpCollector
	{
        private Hashtable/*id -> ArrayList*/ log = new Hashtable();        
	    private IAttachableSimpleWriter writer;
		private XmlDocument document;
		private XmlElement rootElement;

	    public ResultDumpCollector(IAttachableSimpleWriter writer, XmlDocument task)
	    {
	        this.writer = writer;
			document = new XmlDocument();
			document.CreateXmlDeclaration("1.0", "UTF-8", string.Empty);			
			rootElement = document.CreateElement("log");
			document.AppendChild(rootElement);
			rootElement.AppendChild(document.ImportNode(task.DocumentElement, true));

//			rootElement.InnerText += @"<xsl:stylesheet version=""1.0""
//									   xmlns:xsl=""http://www.w3.org/1999/XSL/Transform""
//									   xmlns=""http://www.w3.org/TR/REC-html40"">";
	    }

	    public ResultDumper CreateDumper(string name)
		{            
		    return new ResultDumper(this, writer, name);
		}

        public void Dump()
        {
            writer.WriteLine("Dumping summarised stats");
        }

		public void AppendLogMessage(XmlElement element, string Name)
		{
			XmlElement log = (XmlElement) document.ImportNode(element, true);
			XmlAttribute methodType = document.CreateAttribute("method");
			methodType.Value = Name;
			log.Attributes.Append(methodType);
			rootElement.AppendChild(log);
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

		public void SaveXMLLog(string file)
		{
			using(TextWriter tw = File.CreateText(file)) 
				document.Save(tw);
			XslTransform transform = new XslTransform();
			using(Stream stream = typeof(ResultDumper).Assembly.GetManifestResourceStream("Eugene.Petrenko.Gui2.MethodComparer.xml.transpose.xsl"))
			{				
				transform.Load(new XmlTextReader( new StreamReader(stream)), new XmlUrlResolver(), this.GetType().Assembly.Evidence);	
			}
			using(TextWriter tw = File.CreateText(file + ".html"))
			{
				transform.Transform(document.DocumentElement.CreateNavigator(), null, tw, null);	
			}			
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
