using System;
using DSIS.Scheme.Objects.Systemx;
using DSIS.Utils.Bean;

namespace DSIS.Function.Predefined.HomoLinear
{
  [Serializable]
  public class HomoLinearOptions : ISystemInfoParameters
  {
    [IncludeGenerate(Title = "A")]
    public double A { get; set;}
  }
}