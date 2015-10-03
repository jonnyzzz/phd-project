using System;

namespace DSIS.UI.UI
{
  public interface IErrorProvider<T>
  {
    T Validate();
  }

  [AttributeUsage(AttributeTargets.Class, AllowMultiple = true)]
  public class ErrorProviderAttribute : Attribute
  {
    public readonly Type Type;

    public ErrorProviderAttribute(Type type)
    {
      Type = type;
    }

    public static bool HasAttribute(object obj, Type argumentType)
    {
      var type = obj.GetType();
      var attrs = type.GetCustomAttributes(typeof (ErrorProviderAttribute), true);
      foreach (ErrorProviderAttribute attr in attrs)
      {
        if (attr.Type == argumentType)
          return true;        
      }
      return false;      
    }
  }

}