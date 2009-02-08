using System.Collections.Generic;
using DSIS.Core.Ioc;
using DSIS.Core.System;

namespace DSIS.Function.UserDefined
{
  [ComponentImplementation]
  public class UserDefinedFunctionFactoryImpl : IUserDefinedFunctionFactory
  {
    public string FactoryName
    {
      get { return "User-defined system functions"; }
    }

    public UserFunctionParameters CreateOptions()
    {
      return new UserFunctionParameters();
    }

    public ISystemInfo Create(UserFunctionParameters options)
    {
      throw new System.NotImplementedException();
    }

    public ICollection<CodeError> CheckCode(UserFunctionParameters ps)
    {
      throw new System.NotImplementedException();
    }
  }
}