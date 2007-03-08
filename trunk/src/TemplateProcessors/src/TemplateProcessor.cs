using System.Collections.Generic;
using System.Text.RegularExpressions;

namespace DSIS.TemplateProcessors
{
  public static class TemplateProcessor
  {
    private static Regex ourSubstitute = new Regex(@"\[([a-zA-Z0-9]+)\]", RegexOptions.Compiled);

    public static string Substitute(Template template, Dictionary<string, string> values)
    {
      MatchEvaluator evaluator = delegate(Match match)
                                   {
                                     string v = match.Groups[1].Value;
                                     string r;
                                     if (!values.TryGetValue(v, out r))
                                     {
                                       throw new KeyNotFoundException("Key '" + v + "' was not found");
                                     }
                                     return values[v];
                                   };
      return ourSubstitute.Replace(template.TemplateText, evaluator);
    }
  }
}