using System;

namespace EugenePetrenko.Shared.Utils
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