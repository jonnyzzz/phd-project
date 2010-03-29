using System;
using System.Collections.Generic;
using System.Linq;
using DSIS.Utils;

namespace DSIS.Core.Ioc.JC
{
  public class ImplementationHolderImpl : IImplementationsHolder
  {
    private readonly Func<Type, object> myCreateInstance;
    private readonly IImplLoopup myLookup;
    private readonly Dictionary<Type, object> myImplementations = new Dictionary<Type, object>();

    public ImplementationHolderImpl(Func<Type, object> createInstance, IImplLoopup lookup)
    {
      myCreateInstance = createInstance;
      myLookup = lookup;
    }

    public void AddInstance(object o)
    {
      myLookup.RegisterImplementation(o.GetType());
      if (myImplementations.ContainsKey(o.GetType()))
        throw new Exception("Object with type " + o.GetType() + " has allready been registered");
      myImplementations.Add(o.GetType(), o);
    }

    public IList<object> GetInstancesFor(Type y)
    {
      return myLookup.GetImplementations(y).Map(x=>CreateComponentImplementation(x)).ToList();
    }

    public IList<object> GetCreatedInstancesFor(Type y)
    {
      var result = new List<object>();
      foreach (var type in myLookup.GetImplementations(y))
      {
        object o;
        if (myImplementations.TryGetValue(type, out o))
        {
          result.Add(o);
        }
      }
      return result;
    }

    private object CreateComponentImplementation(Type impl)
    {
      object oImpl;
      if (myImplementations.TryGetValue(impl, out oImpl))
        return oImpl;

      var o = myCreateInstance(impl);
      if (o == null)
        throw new JContainerException("Failed to create implementation for " + impl + " null returned");
      
      if (o.GetType() != impl)
        throw new JContainerException("Created object should have exact type " + impl + " but was " + o.GetType());
      
      myImplementations.Add(impl, o);

      return o;
    }
  }
}