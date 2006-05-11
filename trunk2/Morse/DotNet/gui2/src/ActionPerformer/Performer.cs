using System;
using System.Collections;
using EugenePetrenko.Gui2.Application.Forms;
using EugenePetrenko.Gui2.Application.Runner;
using EugenePetrenko.Gui2.Application.TreeNodes;
using EugenePetrenko.Gui2.Kernell2.Actions;
using EugenePetrenko.Gui2.Kernell2.Node;
using EugenePetrenko.Gui2.Logging;

namespace EugenePetrenko.Gui2.Application.ActionPerformer
{
  public delegate void NewNodesEvent(Node[] node);

  public delegate void StateEvent();

  public delegate void StateException(Exception e);

  public class Performer
  {
    private readonly ActionChain chain;
    private readonly ProgressBarInfo progressBarInfo;
    private readonly ResultSet result;

    public event NewNodesEvent NewNode;
    public event StateEvent Started;
    public event StateEvent Finished;
    public event StateException Exception;

    private volatile bool inProcess = false;

    public Performer(ResultSet result, ActionChain chain, ProgressBarInfo progressBarInfo)
    {
      this.chain = chain;
      this.progressBarInfo = progressBarInfo;
      this.result = result;
    }

    public void Do()
    {
      DateTime start = DateTime.Now;
      
      FireStateChanged(Started);
      inProcess = true;
      try
      {
        Logger.LogMessage("Computation Started");
        ResultSet resultSet = chain.Do(result, progressBarInfo);
        Logger.LogMessage("Comutation result set = {0}", resultSet.ToString());

        if (NewNode != null && chain.PublishResults)
        {
          KernelNode[] kernelNodes = resultSet.ToNodes;
          ArrayList nodes = new ArrayList();
          foreach (KernelNode kernelNode in kernelNodes)
          {
            nodes.Add(new Node(kernelNode, Runner.Runner.Instance.Document.KernelDocument.Function.Iterations));
          }
          FireNewNodeEvent((Node[]) nodes.ToArray(typeof (Node)));
        }
      }
      catch (Exception e)
      {
        FireException(e);
      }
      finally
      {
        progressBarInfo.ProcessFinished();
        inProcess = false;
        Logger.LogMessage("Computation Finished");

        FireStateChanged(Finished);
        
        Runner.Runner.Instance.Document.UpdateTimeSpan(DateTime.Now - start);
      }
    }

    private void DoInThread(object[] data)
    {
      Do();
    }

    public RunInThread ThreadedDo()
    {
      return new RunInThread(DoInThread);
    }

    private void FireException(Exception e)
    {
      if (Exception == null)
        return;

      ComputationForm form = Runner.Runner.Instance.ComputationForm;
      if (form.InvokeRequired)
        form.BeginInvoke(Exception, new object[] {e});
      else
        Exception(e);
    }

    private void FireStateChanged(StateEvent state)
    {
      if (state == null)
        return;

      ComputationForm form = Runner.Runner.Instance.ComputationForm;
      if (form.InvokeRequired)
        form.BeginInvoke(state, new object[] {});
      else
        state();
    }

    private void FireNewNodeEvent(Node[] nodes)
    {
      ComputationForm form = Runner.Runner.Instance.ComputationForm;
      if (form.InvokeRequired)
        form.BeginInvoke(new InvokeDelegate(Invoke), new object[] {nodes});
      else
        Invoke(nodes);
    }

    private delegate void InvokeDelegate(Node[] nodes);

    private void Invoke(Node[] nodes)
    {
      if (NewNode != null)
        NewNode(nodes);
    }

    public bool InProcess
    {
      get { return inProcess; }
    }
  }
}