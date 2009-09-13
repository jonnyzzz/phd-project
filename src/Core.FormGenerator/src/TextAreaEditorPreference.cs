using System.Drawing;

namespace EugenePetrenko.Core.FormGenerator
{
  public class TextAreaEditorPreference : EditorPreferenceAttribute
  {
    public int EnsureLines { get; set; }

    public Font Font { get; set; }

    public TextAreaEditorPreference()
    {
      EnsureLines = 20;
    }
  }
}