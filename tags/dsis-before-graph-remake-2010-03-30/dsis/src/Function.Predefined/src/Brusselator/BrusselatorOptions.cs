using System;
using DSIS.Scheme.Objects.Systemx;
using DSIS.Utils.Bean;

namespace DSIS.Function.Predefined.Brusselator
{
  [Serializable]
  public class BrusselatorOptions : ISystemInfoParameters
  {
    [IncludeGenerate(Title = "P1")]
    public double P1 { get; set; }

    [IncludeGenerate(Title = "P2")]
    public double P2 { get; set; }
  }
}