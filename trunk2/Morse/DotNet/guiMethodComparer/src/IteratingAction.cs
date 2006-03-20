using System;
using System.IO;
using Eugene.Petrenko.Gui2.MethodComparer.Actions;
using EugenePetrenko.Gui2.Kernell2.Actions;
using EugenePetrenko.Gui2.Kernell2.Node;

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
            }
            dumper.SavingResultsStarted();
            
            using(TextWriter tw = File.CreateText(saveAction.LocalLogFile))
            {
                tw.WriteLine(dumper.GetLogFileText());
            }
            dumper.WriteBuildCommand("cd {0}", saveAction.GlobalPath);
            dumper.WriteBuildCommand("wgnuplot {0}", saveAction.GnuPlotFile);            
            PerformAction(saveAction, ref set);

            dumper.SavingResultsFinished();
            dumper.DoFinished();

            return set;
        }

	    private static void PerformAction(IDefinedAction action, ref ResultSet set)
	    {
	        ActionWrapper wrapper = new ActionWrapper(action.Action, action.GetParameters(set), action.Name);
	        set = wrapper.Do(set, new ProgressBarInfo(new EmptyProgressBarListener()));
	    }
	}
}
