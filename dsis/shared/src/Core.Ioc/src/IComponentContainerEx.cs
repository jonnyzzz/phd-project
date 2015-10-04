using System;
using EugenePetrenko.Shared.Core.Ioc.Api;

namespace EugenePetrenko.Shared.Core.Ioc
{
  public interface IComponentContainer : IDisposable, ISubContainerFactory, IComponentService, IComponentContainerBuilder
  {
    ITypesFilter Filter { get; }
  }
}