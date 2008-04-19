using System;

namespace DSIS.Spring
{
  [AttributeUsage(AttributeTargets.Assembly, AllowMultiple = true)]
  public class SpringIncludeAssembly : Attribute
  {
    private readonly string myAssembly;


    public SpringIncludeAssembly(string assembly)
    {
      myAssembly = assembly;
    }

    public string Assembly
    {
      get { return myAssembly; }
    }
  }
}