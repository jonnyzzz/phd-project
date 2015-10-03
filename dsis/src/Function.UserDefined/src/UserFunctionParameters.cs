using System;
using System.Drawing;
using DSIS.Core.System;
using DSIS.Utils.Bean;
using DSIS.Utils;

namespace DSIS.Function.UserDefined
{
  [Serializable]
  public class UserFunctionParameters 
  {
    [IncludeGenerate(Title="Name")]
    public string FunctionName { get; set; }

    [IncludeGenerate(Title="Dimension", Description = "Enter system function dimension")]
    public int Dimension { get; set; }

    [IncludeGenerate(Title = "System type")]
    public SystemType SystemType { get; set; }

    [IncludeGenerate(Title = "Enter function code")]
    [TextAreaPreferenceEx]
    public string Code { get; set; }

    public UserFunctionParameters()
    {
      Func<string, string> en = x => Dimension.Each().JoinString(i => x + (i + 1), ", ");
      Dimension = 2;
      SystemType = SystemType.Discrete;
      Code =
        @"//Use " + en("x") + " as coordinate values." + Environment.NewLine +
        @"//Use " + en("f") + " as results. " + Environment.NewLine +
        @"//You may use 'var' to define new variable." + Environment.NewLine +
        @"//This is C# 3.0 used in background inside a method code." + Environment.NewLine +
        @"" + Environment.NewLine +
        Dimension.Each().JoinString(i => "f" + (i + 1 + " = ...;"), Environment.NewLine + Environment.NewLine);
    }

    private class TextAreaPreferenceEx : TextAreaEditorPreference
    {
      public TextAreaPreferenceEx()
      {
        Font = new Font(FontFamily.GenericMonospace, 9.75f);
      }
    }
  }
}