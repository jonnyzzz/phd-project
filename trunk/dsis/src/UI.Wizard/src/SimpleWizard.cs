using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace DSIS.UI.Wizard
{
  public class SimpleWizard : IWizardPack
  {
    private readonly SimplePage myFirst;

    public SimpleWizard(IEnumerable<IWizardPage> myPages)
    {
      Title = string.Empty;

      var e = myPages.GetEnumerator();
      if (!e.MoveNext())
      {
        throw new ArgumentException("Empty collection is not supported");
      }
      myFirst = BuildPages(e);
    }

    private static SimplePage BuildPages(IEnumerator<IWizardPage> enu)
    {
      var page = enu.Current;
      var next = enu.MoveNext() ? BuildPages(enu) : null;

      return new SimplePage(next, page);
    }

    public string Title { get; set;}

    public IWizardPage FirstPage {get { return myFirst;}}

    public bool IsLastPage(IWizardPage page)
    {
      return ((SimplePage)page).Next == null;
    }

    public IWizardPage Next(IWizardPage page)
    {
      return ((SimplePage)page).Next;
    }

    public virtual void OnFinish()
    {
    }

    public virtual void OnCancel()
    {
    }

    public void PageShown(IWizardPage page)
    {      
    }


    private class SimplePage : IWizardPage
    {
      public readonly IWizardPage Next;
      private readonly IWizardPage myPage;

      public SimplePage(IWizardPage next, IWizardPage myPage)
      {
        Next = next;
        this.myPage = myPage;
      }

      public string Title
      {
        get { return myPage.Title; }
      }

      public Control Control
      {
        get { return myPage.Control; }
      }

      public bool Validate()
      {
        return myPage.Validate();
      }

      public void ControlShown()
      {
        myPage.ControlShown();
      }

      public void ControlHidden()
      {
        myPage.ControlHidden();
      }
    }
  }

}