using System;

namespace DSIS.Graph.Morse.JVR
{
  [Serializable]
  public class JVREvaluatorOptions
  {
    public double Eps { get; set; }

    public JVREvaluatorOptions()
    {
      Eps = 1e-8;
    }
  }
}