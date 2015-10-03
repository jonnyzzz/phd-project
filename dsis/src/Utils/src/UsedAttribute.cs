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

  [AttributeUsage(AttributeTargets.All, AllowMultiple = true)]
  public class UsedInTests : UsedAttribute
  {
    public UsedInTests(string place) : base(place)
    {
    }

    public UsedInTests()
    {
    }
  }
}