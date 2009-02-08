namespace DSIS.Function.UserDefined
{
  public interface IUserDefinedCodeGenerator
  {
    string GenerateCode(UserFunctionParameters paramz);
  }
}