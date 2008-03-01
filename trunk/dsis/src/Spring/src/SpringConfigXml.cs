using System;

namespace DSIS.Spring
{
  [AttributeUsage(AttributeTargets.Assembly, AllowMultiple = true)]
  public class SpringConfigXmlAttribute : Attribute
  {
    private readonly string myLocation;
    private readonly Type myType;
    
    public string Location
    {
      get { return myLocation;}
    }

    public string Namespace
    {
      get { return myType.Namespace; }
    }
    
    public SpringConfigXmlAttribute(string location, Type type)
    {
      myLocation = location;
      myType = type;
    }
  }
}