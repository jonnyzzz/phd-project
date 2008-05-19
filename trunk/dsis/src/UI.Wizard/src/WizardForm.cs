using System;
using System.Collections.Generic;
using System.Drawing;
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

      Text = myHeader.MainTitle = model.Title;

      var firstPage = myPack.FirstPage;
      myPages.Push(firstPage);
      ShowPage(firstPage, null);
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
      ErrorHandler.Safe(page.ControlShown);

      myButtonsTimer.Enabled = true;
    }

    private void UpdateButtonState(IWizardPage page)
    {
      bool status = ErrorHandler.Safe<bool>(page.Validate);

      myHeader.SecondaryTitle = page.Title;
      myButtons.ButtonFinish.Enabled = status && myPack.IsLastPage(page);
      myButtons.ButtonNext.Enabled = status && myPack.Next(page) != null;
      myButtons.ButtonBack.Enabled = myPages.Count > 1;            
    }

    private void myButtonsTimer_Tick(object sender, EventArgs e)
    {
      if (myPages.Count > 0)
      {
        myButtonsTimer.Enabled = false;
        UpdateButtonState(myPages.Peek());
        myButtonsTimer.Enabled = true;
      }
    }
  }
}