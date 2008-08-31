using System;

namespace DSIS.Utils
{
  [AttributeUsage(AttributeTargets.All, AllowMultiple = true)]
  public class UsedInTestsAttribute : UsedAttribute
  {
    public UsedInTestsAttribute(string place) : base(place)
    {
    }

    public UsedInTestsAttribute()
    {
    }
  }
}