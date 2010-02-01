using System;
using JetBrains.Annotations;

namespace DSIS.Utils
{
  [AttributeUsage(AttributeTargets.All , AllowMultiple = true)]
  [MeansImplicitUse]
  public class UsedAttribute : Attribute
  {
    public UsedAttribute([Used("Used Attribute")] string place)
    {
    }

    public UsedAttribute()
    {
    }
  }
}

