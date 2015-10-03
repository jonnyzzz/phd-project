using System;
using DSIS.Scheme.Objects.Systemx;
using DSIS.Utils.Bean;

namespace DSIS.Function.Predefined.VanDerPol
{
  [Serializable]
  public class VanDerPolParameters : ISystemInfoParameters
  {
    [IncludeGenerate(Title = "A")]
    public double A { get; set; }
  }
}