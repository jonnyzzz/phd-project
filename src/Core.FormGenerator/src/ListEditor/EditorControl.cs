using System;
using System.Windows.Forms;

namespace EugenePetrenko.Core.FormGenerator.ListEditor
{
  public partial class EditorControl : UserControl
  {
    private readonly IEditorControlModel myController;

    public EditorControl()
    {
      InitializeComponent();
    }

    public EditorControl(IEditorControlModel controller) : this()
    {
      myController = controller;
      myAdd.Click += delegate { myController.AddAction(); };
      myEdit.Click += delegate { myController.EditAction(); };
      myRemove.Click += delegate { myController.DeleteAction(); };

      var statusUpdate = (Action)delegate
                           {
                             myAdd.Enabled = myController.AddEnabled;
                             myEdit.Enabled = myController.EditEnabled;
                             myRemove.Enabled = myController.DeleteEnabled;
                           };

      controller.RefereshRequired += delegate
                                       {
                                         statusUpdate();
                                       };
      statusUpdate();

      var control = controller.CreateControl();
      control.Dock = DockStyle.Fill;
      myContent.Controls.Add(control);
    }    
  }
}