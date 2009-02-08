using System;
using System.Collections.Generic;
using DSIS.UI.UI;
using log4net;
using DSIS.Utils;

namespace DSIS.UI.Wizard
{
  public class JoinedWizardPack : IWizardPack, IErrorProvider<bool>
  {
    private static readonly ILog LOG = LogManager.GetLogger(typeof (JoinedWizardPack));

    private WizardChainNode myCurrentWizardNode;

    public JoinedWizardPack(string title, IEnumerable<IWizardPack> wizards)
    {
      myCurrentWizardNode = WizardChainNode.Create(wizards);
      Title = title;
      if (wizards == null)
        throw new ArgumentException("Can not create joined wizard from 0 wizards");
    }

    public string Title { get; private set; }

    public IWizardPage FirstPage
    {
      get { return myCurrentWizardNode.First.Page; }
    }

    public bool IsLastPage(IWizardPage page)
    {
      return myCurrentWizardNode.Last.IsLastPage(page);
    }

    public IWizardPage Next(IWizardPage page)
    {
      if (myCurrentWizardNode.IsLastPage(page))
      {
        if (myCurrentWizardNode.Next == null)
        {
          return null;
        }

        myCurrentWizardNode = myCurrentWizardNode.Next;
        return myCurrentWizardNode.Page;
      }
      return myCurrentWizardNode.NextPage();
    }

    public Ref<string> ValidateLazy(IWizardPage page)
    {
      throw new NotImplementedException();
    }

    public void OnFinish()
    {
      myCurrentWizardNode.Each(x => Try(x, "OnCancel", () => x.OnFinish()));
    }

    public void OnCancel()
    {
      myCurrentWizardNode.Each(x => Try(x, "OnCancel", () => x.OnCancel()));
    }

    private static void Try(IWizardPack pack, string name, Action a)
    {
      try
      {
        a();
      }
      catch (Exception e)
      {
        LOG.Error(
          string.Format("Failed to process action {0} on wizard {1} ({2}). {3}", name, pack.Title, pack.GetType(), e.Message), e);
      }
    }

    public void PageShown(IWizardPage page)
    {
      myCurrentWizardNode.PageShown(page);
    }

    private class WizardChainNode
    {
      public readonly IWizardPack Pack;
      public readonly WizardChainNode Next;
      public readonly WizardChainNode Prev;

      private WizardChainNode myCachedFirst;
      private WizardChainNode myCachedLast;

      public IWizardPage Page{ get; private set;}

      private WizardChainNode(WizardChainNode prev, IEnumerator<IWizardPack> enu)
      {        
        Prev = prev;
        Pack = enu.Current;
        Next = enu.MoveNext() ? new WizardChainNode(this, enu) : null;
        Page = Pack.FirstPage;
      }

      public static WizardChainNode Create(IEnumerable<IWizardPack> enu)
      {
        using(var en = enu.GetEnumerator())
        {
          if (en.MoveNext())
            return new WizardChainNode(null, en);

          return null;
        }
      }

      public void AssertCurrentPage(IWizardPage page) {
        if (!ReferenceEquals(page, Page))
          LOG.ErrorFormat("Page is not created by the current wizard state. Expected {0}, but was {1}", Page, page);
      }

      public bool IsLastPage(IWizardPage page)
      {
        AssertCurrentPage(page);
        return Pack.IsLastPage(page);
      } 

      public WizardChainNode First
      {
        get { return myCachedFirst ?? (myCachedFirst = Prev == null ? this : Prev.First); }
      }

      public WizardChainNode Last
      {
        get { return myCachedLast ?? (myCachedLast = Next == null ? this : Next.Last); }
      }

      public T Fold<T>(T def, Func<IWizardPack, T, T> func)
      {
        for (var node = First; node != null; node = node.Next)
        {
          try
          {
            def = func(node.Pack, def);
          }
          catch (Exception e)
          {
            LOG.Error(string.Format("Failed to proceed action on {0}. {1}", node.Pack, e.Message), e);
          }
        }
        return def;
      }

      public void Each(Action<IWizardPack> page)
      {
        Fold(0, (p, v) =>
                  {
                    page(p);
                    return v;
                  });
      }

      public IWizardPage NextPage()
      {
        var next = Pack.Next(Page);
        if (next == null)
        {
          LOG.ErrorFormat("Next Page for {0} is null.", Page);
          throw new ArgumentException("Page can not be null. Use IsLastPage to check it");
        }
        return Page = next;
      }

      public void PageShown(IWizardPage page)
      {
        AssertCurrentPage(page);
        Pack.PageShown(page);
      }
    }

    public bool Validate()
    {
      return myCurrentWizardNode.Fold(false, (x, v)=> x.OfType<IErrorProvider<bool>, bool>(false, p=>p.Validate()));
    }
  }
}