using System;
using DSIS.Utils.Bean;

namespace DSIS.Scheme.Impl.Actions.Entropy
{
  [Serializable]
  public class EigenEntropyOptions
  {
    [IncludeGenerate(Title = "Eigen precision")]
    public double Eps { get; set; }

    public EigenEntropyOptions()
    {
      Eps = 1e-4;
    }
  }
}