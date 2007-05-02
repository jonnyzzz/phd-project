using System.IO;
using System.Reflection;

namespace DSIS.TemplateProcessors
{
  public class Template
  {
    public readonly string Resource;
    public readonly Assembly Assembly;
        
    private string myCachedTemplate = null;

    public Template(string resource, Assembly assembly)
    {
      Resource = resource;
      Assembly = assembly;
    }

    public Template(string text)
    {
      myCachedTemplate = text;
      Resource = null;
      Assembly = null;
    }

    public string TemplateText 
    {
      get
      {
        if (myCachedTemplate == null)
        {
          using (TextReader tr = new StreamReader(Assembly.GetManifestResourceStream(Resource)))
            myCachedTemplate = tr.ReadToEnd();
        }

        return myCachedTemplate;
      }
    }
  }
}
