using System;
using System.ComponentModel;
using DSIS.Scheme.Objects.Systemx;
using DSIS.Utils.Bean;

namespace DSIS.Function.Predefined.FoodChain
{
  [Serializable]
  public class FoodChainOptions : ISystemInfoParameters
  {
    public FoodChainOptions()
    {
      Mu0 = 3.4001;
      Mu1 = 1;
      Mu2 = 4;
    }

    [IncludeGenerate(Title = "mu 0"), DefaultValue(3.4001)]
    public double Mu0 { get; set; }
    [IncludeGenerate(Title = "mu 1"), DefaultValue(1d)]
    public double Mu1 { get; set; }
    [IncludeGenerate(Title = "mu 2"), DefaultValue(4d)]
    public double Mu2 { get; set; }
  }
}