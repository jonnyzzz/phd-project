using System;
using System.Collections.Generic;
using System.Reflection;

namespace DSIS.Core.Ioc
{
  [ComponentInterface]
  public interface IComponentContainer : IDisposable, ISubContainerFactory
  {
    T GetComponent<T>();

    void Start();

    IEnumerable<T> GetComponents<T>();

    void ScanAssemblies(IEnumerable<Assembly> assemblies);

    ITypesFilter Filter { get; }

    void RegisterComponent(object instance);

    void RegisterComponentType(Type t);
  }

  public interface ISubContainerFactory
  {
    IComponentContainer SubContainer<TImplementation>()
      where TImplementation : ComponentImplementationAttributeBase;
  }

  /// <summary>
  /// Marker attribute for types that can be instanciated using
  /// <see cref="ITypeInstantiator"/> intefrace
  /// </summary>
  [AttributeUsage(AttributeTargets.Class)]
  public class TypeInstanciableAttribute : Attribute
  {
  }

  [NoInheritContainer]
  public interface ITypeInstantiator
  {
    /// <summary>
    /// Create instance of type T using specified parameters and 
    /// current component container. 
    /// All autowirings are done.
    /// 
    /// Type T must be marked with <see cref="TypeInstanciableAttribute"/>
    /// </summary>
    /// <typeparam name="T">instance to create</typeparam>
    /// <param name="instances">additional components</param>
    /// <returns>create instace</returns>
    T Instanciate<T>(params object[] instances);
  }
}