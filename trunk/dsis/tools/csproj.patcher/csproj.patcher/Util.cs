using System.Text;

namespace csproj.patcher
{
  public class Util
  {
    private static readonly char[] SEP = new char[] { '\\', '/' };

    public static string MakeRelative(string path, string pathBase)
    {
      string[] pathElements = path.Split(SEP);
      string[] pathBaseElements = pathBase.Split(SEP);

      int index = 0;

      for (;
        index < pathElements.Length
        && index < pathBaseElements.Length
        && pathElements[index] == pathBaseElements[index]; index++)
      {
      }

      if (index == pathElements.Length && index == pathBaseElements.Length)
      {
        return pathBaseElements[pathBaseElements.Length - 1];
      }

      var builder = new StringBuilder();
      for (int i = index; i < pathBaseElements.Length - 1; i++)
      {
        builder.Append("../");
      }

      for (int i = index; i < pathElements.Length; i++)
      {
        builder.Append(pathElements[i]).Append("/");
      }
      return builder.ToString().TrimEnd(SEP);
    }

  }
}