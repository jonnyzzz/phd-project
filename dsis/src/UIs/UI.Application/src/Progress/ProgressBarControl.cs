using System;
using System.Drawing;
using System.Windows.Forms;
using DSIS.UI.UI;
using DSIS.Utils;
using JetBrains.Annotations;

namespace DSIS.UI.Application.Progress
{
  public partial class ProgressBarControl : UserControl
  {
    private readonly IInvocator myInvocator;
    private readonly IProgressBarControlModel myModel;
    private readonly Disposables myDisposer = new Disposables();

    private bool myIsDisabled = true;
    private int myValue;
    private int myMaximum;
    private string myText;

    public ProgressBarControl([NotNull] IProgressBarControlModel model, [NotNull] IInvocator invocator)
    {
      myModel = model;
      myInvocator = invocator;

      InitializeComponent();
      TabStop = false;     
      SetDisabled();
      myDisposer.Subscribe(this);

      myDisposer.Add(
        myInvocator.ExecuteRepeating(
          "Update progress bar",
          TimeSpan.FromSeconds(1),
          () =>
            {
              if (UpdateDisabled()) return;
              
                var m = false
                        || !UpdateProgressText()
                        || !UpdateProgressValue();

                myProgressBar.Style = m 
                  ? ProgressBarStyle.Marquee 
                  : ProgressBarStyle.Continuous;
            }
          )
        );
    }

    private void SetDisabled()
    {
      myCancel.Visible = false;
      myMainLabel.Text = "Idle";
      myProgressBar.Enabled = false;
      myProgressBar.Style = ProgressBarStyle.Continuous;
      myProgressBar.Value = 0;
    }

    private bool UpdateDisabled()
    {
      bool disabled = myModel.Disabled;
      if (myIsDisabled != disabled)
      {
        myIsDisabled = disabled;
        if (disabled)
        {
          SetDisabled();
        } else
        {
          myCancel.Visible = true;
          myCancel.Enabled = true;
          myCancel.Text = "Cancel";
          myCancel.ActiveLinkColor = Color.Blue;
          myProgressBar.Enabled = true;
        }
      }

      return disabled;
    }

    private bool UpdateProgressValue()
    {
      var maximum = myModel.Maximum;
      var value = myModel.Value;

      if (myValue != value || myMaximum != maximum)
      {
        myValue = value;
        myMaximum = maximum;
        myProgressBar.Maximum = maximum;
        myProgressBar.Value = value;

        return true;
      }
      return false;
    }
    
    private bool UpdateProgressText()
    {
      var text = myModel.Text.Trim();
      if (text != myText)
      {
        myText = text;
        myMainLabel.Text = text;
        
        return true;
      }
      return false;
    }

    private void myCancel_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
    {
      myModel.Interrupt();      
      myCancel.Text = "Canceled";
      myCancel.ActiveLinkColor = Color.Red;
      myCancel.Enabled = false;

      myProgressBar.Style = ProgressBarStyle.Marquee;
    }
  }
}