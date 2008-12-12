using System;
using System.Collections.Generic;
using System.Windows.Forms;
using DSIS.UI.UI;
using DSIS.Utils;

namespace DSIS.UI.Wizard
{
  public partial class WizardForm : Form
  {
    private readonly IWizardPack myPack;
    private readonly Dictionary<IWizardPage, Panel> myCachedViwes = new Dictionary<IWizardPage, Panel>();
    private readonly Stack<IWizardPage> myPages = new Stack<IWizardPage>();
    private bool myIsUnderTimer = false;

    public WizardForm() : this(new EmptyWizard())
    {
    }

    public WizardForm(IWizardPack model)
    {
      ErrorHandler = NoSafe.Instance;
      myPack = model;
      InitializeComponent();
      AcceptButton = myButtons.ButtonFinish;
      CancelButton = myButtons.ButtonCancel;
      myButtons.ButtonNext.Click += ButtonNextClick;
      myButtons.ButtonBack.Click += ButtonBackClick;
      myButtons.ButtonFinish.Click += ButtonFinishClick;
      myButtons.ButtonCancel.Click += ButtonCancelClick;

      Text = myHeader.MainTitle = model.Title;

      var firstPage = myPack.FirstPage;
      myPages.Push(firstPage);
      ShowPage(firstPage, null);
    }

    private void ButtonCancelClick(object sender, EventArgs e)
    {
      ErrorHandler.Safe(myPack.OnCancel);
      DialogResult = DialogResult.Cancel;
    }

    private void ButtonFinishClick(object sender, EventArgs e)
    {
      if (myPages.Count == 0)
      {
        MessageBox.Show(this, "Unable to finish wizard. No active page shown", Text, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
        return;
      }
      if (!myPack.IsLastPage(myPages.Peek()))
      {
        MessageBox.Show(this, "Unable to finish wizard. This is not the last page", Text, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
        return;
      }

      ErrorHandler.Safe(myPack.OnFinish);

      DialogResult = DialogResult.OK;
    }

    private void ButtonNextClick(object sender, EventArgs args)
    {
      var currentPage = myPages.Peek();
      var nextPage = myPack.Next(currentPage);
      if (nextPage == null)
      {
        MessageBox.Show(this, "No next page defined for wizard", Text, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
        return;
      }
      myPages.Push(nextPage);
      ShowPage(nextPage, currentPage);
    }
    
    private void ButtonBackClick(object sender, EventArgs args)
    {
      if (myPages.Count <= 1)
      {
        MessageBox.Show(this, "No next page defined for wizard", Text, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
        return;
      }
      var curentPage = myPages.Pop();
      var nextPage = myPages.Peek();
      ShowPage(nextPage, curentPage);
    }

    public ISafe ErrorHandler { get; set;}

    private void ShowPage(IWizardPage page, IWizardPage prevPage)
    {
      myButtonsTimer.Enabled = false;

      if (prevPage != null)
        ErrorHandler.Safe(prevPage.ControlHidden);

      using (myMiddleContainer.UpdateCookie())
      {
        foreach (Control control in myMiddleContainer.Controls)
        {
          control.Visible = control.Enabled = false;
        }

        Panel panel;
        if (!myCachedViwes.TryGetValue(page, out panel))
        {
          panel = new Panel { Dock = DockStyle.Fill };
          var pageContent = page.Control;
          myMiddleContainer.AutoScrollMinSize = pageContent.Size;
          pageContent.Dock = DockStyle.Fill;
          panel.Controls.Add(pageContent);

          myCachedViwes[page] = panel;

          myMiddleContainer.Controls.Add(panel);
        }
        else
        {
          panel.Visible = panel.Enabled = true;
        }

        UpdateButtonState(page);
      }
      ErrorHandler.Safe(() => myPack.PageShown(page));
      ErrorHandler.Safe(page.ControlShown);

      myButtonsTimer.Enabled = true;
    }

    private void UpdateButtonState(IWizardPage page)
    {
      var status = ErrorHandler.Safe(page.Validate, false);

      myHeader.SecondaryTitle = page.Title;
      bool isLastPage = myPack.IsLastPage(page);


      myButtons.FinishEnabled = status && isLastPage;
      myButtons.NextEnabled = status && !isLastPage;
      myButtons.BackEnabled = myPages.Count > 1;            
    }

    private void myButtonsTimer_Tick(object sender, EventArgs e)
    {
      if (myIsUnderTimer || myPages.Count == 0)
        return;

      try
      {
        myIsUnderTimer = true;
        UpdateButtonState(myPages.Peek());
      }
      finally
      {
        myIsUnderTimer = false;
      }
    }
  }
}