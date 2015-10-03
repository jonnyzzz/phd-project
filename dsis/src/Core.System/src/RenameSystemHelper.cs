using System;

namespace DSIS.Core.System
{
  public static class RenameSystemHelper
  {
    public static ISystemInfo RenameSystemInfo(this ISystemInfo info, string newName)
    {
      return new RenameSystem(info, newName);
    }

    public static ISystemInfo RenameSystemInfoTemplate(this ISystemInfo info, string template)
    {
      return new RenameSystem(info, string.Format(template, info.PresentableName));
    }

    private class RenameSystem : ISystemInfo
    {
      private readonly ISystemInfo mySystemInfo;
      private readonly string myNewName;


      public RenameSystem(ISystemInfo systemInfo, string newName)
      {
        mySystemInfo = systemInfo;
        myNewName = newName;
      }


      public IFunction<T> GetFunction<T>(T[] precision)
      {
        return mySystemInfo.GetFunction(precision);
      }

      public SystemType Type
      {
        get { return mySystemInfo.Type; }
      }

      public Type[] SupportedFunctionTypes
      {
        get { return mySystemInfo.SupportedFunctionTypes; }
      }

      public string PresentableName
      {
        get { return myNewName; }
      }

      public int Dimension
      {
        get { return mySystemInfo.Dimension; }
      }

      public override string ToString()
      {
        return PresentableName;
      }
    }
  }
}