using System;
using DSIS.Scheme.Objects.Systemx;
using DSIS.Utils.Bean;

namespace DSIS.Function.Predefined.Chua
{
  [Serializable]
  public class ChuaOptions2 : ISystemInfoParameters
  {
    [IncludeGenerate(Title = "A")]
    public double A { get; set; }

    [IncludeGenerate(Title = "B")]
    public double B { get; set; }

    [IncludeGenerate(Title = "M0")]
    public double M0 { get; set; }

    [IncludeGenerate(Title = "M1")]
    public double M1 { get; set; }

    public ChuaOptions2()
    {
      A = 18;
      B = 33;
      M0 = -0.2;
      M1 = 0.01;
    }
  }
}