using System.Windows.Forms;

namespace EugenePetrenko.Core.FormGenerator.FieldInfos
{
  public delegate void FieldValueChanged(IFieldInfo info, Control control, string message);

  public interface IFieldInfo
  {
    /// <summary>
    /// Fires this event on internal value change
    /// </summary>
    event FieldValueChanged ValueChanged;

    /// <summary>
    /// Editor control to be used for UI
    /// </summary>
    /// <returns>Editor control</returns>
    Control EditorControl();
  }
}