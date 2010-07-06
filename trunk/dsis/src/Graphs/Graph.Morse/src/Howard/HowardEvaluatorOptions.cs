using System;

namespace DSIS.Graph.Morse.Howard
{
  [Serializable]
  public class HowardEvaluatorOptions
  {
    public double Eps { get; set; }

    public HowardEvaluatorOptions()
    {
      Eps = 1e-8;
    }
  }
}