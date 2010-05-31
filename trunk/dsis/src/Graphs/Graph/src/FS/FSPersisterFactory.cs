using System;
using System.Collections.Generic;

namespace DSIS.Graph.FS
{
  public class FSPersisterFactory
  {
    private readonly Dictionary<Type, object> myPersistors = new Dictionary<Type, object>();

    public FSPersisterFactory()
    {
      myPersistors[typeof (uint)] = new FSUIntPersister();
      myPersistors[typeof (long)] = new FSLongPersister();
    }

    public IFSObjectPersister<T> CreatePersister<T>()
    {
      object p;
      if (myPersistors.TryGetValue(typeof (T), out p))
        return (IFSObjectPersister<T>) p;

      throw new Exception("Failed to find persister for type: " + typeof (T));
    }
  }
}