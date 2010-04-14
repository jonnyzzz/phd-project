using System.Collections.Generic;

namespace DSIS.Utils
{
  public class CaseInsensitiveEqualityComparer : IEqualityComparer<string>
  {
    public bool Equals(string x, string y)
    {
      return x.ToLower().Equals(y.ToLower());
    }

    public int GetHashCode(string obj)
    {
      return obj.ToLower().GetHashCode();
    }
  }
}