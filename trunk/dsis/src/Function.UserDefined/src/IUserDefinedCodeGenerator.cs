using System;

namespace DSIS.Function.UserDefined
{
  public interface IUserDefinedCodeGenerator
  {
    string GenerateCode(UserFunctionParameters paramz);

    Predicate<int> UserCodeRangeFilter(string code);
  }
}