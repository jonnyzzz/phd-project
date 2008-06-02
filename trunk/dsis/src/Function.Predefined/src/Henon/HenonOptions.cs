using System;
using System.ComponentModel;
using DSIS.Utils.Bean;

namespace DSIS.Function.Predefined.Henon
{
  [Serializable]
  public class HenonOptions
  {
    public HenonOptions()
    {
      A = 1.4;
    }

    [IncludeGenerate(Title = "Parameter A"), DefaultValue(1.4)]
    public double A { get; set; }
  }
}