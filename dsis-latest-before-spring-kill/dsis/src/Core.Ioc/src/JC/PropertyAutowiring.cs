using System;
using System.Reflection;

namespace DSIS.Core.Ioc.JC
{
  public class PropertyAutowiring : Autowiring
  {
    private readonly object myHost;
    private readonly PropertyInfo myProperty;

    public PropertyAutowiring(object host, PropertyInfo property) : base(property.PropertyType, property.DeclaringType + "#" + property.Name)
    {
      myHost = host;
      myProperty = property;
    }

    protected override void DoSetValue(object value)
    {
      try
      {
        myProperty.SetValue(myHost, value, null);
      } catch (Exception e)
      {
        throw new ArgumentException("Failed to set property due to exception: " + e.Message, e);
      }      
    }
  }
}