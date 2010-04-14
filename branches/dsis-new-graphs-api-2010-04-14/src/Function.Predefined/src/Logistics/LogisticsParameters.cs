using System;
using DSIS.Scheme.Objects.Systemx;
using DSIS.Utils.Bean;

namespace DSIS.Function.Predefined.Logistics
{
  [Serializable]
  public class LogisticsParameters : ISystemInfoParameters
  {
    [IncludeGenerate(Title="A")]
    public double A { get; set; }
    
  }
}