using System;
using System.Collections.Generic;

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
      myImplementations.Add(o.GetType(), o);
    }

    public IList<object> GetInstancesFor(Type y)
    {
      var impls = new List<object>();
      foreach (var impl in myLookup.GetImplementations(y))
      {
        object oImpl;
        if (myImplementations.TryGetValue(impl, out oImpl))
        {
          impls.Add(myImplementations[impl]);
        }
        else
        {
          var o = myCreateInstance(impl);
          if (o == null)
            throw new JContainerException("Failed to create implementation for " + impl + " null returned");
          if (o.GetType() != impl)
            throw new JContainerException("Created object should have exact type " + impl + " but was " + o.GetType());
          AddInstance(o);
        }
      }
      return impls;
    }
  }
}