using System;

namespace DSIS.Persistance
{
  [AttributeUsage(AttributeTargets.Class, AllowMultiple = true)]
  public class FactoryMethod : Attribute
  {
    public readonly string MethodName;

    public FactoryMethod(string methodName)
    {
      MethodName = methodName;
    }
  }
}