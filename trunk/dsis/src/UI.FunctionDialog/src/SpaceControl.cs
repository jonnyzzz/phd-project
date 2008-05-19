using System;
using System.Collections.Generic;
using System.Windows.Forms;
using DSIS.UI.UI;
using DSIS.Utils;

namespace DSIS.UI.FunctionDialog
{
  public partial class SpaceControl : UserControl
  {
    private readonly SpaceModel myModel;
    private readonly List<SpaceParametersRow> myRows = new List<SpaceParametersRow>();

    public SpaceControl() : this(new SpaceModel())
    {
    }

    public SpaceControl(SpaceModel model)
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
      using (this.UpdateCookie())
      {
        while (myRows.Count != myModel.Spaces.Count)
        {
          if (myRows.Count < myModel.Spaces.Count)
          {
            var row = new SpaceParametersRow(new SpaceParametersRowModel()) {Dock = DockStyle.Top};
            myRows.Add(row);
            mySpaceInformationPanel.Controls.Add(row);
          }
          else if (myRows.Count > myModel.Spaces.Count && myRows.Count > 0)
          {
            var row = myRows[myRows.Count - 1];
            mySpaceInformationPanel.Controls.Remove(row);
            myRows.RemoveAt(myRows.Count - 1);
            row.Dispose();
          }
        }

        CollectionUtil.Zip(myRows, myModel.Spaces, (x, y) => { x.Model = y; });
      }
    }
  }
}