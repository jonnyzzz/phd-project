using System;

namespace DSIS.Scheme.Objects.Systemx
{
  public interface IOptionsValueChecker
  {
    void HasErrors(string fieldName, Action<string> setError);
  }
}