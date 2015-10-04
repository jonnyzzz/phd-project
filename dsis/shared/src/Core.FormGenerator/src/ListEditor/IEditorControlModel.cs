using System;
using System.Windows.Forms;

namespace EugenePetrenko.Core.FormGenerator.ListEditor
{
  public interface IEditorControlModel
  {
    Control CreateControl();

    event EventHandler<EventArgs> RefereshRequired;

    bool AddEnabled { get; }
    bool EditEnabled { get; }
    bool DeleteEnabled { get; }

    void AddAction();
    void EditAction();
    void DeleteAction();    
  }
}