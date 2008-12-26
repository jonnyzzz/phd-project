using System;
using System.Collections.Generic;
using log4net;

namespace DSIS.UI.Wizard
{
  public class JoinedWizardPack : IWizardPack
  {
    private static readonly ILog LOG = LogManager.GetLogger(typeof (JoinedWizardPack));

    private WizardChainNode myCurrentWizardNode;

    public JoinedWizardPack(string title, IEnumerable<IWizardPack> wizards)
    {
      myCurrentWizardNode = WizardChainNode.Create(wizards);
      Title = title;
      if (wizards == null)
      {
        throw new ArgumentException("Can not create joined wizard from 0 wizards");
      }
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

    public void OnFinish()
    {
      myCurrentWizardNode.Each(x => Try(x, "OnCancel", () => x.OnCancel()));
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

    private class JoinedPage
    {
      public readonly IWizardPack myWizard;
      public readonly IWizardPage myPage;

      public JoinedPage(IWizardPack wizard, IWizardPage page)
      {
        myWizard = wizard;
        myPage = page;
      }
    }

    private class WizardChainNode
    {
      public readonly IWizardPack Pack;
      public readonly WizardChainNode Next;
      public readonly WizardChainNode Prev;

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
          {
            return new WizardChainNode(null, en);
          }
          return null;
        }
      }

      public void AssertCurrentPage(IWizardPage page) {
      }

      public bool IsLastPage(IWizardPage page)
      {
        throw new NotImplementedException();
      } 

      public WizardChainNode First
      {
        get { return Prev == null ? this : Prev.First; }
      }

      public WizardChainNode Last
      {
        get { return Next == null ? this : Next.Last; }
      }

      public void Each(Action<IWizardPack> page)
      {
        for(var node = First; node != null; node = node.Next)
        {
          try
          {
            page(node.Pack);
          } catch(Exception e)
          {
            LOG.Error(string.Format("Failed to proceed action on {0}. {1}", node.Pack, e.Message), e);
          }
        }
      }

      public IWizardPage NextPage()
      {
        Page = Pack.Next(Page);
        if (Page == null)
        {
          throw new ArgumentException("Page can not be null. Use IsLastPage to check it");
        }
        return Page;
      }

      public void PageShown(IWizardPage page)
      {
        AssertCurrentPage(page);
        Pack.PageShown(page);
      }
    }

    private class JoinedWizardCollection : List<JoinedPage>
    {
      public IWizardPack FindForPage(IWizardPage page)
      {
        foreach (var joinedPage in this)
        {
          if (Equals(joinedPage.myPage))
          {
            return joinedPage.myWizard;
          }
        }
        return null;
      }

      public IWizardPage CreatePage(IWizardPack pack, Func<IWizardPack, IWizardPage> fn)
      {
        var page = fn(pack);
        Add(new JoinedPage(pack, page));
        return page;
      }
    }
  }
}