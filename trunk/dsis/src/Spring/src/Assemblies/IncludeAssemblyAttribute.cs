using System;

namespace DSIS.Spring.Assemblies
{
  [AttributeUsage(AttributeTargets.Assembly, AllowMultiple = true)]
  public class IncludeAssemblyAttribute : Attribute
  {
    private readonly string myAssembly;


    public IncludeAssemblyAttribute(string assembly)
    {
      myAssembly = assembly;
    }

    public string Assembly
    {
      get { return myAssembly; }
    }
  }
}