using System;
using System.IO;
using System.Xml;
using Eugene.Petrenko.Gui2.MethodComparer.Actions;
using EugenePetrenko.Gui2.Kernell2.Actions;
using EugenePetrenko.Gui2.Kernell2.Node;
using EugenePetrenko.Gui2.MorseKernel2;

namespace Eugene.Petrenko.Gui2.MethodComparer
{
	/// <summary>
	/// Summary description for IteratingActionWraper.
	/// </summary>
	public class IteratingAction
	{
	    private readonly IDefinedAction[] actions;

		private readonly ResultSet resultSet;
	    private readonly int power;
	    private readonly ExportToPointsDefinedAction saveAction;
	    private string name;	
		
	
		private const int UPPER_LIMIT_NODES = 2500000/5; //2.5M * dim = upper_limit

		public IteratingAction(ResultSet resultSet, string name, int power, ExportToPointsDefinedAction saveAction, params IDefinedAction[] actions)
		{
		    this.actions = actions;
	    	this.resultSet = resultSet;
	        this.name = name;
	        this.power = power;
	        this.saveAction = saveAction;
		}

        public string Name 
        { 
           get { return name; }
        }		

		public void Compute(ResultDumper dumper)
        {
            Do(resultSet, dumper);
        }

        protected ResultSet Do(ResultSet set, ResultDumper dumper)
        {
            dumper.DoStarted();
            for (int i=0; i<power; i++)
            {
                dumper.IterationStarted(i, power);
                foreach (IDefinedAction action in actions)
                {
                    if (set.Count != 0)
                    {
                        dumper.ActionStarted(action, i, power);
                        PerformAction(action, ref set);
                        dumper.ActionFinished(action,i, power);
                        dumper.DumpResultSet(set);
                    } else
                    {
                        dumper.EmptyResultSet();
                    }
                    GC.Collect();
                    GC.WaitForPendingFinalizers();
                    GC.Collect();
                }
                dumper.IterationFinished(i, power);
				if (!CheckUpperLimit(set)) 	
				{
					dumper.IterationAbortedTooBigGraph(i, power);
					break;
				}
            }
            dumper.SavingResultsStarted();
            
            using(TextWriter tw = File.CreateText(saveAction.LocalLogFile))
            {
                tw.WriteLine(dumper.GetLogFileText());
            }

			using(TextWriter tw = File.CreateText(saveAction.LocalXmlLogFile))
			{
				dumper.GetLogXML().Save(tw);
			}

			dumper.Parent.AppendLogMessage(dumper.GetLogXMLContent(), Name);

            dumper.WriteBuildCommand("cd {0}", saveAction.GlobalPath);
            dumper.WriteBuildCommand("wgnuplot {0}", saveAction.GnuPlotFile);            
            PerformAction(saveAction, ref set);

            dumper.SavingResultsFinished();
            dumper.DoFinished();

            return set;
        }

		private bool CheckUpperLimit(ResultSet set)
		{
			foreach (IResult result in set)
			{
				IGraphResult graphResult = result as IGraphResult;
				if (graphResult != null) 
				{
					IGraphInfo info = graphResult.GetGraphInfo();
					if (info.GetNodes()/info.GetDimension() > UPPER_LIMIT_NODES) 
						return false;
				}
			}
			return true;
		}

	    private static void PerformAction(IDefinedAction action, ref ResultSet set)
	    {
	        ActionWrapper wrapper = new ActionWrapper(action.Action, action.GetParameters(set), action.Name);
	        set = wrapper.Do(set, new ProgressBarInfo(new EmptyProgressBarListener()));
	    }
	}
}