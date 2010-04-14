using System;
using DSIS.Utils.Bean;

namespace DSIS.Scheme.Impl.Actions.Entropy
{
  [Serializable]
  public class EigenEntropyOptions
  {
    [IncludeGenerate(Title = "Eigen precision")]
    public double Eps { get; set; }

    public string Present
    {
      get { return string.Format("Eigen[Eps={0}]", Eps); }
    }

    public EigenEntropyOptions()
    {
      Eps = 1e-4;
    }
  }
}