using System;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;
using EugenePetrenko.Gui2.Actions.Parameters;
using EugenePetrenko.Gui2.Controls.Control;

namespace EugenePetrenko.Gui2.Application.Forms
{
  /// <summary>
  /// Summary description for ParametersSelector.
  /// </summary>
  public class ParametersSelector : Form
  {
    private readonly ParametersControl[] controls;
    private Panel panelParameters;
    private Panel panelControl;
    private Button buttonBack;
    private Button buttonNext;
    private Button buttonCancel;
    private StatusBar statusBar;
    private Splitter splitter;
    private GroupBox parameterCaptionBox;
    private Panel panelParametersContainer;

    /// <summary>
    /// Required designer variable.
    /// </summary>
    private Container components = null;

    private int parameterIndex = 0;

    private ParametersControl CurrentParameterControl
    {
      get { return controls[parameterIndex]; }
    }

    public ParametersSelector(ParametersControl[] controls)
    {
      this.controls = OptimizeControls(controls);
      InitializeComponent();
      parameterIndex = 0;
    }

    private ParametersControl[] OptimizeControls(ParametersControl[] controls)
    {
      ArrayList list = new ArrayList();
      foreach (ParametersControl control in controls)
      {
        if (!control.NeedShowForm)
          control.SubmitData();
        else
          list.Add(control);
      }
      return (ParametersControl[]) list.ToArray(typeof (ParametersControl));
    }

    private const string Title = "Parameters for Action {0} of {1}";

    private void ShowCurrentParameterControl()
    {
      panelParametersContainer.Controls.Clear();
      panelParametersContainer.Controls.Add(CurrentParameterControl);
      CurrentParameterControl.Dock = DockStyle.Fill;
      parameterCaptionBox.Text = CurrentParameterControl.BoxCaption;
      Text = string.Format(Title, parameterIndex + 1, controls.Length);
    }

    public DialogResult ShowDialogOptimized(IWin32Window owner)
    {
      if (controls.Length == 0) return DialogResult.OK;
      ShowCurrentParameterControl();
      return ShowDialog(owner);
    }

    /// <summary>
    /// Clean up any resources being used.
    /// </summary>
    protected override void Dispose(bool disposing)
    {
      if (disposing)
      {
        if (components != null)
        {
          components.Dispose();
        }
      }
      base.Dispose(disposing);
    }

    #region Windows Form Designer generated code

    /// <summary>
    /// Required method for Designer support - do not modify
    /// the contents of this method with the code editor.
    /// </summary>
    private void InitializeComponent()
    {
      System.Resources.ResourceManager resources = new System.Resources.ResourceManager(typeof (ParametersSelector));
      this.panelParameters = new System.Windows.Forms.Panel();
      this.parameterCaptionBox = new System.Windows.Forms.GroupBox();
      this.panelParametersContainer = new System.Windows.Forms.Panel();
      this.panelControl = new System.Windows.Forms.Panel();
      this.statusBar = new System.Windows.Forms.StatusBar();
      this.buttonCancel = new System.Windows.Forms.Button();
      this.buttonBack = new System.Windows.Forms.Button();
      this.buttonNext = new System.Windows.Forms.Button();
      this.splitter = new System.Windows.Forms.Splitter();
      this.panelParameters.SuspendLayout();
      this.parameterCaptionBox.SuspendLayout();
      this.panelControl.SuspendLayout();
      this.SuspendLayout();
      // 
      // panelParameters
      // 
      this.panelParameters.Controls.Add(this.parameterCaptionBox);
      this.panelParameters.Dock = System.Windows.Forms.DockStyle.Fill;
      this.panelParameters.DockPadding.All = 10;
      this.panelParameters.Location = new System.Drawing.Point(0, 0);
      this.panelParameters.Name = "panelParameters";
      this.panelParameters.Size = new System.Drawing.Size(416, 382);
      this.panelParameters.TabIndex = 0;
      // 
      // parameterCaptionBox
      // 
      this.parameterCaptionBox.Controls.Add(this.panelParametersContainer);
      this.parameterCaptionBox.Dock = System.Windows.Forms.DockStyle.Fill;
      this.parameterCaptionBox.Location = new System.Drawing.Point(10, 10);
      this.parameterCaptionBox.Name = "parameterCaptionBox";
      this.parameterCaptionBox.Size = new System.Drawing.Size(396, 362);
      this.parameterCaptionBox.TabIndex = 0;
      this.parameterCaptionBox.TabStop = false;
      this.parameterCaptionBox.Text = "ParametersCaption";
      // 
      // panelParametersContainer
      // 
      this.panelParametersContainer.Dock = System.Windows.Forms.DockStyle.Fill;
      this.panelParametersContainer.DockPadding.All = 10;
      this.panelParametersContainer.Location = new System.Drawing.Point(3, 16);
      this.panelParametersContainer.Name = "panelParametersContainer";
      this.panelParametersContainer.Size = new System.Drawing.Size(390, 343);
      this.panelParametersContainer.TabIndex = 0;
      // 
      // panelControl
      // 
      this.panelControl.Controls.Add(this.statusBar);
      this.panelControl.Controls.Add(this.buttonCancel);
      this.panelControl.Controls.Add(this.buttonBack);
      this.panelControl.Controls.Add(this.buttonNext);
      this.panelControl.Dock = System.Windows.Forms.DockStyle.Bottom;
      this.panelControl.Location = new System.Drawing.Point(0, 382);
      this.panelControl.Name = "panelControl";
      this.panelControl.Size = new System.Drawing.Size(416, 64);
      this.panelControl.TabIndex = 1;
      // 
      // statusBar
      // 
      this.statusBar.Location = new System.Drawing.Point(0, 42);
      this.statusBar.Name = "statusBar";
      this.statusBar.Size = new System.Drawing.Size(416, 22);
      this.statusBar.TabIndex = 3;
      // 
      // buttonCancel
      // 
      this.buttonCancel.Anchor = System.Windows.Forms.AnchorStyles.Left;
      this.buttonCancel.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
      this.buttonCancel.Location = new System.Drawing.Point(160, 16);
      this.buttonCancel.Name = "buttonCancel";
      this.buttonCancel.Size = new System.Drawing.Size(104, 24);
      this.buttonCancel.TabIndex = 2;
      this.buttonCancel.Text = "Cancel";
      this.buttonCancel.Click += new System.EventHandler(this.buttonCancel_Click);
      // 
      // buttonBack
      // 
      this.buttonBack.Anchor = System.Windows.Forms.AnchorStyles.Left;
      this.buttonBack.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
      this.buttonBack.Location = new System.Drawing.Point(40, 16);
      this.buttonBack.Name = "buttonBack";
      this.buttonBack.Size = new System.Drawing.Size(104, 24);
      this.buttonBack.TabIndex = 1;
      this.buttonBack.Text = "Back";
      this.buttonBack.Click += new System.EventHandler(this.buttonBack_Click);
      // 
      // buttonNext
      // 
      this.buttonNext.Anchor = System.Windows.Forms.AnchorStyles.Left;
      this.buttonNext.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
      this.buttonNext.Location = new System.Drawing.Point(280, 16);
      this.buttonNext.Name = "buttonNext";
      this.buttonNext.Size = new System.Drawing.Size(104, 24);
      this.buttonNext.TabIndex = 0;
      this.buttonNext.Text = "Next";
      this.buttonNext.Click += new System.EventHandler(this.buttonNext_Click);
      // 
      // splitter
      // 
      this.splitter.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
      this.splitter.Dock = System.Windows.Forms.DockStyle.Bottom;
      this.splitter.Enabled = false;
      this.splitter.Location = new System.Drawing.Point(0, 379);
      this.splitter.Name = "splitter";
      this.splitter.Size = new System.Drawing.Size(416, 3);
      this.splitter.TabIndex = 2;
      this.splitter.TabStop = false;
      // 
      // ParametersSelector
      // 
      this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
      this.ClientSize = new System.Drawing.Size(416, 446);
      this.Controls.Add(this.splitter);
      this.Controls.Add(this.panelParameters);
      this.Controls.Add(this.panelControl);
      this.Icon = ((System.Drawing.Icon) (resources.GetObject("$this.Icon")));
      this.Name = "ParametersSelector";
      this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
      this.Text = "ParametersSelector";
      this.panelParameters.ResumeLayout(false);
      this.parameterCaptionBox.ResumeLayout(false);
      this.panelControl.ResumeLayout(false);
      this.ResumeLayout(false);
    }

    #endregion

    private void buttonCancel_Click(object sender, EventArgs e)
    {
      DialogResult = DialogResult.Cancel;
    }

    private void buttonBack_Click(object sender, EventArgs e)
    {
      if (parameterIndex >= 1)
      {
        parameterIndex--;
        ShowCurrentParameterControl();
      }
    }

    private void buttonNext_Click(object sender, EventArgs e)
    {
      try
      {
        CurrentParameterControl.SubmitData();
        if (parameterIndex + 1 < controls.Length)
        {
          parameterIndex++;
          ShowCurrentParameterControl();
        }
        else
        {
          DialogResult = DialogResult.OK;
        }
      }
      catch (ControlException ee)
      {
        MessageBox.Show(this, ee.ErrorDescription, "Error filling parameters", MessageBoxButtons.OK,
                        MessageBoxIcon.Error);
      }
    }
  }
}