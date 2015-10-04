using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using EugenePetrenko.Shared.Core.Ioc.Api;
using EugenePetrenko.Shared.Utils;

namespace EugenePetrenko.Shared.Core.Ioc.JC
{
  public class JContainer : IJContainer
  {
    private readonly ITypesFilter myFilter;
    private readonly IBaseTypesLookup myBasesLookup;
    private readonly IImplLoopup myImplLoopup;
    private readonly IImplementationsHolder myHolder;
    private readonly RecursionBlocker<Type> myCreateInstance = new RecursionBlocker<Type>();
    private readonly List<JContainer> myParents = new List<JContainer>();
    private readonly IAutowireLookupImpl myAutowires;

    public JContainer(ITypesFilter filter)
    {
      myFilter = filter;
      myBasesLookup = new BaseTypeLookupImpl(myFilter);
      myImplLoopup = new ImplLookupImpl(myBasesLookup);
      myHolder = new ImplementationHolderImpl(CreateInstance, myImplLoopup);
      myAutowires = new AutowireLookupImpl(myBasesLookup);
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
      return GetComponents(typeof (T)).Cast<T>();
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
          components.AddRange(parent.GetComponents(y).Where(x => check(x.GetType())));
        }
      }
      components.AddRange(myHolder.GetInstancesFor(y));

      return components;
    }

    public IEnumerable<T> GetCreatedComponentFromThatContainer<T>()
    {
      return myHolder.GetCreatedInstancesFor(typeof (T)).Cast<T>();
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
            argz.Add(FindAutowiringInstance(info.ParameterType));
          }

          object obj = Activator.CreateInstance(t, argz.ToArray());

          var autowings = myAutowires.GetAutowings(obj);
          foreach (var auto in autowings)
          {
            var value = FindAutowiringInstance(auto.Type);
            try
            {
              auto.SetValue(value);
            }
            catch (Exception e)
            {
              throw new ComponentContainerException(
                string.Format("Failed to autowire setter of type {0}.{1}. {2}", t, auto.Name, e.Message), e);
            }
          }

          return obj;
        }
      }
      catch (ComponentContainerException e)
      {
        throw new ComponentContainerException(e.Message + "\r\nCreation of " + t, e);
      }
      catch (Exception e)
      {
        throw new ComponentContainerException(e.Message + "\r\nCreation of " + t, e);
      }
    }

    private object FindAutowiringInstance(Type type)
    {
      if (type.IsArray)
        return FillCollectionOf(type.GetElementType());

      if (type.IsGenericType && type.GetGenericTypeDefinition() == typeof (IEnumerable<>))
        return FillCollectionOf(type.GetGenericArguments()[0]);

      if (type.IsGenericType && type.GetGenericTypeDefinition() == typeof (ICollection<>))
        return FillCollectionOf(type.GetGenericArguments()[0]);

      if (type.IsGenericType && type.GetGenericTypeDefinition() == typeof(Func<>))
      {
        var genericArgument = type.GetGenericArguments()[0];
        return CreateFuncOf(genericArgument);
      }

      return GetComponent(type);
    }

    private object CreateFuncOf(Type t)
    {
      var c = new FuncOfFactory(this);
      TypeGenerifier.CallbackType(t, c);
      return c.Func;
    }

    private class FuncOfFactory : TypeGenerifier.Callback
    {
      private readonly JContainer myContainer;

      public FuncOfFactory(JContainer container)
      {
        myContainer = container;
      }

      public object Func { get; private set; }
      public void Callback<T>()
      {
        Func = (Func<T>)( () => myContainer.GetComponent<T>());
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