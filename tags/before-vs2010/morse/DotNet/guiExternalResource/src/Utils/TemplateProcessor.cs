namespace EugenePetrenko.Gui2.ExternalResource.Utils
{
  /// <summary>
  /// Summary description for TemplateProcessor.
  /// </summary>
  public class TemplateProcessor
  {
    private string template;

    public TemplateProcessor(string template)
    {
      this.template = template;
    }

    public void subsitute(string key, string value)
    {
      template = template.Replace("$" + key + "$", value);
    }

    public override string ToString()
    {
      return template;
    }
  }
}