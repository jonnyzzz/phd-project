using System;
using System.Collections.Generic;
using System.Reflection;
using Castle.Core;
using Castle.MicroKernel;
using DSIS.Utils;

namespace DSIS.Core.Ioc
{
  public class ComponentContainer : IDisposable, IComponentContainer
  {
    private readonly IKernel myKernel;
    private readonly IAssemblyScaner myScanner;

    public ComponentContainer()
    {
      myKernel = new DefaultKernel();
      myKernel.AddComponentInstance<IComponentContainer>(this);

      myScanner = new AssemblyScanerImpl();

      AppDomain.CurrentDomain.AssemblyLoad += (x, e) => ScanAssemblies(e.LoadedAssembly.En());
      ScanAssemblies(AppDomain.CurrentDomain.GetAssemblies());
    }

    public void Dispose()
    {
      myKernel.Dispose();
    }

    public void ScanAssemblies(IEnumerable<Assembly> assemblies)
    {
      foreach (var assembly in assemblies)
      {
        foreach (var p in myScanner.LoadTypes<ComponentContainerImplemetationAttribute>(assembly)  )
        {
          if (myKernel.HasComponent(p.Second.InterfaceType))
            throw new ComponentContainerException(string.Format("Service with interface type {0} has allready been registered.", p.Second.InterfaceType.FullName));
         
          myKernel.AddComponent(p.First.AssemblyQualifiedName, p.Second.InterfaceType, p.First, LifestyleType.Singleton);
        }
      }
    }
  }
}