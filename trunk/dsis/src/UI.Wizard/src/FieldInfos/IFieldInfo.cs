using System.Windows.Forms;

namespace DSIS.UI.Wizard.FieldInfos
{
  public delegate void FieldValueChanged(IFieldInfo info, Control control, string message);

  public interface IFieldInfo
  {
    event FieldValueChanged ValueChanged;
    Control EditorControl();
  }
}