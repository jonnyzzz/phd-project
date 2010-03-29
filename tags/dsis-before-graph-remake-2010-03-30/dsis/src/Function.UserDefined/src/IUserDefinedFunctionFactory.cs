using System.Collections.Generic;
using DSIS.Core.System;
using DSIS.Scheme.Objects.Systemx;
using DSIS.Utils;

namespace DSIS.Function.UserDefined
{
  public interface IUserDefinedFunctionFactory : IOptionsBasedFactory<UserFunctionParameters, ISystemInfo>
  {
    Pair<string, ICollection<CodeError>> CheckCode(UserFunctionParameters ps);
  }
}