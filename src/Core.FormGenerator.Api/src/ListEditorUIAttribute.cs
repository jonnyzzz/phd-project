using System;

namespace EugenePetrenko.Core.FormGenerator.Api
{
  public class ListEditorUIAttribute : IncludeGenerateAttribute
  {
    private readonly Type myModel;

    public ListEditorUIAttribute(Type model)
    {
      myModel = model;
    }

    public Type Model
    {
      get { return myModel; }
    }
  }
}