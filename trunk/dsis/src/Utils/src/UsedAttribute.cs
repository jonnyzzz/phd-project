using System;

namespace DSIS.Utils
{
  public class MeansImplicitUseAttribute : Attribute {}

  [AttributeUsage(AttributeTargets.All , AllowMultiple = true)]
  [MeansImplicitUse]
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