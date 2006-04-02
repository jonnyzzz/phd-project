using System;
using System.Text;
using System.Xml;
using EugenePetrenko.Gui2.Kernell2;
using EugenePetrenko.Gui2.Kernell2.Node;
using EugenePetrenko.Gui2.MorseKernel2;

namespace Eugene.Petrenko.Gui2.MethodComparer
{
	/// <summary>
	/// Summary description for ResultDumper.
	/// </summary>
	public class ResultDumper : IDisposable, ISimpleWriter
	{
	    private readonly IAttachableSimpleWriter output;
	    private readonly string id;
	    private DateTime computationStartTime;
	    private DateTime iterationStartedTime;
	    private DateTime actionStartedTime;
	    private DateTime saveStartTime;
        private TimeSpan totalTime;
	    private StringBuilder logOutput = new StringBuilder();
		private XmlDocument document;
		private XmlElement rootElement;
		private ResultDumpCollector parent;

	    public ResultDumper(ResultDumpCollector parent, IAttachableSimpleWriter output, string id)
	    {	        
			this.parent = parent;
	        this.output = output;
	        this.id = id;
			document = new XmlDocument();
			document.CreateXmlDeclaration("1.0", "UTF-8", string.Empty);			
			rootElement = document.CreateElement("log");
			document.AppendChild(rootElement);
	        output.AddHandler(this);
	    }

		public ResultDumpCollector Parent
		{
			get { return parent; }
		}

		private void WriteArrtibute(XmlElement element, string name, object value)
		{
			XmlAttribute attr = element.OwnerDocument.CreateAttribute(name);
			attr.Value = value.ToString();
			element.Attributes.Append(attr);
		}

	    public void WriteBuildCommand(string format, params object[] data)
	    {
	        output.WriteBuildCommand(format,  data);
	    }
	    
	    public void DoStarted()
	    {  
            totalTime = new TimeSpan(0);
            output.WriteLine("\r\n\r\nWorking for {0}", id);
            computationStartTime = DateTime.Now;
            output.WriteLine("Computations started");
		
			XmlElement element = document.CreateElement("start");
			WriteArrtibute(element, "action", id);
			rootElement.AppendChild(element);
	    }

	    public void IterationStarted(int i, int power)
	    {
            iterationStartedTime = DateTime.Now;
            output.WriteLine("Iteration {0} of {1} started.", i, power);   

			XmlElement element = document.CreateElement("IterationStarted");
			WriteArrtibute(element, "step", i);
			WriteArrtibute(element, "of", power);
			rootElement.AppendChild(element);
	    }

	    public void ActionStarted(IDefinedAction action, int i, int power)
	    {
            actionStartedTime = DateTime.Now;
	        output.WriteLine("Iteration {0} of {1}: action {2} started", i, power, action.Name);

			XmlElement element = document.CreateElement("ActionStart");
			WriteArrtibute(element, "step", i);
			WriteArrtibute(element, "of", power);
			WriteArrtibute(element, "name", action.Name);
			rootElement.AppendChild(element);
	    }


	    public void ActionFinished(IDefinedAction action, int i, int power)
	    {
	        TimeSpan difference = DateTime.Now - actionStartedTime;
            double ms = difference.TotalMilliseconds;            
            output.WriteLine("Iteration {0} of {1}: action {2} finished. {3} ms", i, power, action.Name, ms );

			XmlElement element = document.CreateElement("ActionFinish");
			WriteArrtibute(element, "timeMiniseconds", ms);
			WriteArrtibute(element, "step", i);
			WriteArrtibute(element, "of", power);
			rootElement.AppendChild(element);
	    }

	    public void IterationFinished(int i, int power)
	    {
            TimeSpan difference = DateTime.Now - iterationStartedTime;
            double ms = difference.TotalMilliseconds;
            totalTime = totalTime.Add(difference) ;
            output.WriteLine("Iteration {0} of {1} finished. {2} ms", i, power, ms);

			XmlElement element = document.CreateElement("IterationFinished");
			WriteArrtibute(element, "timeMiniseconds", ms);
			WriteArrtibute(element, "step", i);
			WriteArrtibute(element, "of", power);
			rootElement.AppendChild(element);
	    }

        public void SavingResultsStarted()
        {
            saveStartTime = DateTime.Now;
            output.WriteLine("Save started");
			rootElement.AppendChild(document.CreateElement("SaveResultStarted"));
        }
	    
	    public string GetLogFileText()
	    {
	        return logOutput.ToString();
	    }

		public XmlDocument GetLogXML()
		{
			return document;
		}

		public XmlElement GetLogXMLContent()
		{
			return rootElement;
		}

        public void SavingResultsFinished()
        {
            logOutput = new StringBuilder();
            TimeSpan difference = DateTime.Now - saveStartTime;
            double ms = difference.TotalMilliseconds;
            output.WriteLine("Save finished. {0} ms", ms);	        

			XmlElement element = document.CreateElement("SaveResultsFinished");
			WriteArrtibute(element, "timeMilliseconds", ms);
			rootElement.AppendChild(element);
        }

        public void DumpResultSet(ResultSet set)        
        {
			XmlElement element = document.CreateElement("Result");

            output.WriteLine("Dumping node result: ");
            GraphInfoPresenter presenter = new GraphInfoPresenter();
            foreach (IResult resultSet in set)
            {
                IGraphResult result = resultSet as IGraphResult;
				if (result != null) 
				{
					output.WriteLine(presenter.PresentToHistory(result));
					presenter.PresentToXml(result, element);
				}
            }
            output.WriteLine("Finished\r\n\r\n");

			rootElement.AppendChild(element);
        }

	    public void DoFinished()
	    {
            TimeSpan difference = DateTime.Now - computationStartTime;
            double ms = difference.TotalMilliseconds;
            output.WriteLine("Computations finished. {0} ms", ms);
            output.WriteLine("\r\n\r\nFinished work for {0}\r\n\r\n\r\n", id);

			XmlElement element = document.CreateElement("DoFinished");
			WriteArrtibute(element, "timeMilliseconds", ms);
			rootElement.AppendChild(element);
		}

	    public void Dispose()
	    {			
	        output.WriteLine("Finished");
	        output.RemoveHandler(this);
	    }

	    public void WriteLine(string format, params object[] data)
	    {
	        logOutput.AppendFormat(format, data);
	        logOutput.Append("\r\n");
	    }

	    public void EmptyResultSet()
	    {
	        output.WriteLine("Result set is empty");
	    }

		public void IterationAbortedTooBigGraph(int i, int power)
		{
			output.WriteLine("Iteration process ended due to big number of nodes in graph");

			XmlElement element = document.CreateElement("Iteration_AbortedTooBigGraph");
			WriteArrtibute(element, "step", i);
			WriteArrtibute(element, "of", power);
			rootElement.AppendChild(element);
		}
	}
}
