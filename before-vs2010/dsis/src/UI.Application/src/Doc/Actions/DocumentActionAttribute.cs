using System;
using DSIS.Core.Ioc;

namespace DSIS.UI.Application.Doc.Actions
{
  [AttributeUsage(AttributeTargets.Class)]
  public class DocumentActionAttribute : ComponentImplementationAttributeBase
  {
    public string Caption { get; set; }
    public string Description { get; set; }
  }
}