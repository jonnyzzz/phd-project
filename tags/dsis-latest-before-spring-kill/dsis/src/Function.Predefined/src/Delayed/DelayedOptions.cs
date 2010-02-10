using System;
using DSIS.Scheme.Objects.Systemx;
using DSIS.Utils.Bean;

namespace DSIS.Function.Predefined.Delayed
{
  [Serializable]
  public class DelayedOptions : ISystemInfoParameters
  {
    [IncludeGenerate(Title = "A")]
    public double A { get; set; }
  }
}