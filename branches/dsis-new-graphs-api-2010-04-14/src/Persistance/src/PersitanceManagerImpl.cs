using System;
using System.Collections.Generic;
using DSIS.Core.Ioc;

namespace DSIS.Persistance
{
  [SpringBean]
  public class PersitanceManagerImpl : IPersistanceManager
  {
    private readonly Dictionary<Type, object> myPersistances = new Dictionary<Type, object>();

    public IPersistance<Q> Persistance<Q>()
    {
      return (IPersistance<Q>) myPersistances[typeof (Q)];
    }

    public void RegisterPersistance<Q>(IPersistance<Q> manager)
    {
      myPersistances[typeof (Q)] = manager;
    }
  }
}