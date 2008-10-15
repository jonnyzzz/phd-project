using System;
using System.Collections.Generic;
using System.Reflection;
using Castle.Core;
using Castle.MicroKernel;
using DSIS.Utils;

namespace DSIS.Core.Ioc
{
  public class ComponentContainer<TInterface, TCollectionInterface, TImplementation> : IComponentContainer
    where TImplementation : ComponentImplemetationAttributeBase
    where TCollectionInterface : ComponentCollectionAttributeBase
    where TInterface : ComponentInterfaceAttributeBase
  {
    private readonly IKernel myKernel;
    private readonly IAssemblyScaner myScanner;
    private readonly IComponentInterfaceLookup myLookup;
    private readonly HashSet<Assembly> mySubscription = new HashSet<Assembly>();
    private readonly ITypesFilter myFilter;

    public ComponentContainer(ITypesFilter filter, IAssemblyScaner scanner, IComponentInterfaceLookup lookup)
    {
      myKernel = new DefaultKernel();
      myFilter = filter;

      myScanner = scanner;
      myLookup = lookup;
//      myKernel.AddFacility("Startable", new StartableFacility<TImplementation>());

      //This component does not depends on attributes!
      myKernel.AddComponentInstance("##container", typeof(IComponentContainer), this);
      myKernel.AddComponentInstance("##containerServices", typeof(IComponentContainerServices), new ComponentContainerServices<TCollectionInterface>(myKernel, myLookup));

      ScanAssemblies(new[]{GetType().Assembly});
    }

    private ComponentContainer(ITypesFilter filter) : this(filter, new AssemblyScanerImpl(filter), new ComponentInterfaceLookupImpl(filter))
    {
    }

    public ComponentContainer() : this(new TypesFilerImpl())
    {
    }

    public void Start()
    {
      var init = GetComponent<IComponentContainerServices>().GetServices<IStartableComponent>();
      foreach (var cmp in init)
      {
        cmp.Start();
      }
    }

    private void CheckValidComponent(Type interfaceType, Type implementationType)
    {
      CheckInterfaceMarked(interfaceType);
      CheckImplemetsService(interfaceType, implementationType);
      CheckServiceNotAdded(interfaceType);
    }

    private void CheckValidServiceComponent(Type interfaceType, Type implementationType)
    {
      CheckServiceInterfaceMarked(interfaceType);
      CheckImplemetsService(interfaceType, implementationType);
      CheckServiceNotAdded(implementationType);
    }

    private static void CheckImplemetsService(Type interfaceType, Type implementationType)
    {
      if (!interfaceType.IsAssignableFrom(implementationType))
        throw new ComponentContainerException(string.Format("Component {0} should implement service {1}", implementationType, interfaceType));
    }

    public void Dispose()
    {
      if (myKernel.Parent != null)
        myKernel.Parent.RemoveChildKernel(myKernel);

      myKernel.Dispose();
    }

    public IComponentContainer SubContainer<TInterface1, TCollectionInterface1, TImplementation1>() where TInterface1 : ComponentInterfaceAttributeBase where TCollectionInterface1 : ComponentCollectionAttributeBase where TImplementation1 : ComponentImplemetationAttributeBase
    {
      var container = new ComponentContainer<TInterface1, TCollectionInterface1, TImplementation1>(myFilter, myScanner, myLookup);
      myKernel.AddChildKernel(container.myKernel);
      container.ScanAssemblies(mySubscription);
      return container;
    }

    public ITypesFilter Filter
    {
      get { return myFilter; }
    }

    public void RegisterComponent(object instance)
    {
      foreach (var type in myLookup.FindInterfaces<TInterface>(instance.GetType()))
      {
        myKernel.AddComponentInstance(Key(type, instance.GetType()), type, instance);
      }
    }

    public T GetComponent<T>()
    {
      return myKernel.GetService<T>();
    }

    public IEnumerable<T> GetComponents<T>()
    {
      return GetComponent<IComponentContainerServices>().GetServices<T>();
    }

    public void ScanAssemblies(IEnumerable<Assembly> assemblies)
    {
      var toScan = new HashSet<Assembly>(new HashSet<Assembly>(assemblies).Filter(x=>!mySubscription.Contains(x)).ToArray());
      mySubscription.UnionWith(toScan);

      foreach (var assembly in toScan)
      {
        foreach (var p in myScanner.LoadTypes<TImplementation>(assembly))
        {
          var implType = p.First;
          foreach (var t in myLookup.FindInterfaces<TInterface>(implType))
          {
            CheckValidComponent(t, implType);

            myKernel.AddComponent(Key(t, implType), t, implType, LifestyleType.Singleton);            
          }

          bool providesServiceComponents = false;
          foreach (var type in myLookup.FindInterfaces<TCollectionInterface>(implType))
          {
            providesServiceComponents = true;
            CheckValidServiceComponent(type, implType);
          }
          if (providesServiceComponents)
          {
            myKernel.AddComponent(Key(implType, implType), implType, LifestyleType.Singleton);            
          }
        }
      }
    }

    private static string Key(Type foundInterface, Type implementationType)
    {
      return implementationType.AssemblyQualifiedName + "@" + foundInterface.AssemblyQualifiedName;
    }

    private static void CheckInterfaceMarked(Type interfaceType)
    {
      if (!interfaceType.IsDefined(typeof(TInterface), true))
        throw new ComponentContainerException(string.Format("Interface {0} shold be marked with {1} attribute", interfaceType, typeof (TInterface)));
    }
 
    private static void CheckServiceInterfaceMarked(Type interfaceType)
    {
      if (!interfaceType.IsDefined(typeof(TCollectionInterface), true))
        throw new ComponentContainerException(string.Format("Interface {0}  shold be marked with {1} attribute", interfaceType, typeof (TInterface)));
    }

    private void CheckServiceNotAdded(Type interfaceType)
    {
      if (myKernel.HasComponent(interfaceType))
        throw new ComponentContainerException(
          string.Format("Service with interface type {0} has allready been registered.",
                        interfaceType.FullName));
    }
  }
}