using System;
using DSIS.Scheme.Objects.Systemx;
using DSIS.Utils.Bean;

namespace DSIS.Function.Predefined.Henon
{
  [Serializable]
  public class HenonDellnitzOptions : ISystemInfoParameters
  {
    [IncludeGenerate(Title = "A")]
    public double A { get; set; }
    [IncludeGenerate(Title = "B")]
    public double B { get; set; }
  }
}