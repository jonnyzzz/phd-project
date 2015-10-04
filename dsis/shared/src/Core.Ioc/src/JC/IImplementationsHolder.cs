using System;
using System.Collections.Generic;

namespace EugenePetrenko.Shared.Core.Ioc.JC
{
  public interface IImplementationsHolder
  {
    void AddInstance(object o);

    IList<object> GetInstancesFor(Type y);

    IList<object> GetCreatedInstancesFor(Type y);
  }
}