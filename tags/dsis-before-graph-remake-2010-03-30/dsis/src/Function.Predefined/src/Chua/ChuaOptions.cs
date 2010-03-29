using System;
using System.ComponentModel;
using DSIS.Scheme.Objects.Systemx;
using DSIS.Utils.Bean;

namespace DSIS.Function.Predefined.Chua
{
  [Serializable]
  public class ChuaOptions : ISystemInfoParameters
  {
    [IncludeGenerate(Title = "P1")]
    public double P1 { get; set; }

    [IncludeGenerate(Title = "P2")]
    public double P2 { get; set; }

    [IncludeGenerate(Title = "P3")]
    public double P3 { get; set; }

    [IncludeGenerate(Title = "P4")]
    public double P4 { get; set; }

    public ChuaOptions()
    {
      P1 = 9.85;
      P2 = 14.3;
      P3 = -0.14;
      P4 = 0.28;
    }
  }
}