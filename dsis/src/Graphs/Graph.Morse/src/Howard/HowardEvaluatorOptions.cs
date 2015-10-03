using System;

namespace DSIS.Graph.Morse.Howard
{
  [Serializable]
  public class HowardEvaluatorOptions : IMorseOptions
  {
    public string MethodName
    {
      get { return "Howard"; }
    }

    public double Eps { get; set; }

    public HowardEvaluatorOptions()
    {
      Eps = 1e-8;
    }
  }
}