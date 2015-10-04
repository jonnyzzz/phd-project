using System;
using System.Collections.Generic;

namespace EugenePetrenko.Shared.Core.Ioc.Api
{
  [NoInheritContainer]
  public interface IComponentService : IDisposable
  {
    T GetComponent<T>();

    IEnumerable<T> GetComponents<T>();
  }
}