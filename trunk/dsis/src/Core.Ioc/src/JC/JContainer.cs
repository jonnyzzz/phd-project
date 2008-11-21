using System;
using System.Collections;
using System.Collections.Generic;
using DSIS.Utils;

namespace DSIS.Core.Ioc.JC
{
  public class JContainer : IJContainer
  {
    private readonly ITypesFilter myFilter;
    private readonly IBaseTypesLookup myBasesLookup;
    private readonly IImplLoopup myImplLoopup;
    private readonly IImplementationsHolder myHolder;
    private readonly RecursionBlocker<Type> myCreateInstance = new RecursionBlocker<Type>();
    private readonly List<JContainer> myParents = new List<JContainer>();

    public JContainer(ITypesFilter filter)
    {
      myFilter = filter;
      myBasesLookup = new BaseTypeLookupImpl(myFilter);
      myImplLoopup = new ImplLookupImpl(myBasesLookup);
      myHolder = new ImplementationHolderImpl(CreateInstance, myImplLoopup);
    }

    public JContainer(ITypesFilter filter, JContainer parent) : this(filter)
    {
      myParents.Add(parent);
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

    public object GetComponent(Type y)
    {
      IList<object> impls = GetComponents(y);
      if (impls.Count == 0)
        throw new JContainerException("No component implementation for " + y);
      if (impls.Count > 1)
        throw new JContainerException("Too much component implementations for " + y);

      return impls[0];
    }

    public IList<object> GetComponents(Type y)
    {
      var components = new List<object>();
      Predicate<Type> check = x => !x.IsDefined(typeof (NoInheritContainerAttribute), true);

      if (check(y))
      {
        foreach (var parent in myParents)
        {
          components.AddRange(parent.GetComponents(y).Filter(x=>check(x.GetType())));
        }
      }
      components.AddRange(myHolder.GetInstancesFor(y));

      return components;
    }

    public IList<JContainer> Parents
    {
      get { return myParents; }
    }

    public IEnumerable<T> GetCreatedComponentFromThatContainer<T>()
    {
      return myHolder.GetCreatedInstancesFor(typeof(T)).Cast<T>();
    }

    private object CreateInstance(Type t)
    {
      try
      {
        using (myCreateInstance.Call(t))
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
              argz.Add(FillCollectionOf(type.GetElementType()));
            }
            else if (type.IsGenericType && type.GetGenericTypeDefinition() == typeof(IEnumerable<>))
            {
              argz.Add(FillCollectionOf(type.GetGenericArguments()[0]));              
            }
            else if (type.IsGenericType && type.GetGenericTypeDefinition() == typeof(ICollection<>))
            {
              argz.Add(FillCollectionOf(type.GetGenericArguments()[0]));              
            }
            else
            {
              argz.Add(GetComponent(type));
            }
          }

          return Activator.CreateInstance(t, argz.ToArray());
        }
      } catch (ComponentContainerException e)
      {
        throw new ComponentContainerException(e.Message + "\r\n" + "Creation of " + t, e);
      } catch (Exception e)
      {
        throw new ComponentContainerException(e.Message + "\r\nCreation of " + t, e);
      }
    }

    private Array FillCollectionOf(Type type)
    {
      var arg = new ArrayList();  
      foreach (var o in GetComponents(type))
      {
        arg.Add(o);
      }
      return arg.ToArray(type);
    }
  }
}