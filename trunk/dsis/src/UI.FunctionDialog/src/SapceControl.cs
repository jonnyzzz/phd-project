using System;
using System.Windows.Forms;

namespace DSIS.UI.FunctionDialog
{
  public partial class SapceControl : UserControl
  {
    private readonly SpaceModel myModel;

    public SapceControl() : this(new SpaceModel())
    {
    }

    public SapceControl(SpaceModel model)
    {
      model.OnModelChanged += OnModelChanged;
      myModel = model;
      InitializeComponent();
      Synch();
    }

    private void OnModelChanged(object sender, EventArgs e)
    {
      Synch();
    }

    private void myDimension_ValueChanged(object sender, EventArgs e)
    {
      myModel.Dimension = (int) myDimension.Value;
    }

    private void Synch()
    {
      mySpaceInformationPanel.Controls.Clear();
      foreach (var space in myModel.Spaces)
      {
        mySpaceInformationPanel.Controls.Add(
          new SpaceParametersRow(space)
            {
              Dock = DockStyle.Top
            });
      }
    }
  }
}