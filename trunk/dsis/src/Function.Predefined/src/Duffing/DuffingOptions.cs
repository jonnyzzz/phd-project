using System;
using DSIS.Scheme.Objects.Systemx;
using DSIS.Utils.Bean;

namespace DSIS.Function.Predefined.Duffing
{
  [Serializable]
  public class DuffingOptions : ISystemInfoParameters
  {
    [IncludeGenerate(Title = "Alpha")]
    public double Alpha { get; set; }
    [IncludeGenerate(Title = "K")]
    public double K { get; set; }
    [IncludeGenerate(Title = "Beta")]
    public double Beta { get; set; }

    public DuffingOptions() {
      Alpha = 1;
      Beta = 1;
      K = 0.1;
    }
  }
}