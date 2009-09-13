using System;

namespace EugenePetrenko.Core.FormGenerator.Api
{
  [AttributeUsage(AttributeTargets.Property, AllowMultiple = false)]
  public abstract class EditorPreferenceAttribute : Attribute
  {
  }
}