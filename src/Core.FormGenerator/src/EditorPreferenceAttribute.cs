using System;

namespace EugenePetrenko.Core.FormGenerator
{
  [AttributeUsage(AttributeTargets.Property, AllowMultiple = false)]
  public abstract class EditorPreferenceAttribute : Attribute
  {
  }
}