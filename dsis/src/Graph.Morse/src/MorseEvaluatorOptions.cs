using System;

namespace DSIS.Graph.Morse
{
  [Serializable]
  public class MorseEvaluatorOptions
  {
    public double Eps { get; set; }

    public MorseEvaluatorOptions()
    {
      Eps = 1e-8;
    }
  }
}