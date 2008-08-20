using System;
using System.Windows.Forms;
using EugenePetrenko.Gui2.Application.Forms;
using EugenePetrenko.Gui2.Application.TreeNodes;
using EugenePetrenko.Gui2.Controls.TreeControl;
using EugenePetrenko.Gui2.Kernell2.Document;

namespace EugenePetrenko.Gui2.Application.Document
{
  public class Document : IDisposable
  {
    private KernelDocument kernelDocument;
    private Node rootNode = null;
    private SystemFunctionAnalisys analisysForm = null;
    private TimeSpan workTime = TimeSpan.Zero;

    public Document(Function function)
    {
      kernelDocument = new KernelDocument(function);
      rootNode = new Node(kernelDocument.CreateInitialNode(), function.Iterations);
    }

    public Document(Function function, Node root)
    {
      kernelDocument = new KernelDocument(function);
      rootNode = root;
    }

    public KernelDocument KernelDocument
    {
      get { return kernelDocument; }
      set { kernelDocument = value; }
    }

    public TimeSpan WorkTime
    {
      get { return workTime; }
    }

    public Node RootNode
    {
      get { return rootNode; }
    }
    
    public void UpdateTimeSpan(TimeSpan span)
    {
      lock(this)
      {
        workTime += span;
      }
    }

    public void Lock()
    {
      Runner.Runner.Instance.ComputationForm.Lock();
    }

    public void UnLock()
    {
      Runner.Runner.Instance.ComputationForm.Unlock();
    }

    public SystemFunctionAnalisys AnalisysForm
    {
      get { return analisysForm; }
      set { analisysForm = value; }
    }

    public void DisposeOnExit()
    {
      if (analisysForm != null)
        analisysForm.Close();

      rootNode = null;
    }
    
    public void Dispose()
    {
      if (analisysForm != null)
        analisysForm.Close();
      
      if (rootNode != null)
        RecursiveDisposeNode(rootNode);
      
      rootNode = null;
    }
    
    private void RecursiveDisposeNode(ComputationNode root)
    {      
      foreach (TreeNode treeNode in root.Nodes)
      {
        ComputationNode node = treeNode as ComputationNode;
        if (node != null)
          RecursiveDisposeNode(node);
      }
            
      root.Nodes.Clear();
      root.Dispose();      
    }
  }
}