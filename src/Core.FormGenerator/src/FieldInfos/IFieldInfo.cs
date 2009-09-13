using System.Windows.Forms;

namespace EugenePetrenko.Core.FormGenerator.FieldInfos
{
  public delegate void FieldValueChanged(IFieldInfo info, Control control, string message);

  public interface IFieldInfo
  {
    event FieldValueChanged ValueChanged;
    Control EditorControl();
    void CheckFieldValue();
  }
}