using System.Windows.Forms;

namespace DSIS.UI.Wizard.FormsGenerator
{
  public delegate void FieldValueChanged(IFieldInfo info, Control control, string message);

  public interface IFieldInfo
  {
    event FieldValueChanged ValueChanged;
    Control EditorControl();
  }
}