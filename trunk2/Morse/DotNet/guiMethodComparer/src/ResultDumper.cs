using System;
using System.Text;
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

	    public ResultDumper(IAttachableSimpleWriter output, string id)
	    {	        
	        this.output = output;
	        this.id = id;
	        
	        output.AddHandler(this);
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
	    }

	    public void IterationStarted(int i, int power)
	    {
            iterationStartedTime = DateTime.Now;
            output.WriteLine("Iteration {0} of {1} started.", i, power);   
	    }

	    public void ActionStarted(IDefinedAction action, int i, int power)
	    {
            actionStartedTime = DateTime.Now;
	        output.WriteLine("Iteration {0} of {1}: action {2} started", i, power, action.Name);
	    }

	    public void ActionFinished(IDefinedAction action, int i, int power)
	    {
	        TimeSpan difference = DateTime.Now - actionStartedTime;
            double ms = difference.TotalMilliseconds;            
            output.WriteLine("Iteration {0} of {1}: action {2} finished. {3} ms", i, power, action.Name, ms );
	    }

	    public void IterationFinished(int i, int power)
	    {
            TimeSpan difference = DateTime.Now - iterationStartedTime;
            double ms = difference.TotalMilliseconds;
            totalTime = totalTime.Add(difference) ;
            output.WriteLine("Iteration {0} of {1} finished. {2} ms", i, power, ms);
	    }

        public void SavingResultsStarted()
        {
            saveStartTime = DateTime.Now;
            output.WriteLine("Save started");
        }
	    
	    public string GetLogFileText()
	    {
	        return logOutput.ToString();
	    }

        public void SavingResultsFinished()
        {
            logOutput = new StringBuilder();
            TimeSpan difference = DateTime.Now - saveStartTime;
            double ms = difference.TotalMilliseconds;
            output.WriteLine("Save finished. {0} ms", ms);	        
        }

        public void DumpResultSet(ResultSet set)        
        {
            output.WriteLine("Dumping node result: ");
            GraphInfoPresenter presenter = new GraphInfoPresenter();
            foreach (IResult resultSet in set)
            {
                IGraphResult result = resultSet as IGraphResult;
                if (result != null)
                    output.WriteLine(presenter.PresentToHistory(result));
            }
            output.WriteLine("Finished\r\n\r\n");
        }

	    public void DoFinished()
	    {
            TimeSpan difference = DateTime.Now - computationStartTime;
            double ms = difference.TotalMilliseconds;
            output.WriteLine("Computations finished. {0} ms", ms);
            output.WriteLine("\r\n\r\nFinished work for {0}\r\n\r\n\r\n", id);
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
	}
}
