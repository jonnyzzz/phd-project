using System.Drawing;
using System.Reflection;
using System.Windows.Forms;

namespace EugenePetrenko.Core.FormGenerator.FieldInfos
{
  public class TextAreaFieldInfo : TextFieldInfo
  {
    private readonly TextAreaEditorPreference myPref;

    public TextAreaFieldInfo(TextAreaEditorPreference pref, PropertyInfo property, object instance) : base(property, instance)
    {
      myPref = pref;
    }

    protected override Control UpdateTextBox(TextBox box)
    {
      box.Multiline = true;
      box.AcceptsReturn = true;
      box.AcceptsTab = true;
      box.ScrollBars = ScrollBars.Both;
      if (myPref.Font != null)
        box.Font = (Font) myPref.Font.Clone();
      box.Height = (int)(box.Font.GetHeight() * myPref.EnsureLines) + 15;
      box.WordWrap = false;

      return base.UpdateTextBox(box);
    }
  }
}