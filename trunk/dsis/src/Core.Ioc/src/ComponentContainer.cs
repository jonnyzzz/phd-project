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

    public ComponentContainer()
    {
      myKernel = new DefaultKernel();
      myKernel.AddComponentInstance<IComponentContainer>(this);

      myScanner = new AssemblyScanerImpl();
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

    public void Subscribe()
    {
      AppDomain.CurrentDomain.AssemblyLoad += OnAssemblyLoadEvent;
      ScanAssemblies(AppDomain.CurrentDomain.GetAssemblies());
    }

    private void OnAssemblyLoadEvent(object x, AssemblyLoadEventArgs e)
    {
      ScanAssemblies(e.LoadedAssembly.En());
    }

    public void Dispose()
    {
      AppDomain.CurrentDomain.AssemblyLoad -= OnAssemblyLoadEvent;
      if (myKernel.Parent != null)
        myKernel.Parent.RemoveChildKernel(myKernel);

      myKernel.Dispose();
    }

    public IComponentContainer SubContainer<TInterface1, TImplementation1>()
      where TInterface1 : ComponentInterfaceAttributeBase where TImplementation1 : ComponentImplemetationAttributeBase
    {
      var container = new ComponentContainer<TInterface1, TImplementation1>();
      myKernel.AddChildKernel(container.myKernel);
      container.Subscribe();
      return container;
    }

    public T GetComponent<T>()
    {
      return myKernel.GetService<T>();
    }

    public void ScanAssemblies(IEnumerable<Assembly> assemblies)
    {
      foreach (var assembly in assemblies)
      {
        foreach (var p in myScanner.LoadTypes<TImplementation>(assembly))
        {
          var interfaceType = p.Second.InterfaceType;
          var implementationType = p.First;

          CheckValidComponent(interfaceType, implementationType);

          myKernel.AddComponent(implementationType.AssemblyQualifiedName, interfaceType, implementationType, LifestyleType.Singleton);
        }
      }
    }

    private static void CheckInterfaceMarked(Type interfaceType)
    {
      if (!interfaceType.IsDefined(interfaceType, true))
        throw new ComponentContainerException(string.Format("Interface {0} shold be marked with {1} attribute", typeof (TInterface), typeof (TInterface)));
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