using System;
using System.Collections.Generic;
using System.IO;
using System.Xml.Xsl;
using DSIS.Graph;
using DSIS.IntegerCoordinates;
using DSIS.Utils;

namespace DSIS.SimpleRunner
{
  public abstract class FullImageBuilderWithLog<T, Q> : FullImageBuilder<T, Q>
    where T : IIntegerCoordinateSystem<Q>
    where Q : IIntegerCoordinate<Q>
  {
    private readonly string myWorkPath;
    private readonly string myXmlFile;
    private readonly XmlAbstractImageBuilderListener<T, Q> myXmlListener;
    private readonly FakeEvent myFake = new FakeEvent();

    protected FullImageBuilderWithLog(string workPath, long stepLimit, long cellsLimit) : base(stepLimit, cellsLimit)
    {
      myWorkPath = workPath;
      UseUnsimmetric = true;

      myXmlFile = Path.Combine(myWorkPath, "log.xml");

      myXmlListener = new XmlAbstractImageBuilderListener<T, Q>(myXmlFile);

      AddListener(new ConsoleListener<T, Q>());
      AddListener(myXmlListener);

      AddListener(new ComputationPathListener<T, Q>(myWorkPath));

      AddListener(new DrawLastComputationResultListener<T, Q>());

      AddListener(myFake);

      AddListener<ComputeEntropyListener<T, Q>>("Const");
      AddListener<ComputeEntropySquareListener<T, Q>>("Square");
      AddListener<ComputeEntropyLinearListener<T, Q>>("Linear");

//      AddListener(new ComputeEntropyListener<T, Q>());      
//      AddListener(new ComputeEntropySquareListener<T,Q>());      
//      AddListener(new ComputeEntropyLinearListener<T,Q>());      
//      AddListener(new ComputeJVREntropySquareListener<T,Q>());
    }

    private void AddListener<_>(string __) where _ : ComputeEntropyListenerBase<T, Q>, new()
    {
      _ ___ = new _();
      AddListener(___, __);
    }

    private void AddListener(ComputeEntropyListenerBase<T, Q> listener, string suffix)
    {
      DrawEntropyListener<T, Q> l = new DrawEntropyListener<T, Q>(suffix);
      listener.AddListener(l);
      myFake.AddListener(l);
      AddListener(listener);
    }

    public void ApplyXSL(IEnumerable<string> xslFiles)
    {
      foreach (string file in xslFiles)
      {
        XslCompiledTransform transform = new XslCompiledTransform(false);
        transform.Load(file);
        transform.Transform(myXmlFile, myXmlFile + Path.GetFileNameWithoutExtension(file) + ".html");
      }
    }

    private class FakeEvent : AbstractImageBuilderListener<T, Q>, IComputationPathListener
    {
      private readonly List<DrawEntropyListener<T, Q>> myListeners = new List<DrawEntropyListener<T, Q>>();
      
      IEnumerable<Pair<string, Action<string>>> IComputationPathListener.FormatPath
      {
        get
        {
          foreach (IComputationPathListener listener in myListeners)
          {
            foreach (Pair<string, Action<string>> pair in listener.FormatPath)
            {
              yield return pair;
            }
          }
        }
      }

      void IComputationPathListener.ComputationTitle(string title)
      {
        foreach (IComputationPathListener listener in myListeners)
        {
          listener.ComputationTitle(title);
        }
      }

      public void AddListener(DrawEntropyListener<T,Q> l)
      {
        myListeners.Add(l);
      }


      public override VoidDelegate ComputationStartedC(T system, AbstractImageBuilderContext<Q> cx, bool isUnsimmetric)
      {
        List<VoidDelegate> ds = new List<VoidDelegate>();
        ds.Add(base.ComputationStartedC(system, cx, isUnsimmetric));
        foreach (IAbstractImageBuilderListener<T, Q> listener in myListeners)
        {
          ds.Add(listener.ComputationStartedC(system, cx, isUnsimmetric));
        }
        return Merge(ds);
      }

      private static VoidDelegate Merge(IEnumerable<VoidDelegate> ds)
      {
        return delegate
                 {
                   foreach (VoidDelegate d in ds)
                   {
                     d();
                   }
                 };
      }

      public override VoidDelegate ComputationFinishedC(IGraphStrongComponents<Q> comps, IGraph<Q> graph, T system,
                                                        AbstractImageBuilderContext<Q> cx)
      {
        List<VoidDelegate> ds = new List<VoidDelegate>();
        ds.Add(base.ComputationFinishedC(comps, graph, system, cx));
        foreach (IAbstractImageBuilderListener<T, Q> listener in myListeners)
        {
          ds.Add(listener.ComputationFinishedC(comps, graph, system, cx));
        }
        return Merge(ds);
      }


      public override void OnStepStarted(T system, AbstractImageBuilderContext<Q> cx, long[] subdivide)
      {
        base.OnStepStarted(system, cx, subdivide);
        foreach (DrawEntropyListener<T, Q> listener in myListeners)
        {
          listener.OnStepStarted(system, cx, subdivide);
        }
      }
    }
  }
}