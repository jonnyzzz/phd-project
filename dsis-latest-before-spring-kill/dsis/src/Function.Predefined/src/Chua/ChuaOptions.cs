using System;
using System.ComponentModel;
using DSIS.Scheme.Objects.Systemx;
using DSIS.Utils.Bean;

namespace DSIS.Function.Predefined.Chua
{
  [Serializable]
  public class ChuaOptions : ISystemInfoParameters
  {
    [IncludeGenerate(Title = "P1"), DefaultValue(9.85)]
    public double P1 { get; set; }

    [IncludeGenerate(Title = "P2"), DefaultValue(14.3)]
    public double P2 { get; set; }

    [IncludeGenerate(Title = "P3"), DefaultValue(-0.14)]
    public double P3 { get; set; }

    [IncludeGenerate(Title = "P4"), DefaultValue(0.28)]
    public double P4 { get; set; }
  }
}