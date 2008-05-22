using System.Reflection;
using DSIS.Spring.Attributes;
using Spring.Objects.Factory.Config;

namespace DSIS.Spring.Assemblies
{
  [SpringBean]
  public class AssemblyIncludeManagerRegistrar : IObjectPostProcessor
  {
    private readonly AssemblyIncludeManager myManager;

    public AssemblyIncludeManagerRegistrar(AssemblyIncludeManager myManager)
    {
      this.myManager = myManager;
    }

    public object PostProcessBeforeInitialization(object instance, string name)
    {
      return instance;
    }

    public object PostProcessAfterInitialization(object instance, string objectName)
    {
      var man = instance as IAssemblyLoadListener;
      if (man != null)
      {
        myManager.RegisterAssemblyLoaded(man);
      }

      var proxy = instance as ITypeLoadListener;
      if (proxy != null)
      {
        myManager.RegisterAssemblyLoaded(new TypeLoadListenerProxy(proxy));
      }
      return instance;
    }

    private class TypeLoadListenerProxy : IAssemblyLoadListener
    {
      private readonly ITypeLoadListener myListener;

      public TypeLoadListenerProxy(ITypeLoadListener myListener)
      {
        this.myListener = myListener;
      }

      public void AssemblyLoaded(Assembly assembly)
      {
        myListener.TypeLoaded(assembly, assembly.GetTypes());
      }
    }
  }
}