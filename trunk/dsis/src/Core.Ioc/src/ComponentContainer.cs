using System;
using System.Collections.Generic;
using System.Reflection;
using Castle.Core;
using Castle.MicroKernel;
using DSIS.Utils;

namespace DSIS.Core.Ioc
{
  public class ComponentContainer<TInterface, TImplementation> : IComponentContainer
    where TImplementation : ComponentImplemetationAttributeBase
    where TInterface : ComponentInterfaceAttributeBase
  {
    private readonly IKernel myKernel;
    private readonly IAssemblyScaner myScanner;
    private readonly IComponentInterfaceLookup myLookup;
    private readonly Hashset<Assembly> mySubscription = new Hashset<Assembly>();

    public ComponentContainer(IAssemblyScaner scanner, IComponentInterfaceLookup lookup)
    {
      myKernel = new DefaultKernel();

      myScanner = scanner;
      myLookup = lookup;

      myKernel.AddComponentInstance<IComponentContainer>(this);
    }

    private ComponentContainer(ITypesFilter filer) : this(new AssemblyScanerImpl(filer), new ComponentInterfaceLookupImpl(filer))
    {
    }

    public ComponentContainer() : this(new TypesFilerImpl())
    {
    }

    public void RegisterComponentInstance<TI>(object component)
    {
      var implementationType = component.GetType();
      var interfaceType = typeof(TI);
      CheckValidComponent(interfaceType, implementationType);
      myKernel.AddComponentInstance<TI>(component);
    }

    private void CheckValidComponent(Type interfaceType, Type implementationType)
    {
      CheckInterfaceMarked(interfaceType);
      CheckImplemetsService(interfaceType, implementationType);
      CheckServiceNotAdded(interfaceType);
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

    public IComponentContainer SubContainer<TInterface1, TImplementation1>()
      where TInterface1 : ComponentInterfaceAttributeBase 
      where TImplementation1 : ComponentImplemetationAttributeBase
    {
      var container = new ComponentContainer<TInterface1, TImplementation1>(myScanner, myLookup);
      myKernel.AddChildKernel(container.myKernel);
      container.ScanAssemblies(mySubscription);
      return container;
    }

    public T GetComponent<T>()
    {
      return myKernel.GetService<T>();
    }

    public void ScanAssemblies(IEnumerable<Assembly> assemblies)
    {
      var toScan = assemblies.Filter(x=>!mySubscription.Contains(x)).ToArray();
      mySubscription.AddRange(toScan);

      foreach (var assembly in toScan)
      {
        foreach (var p in myScanner.LoadTypes<TImplementation>(assembly))
        {
          var implementationType = p.First;
          foreach (var foundInterface in myLookup.FindInterfaces<TInterface>(p.First))
          {
            CheckValidComponent(foundInterface, implementationType);

            myKernel.AddComponent(implementationType.AssemblyQualifiedName, foundInterface, implementationType, LifestyleType.Singleton);            
          }
        }
      }
    }

    private static void CheckInterfaceMarked(Type interfaceType)
    {
      if (!interfaceType.IsDefined(typeof(TInterface), true))
        throw new ComponentContainerException(string.Format("Interface {0} shold be marked with {1} attribute", interfaceType, typeof (TInterface)));
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