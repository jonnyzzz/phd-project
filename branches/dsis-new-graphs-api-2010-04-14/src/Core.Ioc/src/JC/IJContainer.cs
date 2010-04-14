using System;
using System.Collections.Generic;

namespace DSIS.Core.Ioc.JC {
  public interface IJContainer
  {
    void RegisterInstance(object instance);
    T GetComponent<T>();
    IEnumerable<T> GetComponents<T>();
    void RegisterComponent(Type t);
  }
}