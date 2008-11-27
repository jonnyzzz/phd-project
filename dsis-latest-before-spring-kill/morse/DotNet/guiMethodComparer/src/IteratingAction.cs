using System;
using System.Collections;
using System.IO;
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
    private readonly bool myUnsimmetric;
    private readonly ExportToPointsDefinedAction saveAction;
    private string name;


//    private const int UPPER_LIMIT_NODES = 2500000/5; //2.5M * dim = upper_limit

    public IteratingAction(ResultSet resultSet, string name, int power, bool unsimmetric, ExportToPointsDefinedAction saveAction,
                           params IDefinedAction[] actions)
    {
      this.actions = actions;
      this.resultSet = resultSet;
      this.name = name;
      this.power = power;
      myUnsimmetric = false;
      this.saveAction = saveAction;
      
      if(unsimmetric)
      {
        foreach (IDefinedAction action in actions)
        {
          if (action is IUnsimmetricDefinedAction)
          {
            myUnsimmetric = true;
            break;
          }
        }
      }
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
      Hashtable actionToIndex = new Hashtable();      
      dumper.DoStarted();

      for (int i = 0; i < power; i++)
      {
        if (myUnsimmetric)
          foreach (IDefinedAction action in actions)
          {
            IUnsimmetricDefinedAction uAction = action as IUnsimmetricDefinedAction;
            if (uAction != null)
              actionToIndex[uAction] = uAction.UnsimmetrisSteps;
          }

        dumper.IterationStarted(i, power);
        bool endFlag;
        do
        {          
          endFlag = false;
          foreach (IDefinedAction action in actions)
          {
            IUnsimmetricDefinedAction uAction = action as IUnsimmetricDefinedAction;
            if (myUnsimmetric && uAction != null)
            {
              uAction.UseUnsimmetric = true;
              int v = (int)actionToIndex[uAction] - 1;
              actionToIndex[uAction] = v;
              uAction.UnsimmetricStep = v;
              endFlag = v > 0;
              dumper.WriteLine("!!!!! v = {0}", v);
            }
            
            if (set.Count != 0)
            {
              dumper.ActionStarted(action, i, power);
              PerformAction(action, ref set);
              dumper.ActionFinished(action, i, power);
              dumper.DumpResultSet(set);
            }
            else
            {
              dumper.EmptyResultSet();
            }
            GC.Collect();
            GC.WaitForPendingFinalizers();
            GC.Collect();
          }
          
          if (!CheckUpperLimit(set))
          {
            dumper.IterationAbortedTooBigGraph(i, power);
            break;
          }          
        } while(endFlag);
        
        dumper.IterationFinished(i, power);
        if (!CheckUpperLimit(set))
        {
          dumper.IterationAbortedTooBigGraph(i, power);
          break;
        }
      }
      dumper.SavingResultsStarted();

      using (TextWriter tw = File.CreateText(saveAction.LocalLogFile))
      {
        tw.WriteLine(dumper.GetLogFileText());
      }

      using (TextWriter tw = File.CreateText(saveAction.LocalXmlLogFile))
      {
        dumper.GetLogXML().Save(tw);
      }

      dumper.Parent.AppendLogMessage(dumper.GetLogXMLContent(), Name);

      dumper.WriteBuildCommand("cd {0}", saveAction.GlobalPath);
      dumper.WriteBuildCommand("wgnuplot {0}", saveAction.GnuPlotFile);
      PerformSaveAction(saveAction, ref set);

      dumper.SavingResultsFinished();
      dumper.DoFinished();

      return set;
    }

    private bool CheckUpperLimit(ResultSet set)
    {
      return true;
//			foreach (IResult result in set)
//			{
//				IGraphResult graphResult = result as IGraphResult;
//				if (graphResult != null) 
//				{
//					IGraphInfo info = graphResult.GetGraphInfo();
//					if (info.GetNodes()/info.GetDimension() > UPPER_LIMIT_NODES) 
//						return false;
//				}
//			}
//			return true;
    }

    private static void PerformAction(IDefinedAction action, ref ResultSet set)
    {
      ActionWrapper wrapper = new ActionWrapper(action.Action, action.GetParameters(set), action.Name);
      set = wrapper.Do(set, new ProgressBarInfo(new EmptyProgressBarListener()));
    }


    private static void PerformSaveAction(ExportToPointsDefinedAction action, ref ResultSet set)
    {
      ArrayList results = new ArrayList(set.GetCollection());
      results.Sort(new ResultSetComparer());
      set = ResultSet.FromResult((IResultBase[]) results.ToArray(typeof (IResult)));
      PerformAction(action, ref set);
    }

    private class ResultSetComparer : IComparer
    {
      public int Compare(object x, object y)
      {
        if (ReferenceEquals(x, y))
          return 0;

        IGraphResult gX = (IGraphResult) x;
        IGraphResult gY = (IGraphResult) y;

        int vX = gX.GetGraphInfo().GetNodes();
        int vY = gY.GetGraphInfo().GetNodes();

        if (vX > vY)
          return -1;
        if (vX < vY)
          return 1;

        return 0;
      }
    }
  }
}