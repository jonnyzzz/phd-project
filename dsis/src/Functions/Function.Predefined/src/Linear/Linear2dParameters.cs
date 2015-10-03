using System;
using DSIS.Scheme.Objects.Systemx;
using DSIS.Utils.Bean;

namespace DSIS.Function.Predefined.Linear
{
  [Serializable]
  public class Linear2dParameters : ISystemInfoParameters
  {
    [IncludeGenerate(Title = "A")]
    public double A { get; set; }
    [IncludeGenerate(Title = "B")]
    public double B { get; set; }
    [IncludeGenerate(Title = "C")]
    public double C { get; set; }
    [IncludeGenerate(Title = "D")]
    public double D { get; set; }
  }
}