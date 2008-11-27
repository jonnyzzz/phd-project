using System;

namespace DSIS.UI.Application.Actions
{
  [AttributeUsage(AttributeTargets.Assembly, AllowMultiple = true)]
  public class ActionDescriptorXmlAttributre : Attribute
  {
    private readonly string myLocation;
    private Type myType;

    public string Location
    {
      get { return myLocation; }
    }

    public Type Type
    {
      get { return myType; }
      set { myType = value; }
    }
    
    public ActionDescriptorXmlAttributre(string location)
    {
      myLocation = location;
    }
  }
}