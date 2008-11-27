using System;
using System.Reflection;

namespace DSIS.Spring.Assemblies
{
  public interface ITypeLoadListener
  {
    void TypeLoaded(Assembly assembly, Type[] loadedTypes);
  }
}