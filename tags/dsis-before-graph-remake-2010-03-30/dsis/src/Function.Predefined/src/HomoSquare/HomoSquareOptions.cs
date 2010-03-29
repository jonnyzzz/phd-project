using System;
using DSIS.Scheme.Objects.Systemx;
using DSIS.Utils.Bean;

namespace DSIS.Function.Predefined.HomoSquare
{
  [Serializable]
  public class HomoSquareOptions : ISystemInfoParameters
  {
    [IncludeGenerate(Title = "A")]
    public double A { get; set; }
  }
}