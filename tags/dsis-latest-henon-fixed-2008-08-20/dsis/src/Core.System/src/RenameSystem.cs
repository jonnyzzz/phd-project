using System;

namespace DSIS.Core.System
{
  public class RenameSystem : ISystemInfo
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
      return mySystemInfo.GetFunction<T>(precision);
    }

    public IFunction<T> GetFunction<T>(T precision)
    {
      return mySystemInfo.GetFunction(precision);
    }

    public IFunction<T> GetDerivateFunction<T>(T[] precision, int derivatePower)
    {
      return mySystemInfo.GetDerivateFunction(precision, derivatePower);
    }

    public IFunction<T> GetDerivateFunction<T>(T[] precision, int[] unsimmetricDerivate)
    {
      return mySystemInfo.GetDerivateFunction(precision, unsimmetricDerivate);
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
  }
}