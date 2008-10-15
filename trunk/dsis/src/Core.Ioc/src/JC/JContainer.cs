using System;
using System.Collections.Generic;
using DSIS.Core.Ioc;
using DSIS.Core.Ioc.JC;
using DSIS.Utils;

public class JContainer
{
  private readonly ITypesFilter myFilter;
  private readonly IBaseTypesLookup myBasesLookup;
  private readonly IImplLoopup myImplLoopup;
  private readonly IImplementationsHolder myHolder;
  private readonly RecursionBlocker<Type> myCreateInstance = new RecursionBlocker<Type>();
  private readonly JContainer myParent;

  public JContainer(ITypesFilter filter) : this(filter, null)
  {
  }

  public JContainer(ITypesFilter filter, JContainer parent)
  {
    myParent = parent;
    myFilter = filter;
    myBasesLookup = new BaseTypeLookupImpl(myFilter);
    myImplLoopup = new ImplLookupImpl(myBasesLookup);
    myHolder = new ImplementationHolderImpl(CreateInstance, myImplLoopup);
  }

  public void RegisterInstance(object instance)
  {
    myHolder.AddInstance(instance);
  }

  public T GetComponent<T>()
  {
    return (T) GetComponent(typeof (T));
  }

  public IEnumerable<T> GetComponents<T>()
  {
    return GetComponents(typeof(T)).Cast<T>();
  }

  public void RegisterComponent(Type t)
  {
    myImplLoopup.RegisterImplementation(t);
  }

  private object GetComponent(Type y)
  {
    IList<object> impls = GetComponents(y);
    if (impls.Count == 0)
      throw new JContainerException("No component implementation for " + y);
    if (impls.Count > 1)
      throw new JContainerException("Too much component implementations for " + y);

    return impls[0];
  }

  private IList<object> GetComponents(Type y)
  {
    var components = new List<object>();
    if (myParent != null)
      components.AddRange(myParent.GetComponents(y));
    components.AddRange(myHolder.GetInstancesFor(y));

    return components;
  }

  private object CreateInstance(Type t)
  {
    using(myCreateInstance.Call(t))
    {
      if (!t.IsClass || t.IsAbstract)
        throw new JContainerException("Failed to create class " + t);

      var constructors = t.GetConstructors();
      if (constructors.Length != 1)
        throw new JContainerException("Failed to create class " + t + ". There are more than one public constructor");

      var constr = constructors[0];

      var argz = new List<object>();
      foreach (var info in constr.GetParameters())
      {
        var type = info.ParameterType;
        if (type.IsArray)
        {
          argz.Add(GetComponents(type.GetElementType()));
        } else
        {
          argz.Add(GetComponent(type));
        }
      }

      return Activator.CreateInstance(t, argz.ToArray());
    }
  }
}
