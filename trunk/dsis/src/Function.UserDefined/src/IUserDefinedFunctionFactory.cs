using System.Collections.Generic;
using DSIS.Core.System;
using DSIS.Scheme.Objects.Systemx;

namespace DSIS.Function.UserDefined
{
  public interface IUserDefinedFunctionFactory : IOptionsBasedFactory<UserFunctionParameters, ISystemInfo>
  {
    ICollection<CodeError> CheckCode(UserFunctionParameters ps);
  }
}