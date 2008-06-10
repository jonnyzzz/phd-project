using System;
using DSIS.Scheme.Objects.Systemx;
using DSIS.Utils.Bean;

namespace DSIS.Function.Predefined.Linear
{
  [Serializable]
  public class Linear1dParameters : ISystemInfoParameters
  {
    [IncludeGenerate(Title = "A")]
    public double A { get; set; }
    [IncludeGenerate(Title = "B")]
    public double B { get; set; }
  }
}