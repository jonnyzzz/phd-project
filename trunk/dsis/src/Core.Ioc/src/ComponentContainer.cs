using System;
using System.Collections.Generic;
using System.Reflection;
using Castle.MicroKernel;
using DSIS.Utils;

namespace DSIS.Core.Ioc
{
  public interface IAssemblyScaner
  {
    IEnumerable<Type> LoadTypes(Assembly a, Type attribuType);
  }

  public class AssemblyScanerImpl : IAssemblyScaner
  {
    public IEnumerable<Type> LoadTypes(Assembly a, Type attribuType)
    {
      return new List<Type>(a.GetTypes().Filter(x => x.IsDefined(attribuType, true)));
    }
  }

  public interface IComponentContainer
  {
    
  }

  public class ComponentContainerInterfaceAttribute : Attribute {}
  public class ComponentContainerImplemetationAttribute : Attribute {}

  public class ComponentContainer : IDisposable
  {
    private readonly IKernel myKernel;

    public ComponentContainer()
    {
      myKernel = new DefaultKernel();
      myKernel.AddComponentInstance<IComponentContainer>(this);
    }

    public void Dispose()
    {
      myKernel.Dispose();
    }
  }
}