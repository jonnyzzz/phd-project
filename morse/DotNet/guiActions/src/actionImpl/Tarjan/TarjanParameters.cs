using System.ComponentModel;
using System.Windows.Forms;
using EugenePetrenko.Gui2.Actions.Parameters;
using EugenePetrenko.Gui2.MorseKernel2;

namespace EugenePetrenko.Gui2.Actions.ActionImpl.Tarjan
{
  public class TarjanParameters : ParametersControl
  {
    private CheckBox resolveEdges;
    private Container components = null;


    public TarjanParameters()
    {
      InitializeComponent();
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

    #region Component Designer generated code

    /// <summary> 
    /// Required method for Designer support - do not modify 
    /// the contents of this method with the code editor.
    /// </summary>
    private void InitializeComponent()
    {
      this.resolveEdges = new System.Windows.Forms.CheckBox();
      this.SuspendLayout();
      // 
      // resolveEdges
      // 
      this.resolveEdges.Dock = System.Windows.Forms.DockStyle.Fill;
      this.resolveEdges.Location = new System.Drawing.Point(5, 5);
      this.resolveEdges.Name = "resolveEdges";
      this.resolveEdges.Size = new System.Drawing.Size(222, 102);
      this.resolveEdges.TabIndex = 0;
      this.resolveEdges.Text = "Resolve Edges";
      // 
      // TarjanParameters
      // 
      this.Controls.Add(this.resolveEdges);
      this.DockPadding.All = 5;
      this.Name = "TarjanParameters";
      this.Size = new System.Drawing.Size(232, 112);
      this.ResumeLayout(false);
    }

    #endregion

    protected override IParameters SubmitDataInternal()
    {
      return new TarjanParametersImpl(resolveEdges.Checked);
    }

    public override string BoxCaption
    {
      get { return "Strong Component localization"; }
    }
  }
}