using System;

namespace DSIS.Utils
{
  [AttributeUsage(AttributeTargets.All , AllowMultiple = true)]
  public class UsedAttribute : Attribute
  {
    public UsedAttribute([Used("Used Attribute")]string place)
    {
    }

    public UsedAttribute()
    {
    }
  }
}