using System;
using DSIS.Scheme.Objects.Systemx;
using DSIS.Utils.Bean;

namespace DSIS.Function.Predefined.Lorentz
{
  [Serializable]
  public class LorentzParameters : ISystemInfoParameters
  {
    [IncludeGenerate(Title="Sigma")]
    public double Sigma { get; set; }
    [IncludeGenerate(Title = "Rho")]
    public double Rho { get; set; }
    [IncludeGenerate(Title = "Beta")]
    public double Beta { get; set; }
    
  }
}