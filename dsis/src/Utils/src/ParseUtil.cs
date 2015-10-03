using System.Globalization;

namespace DSIS.Utils
{
  public static class ParseUtil
  {
    public static bool TryParse(string value, out double result)
    {
      if (double.TryParse(value, out result)
          || double.TryParse(value, NumberStyles.Any, CultureInfo.InvariantCulture, out result)
          || double.TryParse(value.Replace(".", ","), out result)
          || double.TryParse(value.Replace(",", "."), out result))
      {        
        return true;
      }
      return false;
    }
  }
}