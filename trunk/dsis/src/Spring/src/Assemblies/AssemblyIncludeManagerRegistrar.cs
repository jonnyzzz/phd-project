using System.Reflection;
using DSIS.Spring.Attributes;
using DSIS.Spring.Util;

namespace DSIS.Spring.Assemblies
{
  [SpringBean]
  public class AssemblyIncludeManagerRegistrar
  {
    public AssemblyIncludeManagerRegistrar(IAssemblyIncludeManager myManager, IBeanManager beans)
    {
      beans.RegisterBeanProcessor<IAssemblyLoadListener>(q => myManager.RegisterAssemblyLoaded(q));
      beans.RegisterBeanProcessor<ITypeLoadListener>(q => myManager.RegisterAssemblyLoaded(new TypeLoadListenerProxy(q)));
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