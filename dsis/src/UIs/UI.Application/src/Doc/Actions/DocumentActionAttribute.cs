using System;
using EugenePetrenko.Shared.Core.Ioc.Api;
using JetBrains.Annotations;

namespace DSIS.UI.Application.Doc.Actions
{
  [AttributeUsage(AttributeTargets.Class)]
  [MeansImplicitUse]
  public class DocumentActionAttribute : ComponentImplementationAttributeBase
  {
    public string Caption { get; set; }
    public string Description { get; set; }
  }
}