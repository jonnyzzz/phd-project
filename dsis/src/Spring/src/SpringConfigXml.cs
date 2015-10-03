using System;

namespace DSIS.Spring
{
  [AttributeUsage(AttributeTargets.Assembly, AllowMultiple = true)]
  public class SpringConfigXmlAttribute : Attribute
  {
    private readonly string myLocation;
    private string myNamespace;
    private Type myType;

    public string Location
    {
      get { return myLocation; }
    }

    public Type Type
    {
      get { return myType; }
      set
      {
        myNamespace = value.Namespace;
        myType = value;
      }
    }

    public string Namespace
    {
      get { return myNamespace; }
      set
      {
        myNamespace = value;
        myType = null;
      }
    }

    public SpringConfigXmlAttribute(string location)
    {
      myLocation = location;
    }
  }
}