using System;
using System.ComponentModel;
using DSIS.Scheme.Objects.Systemx;
using DSIS.Utils.Bean;

namespace DSIS.Function.Solvers.Merson
{
  [Serializable]
  public class MersonOptions : IContiniousSolverParameters
  {
    [IncludeGenerate(Title = "Steps", Description = "Number of steps to apply evaluation method"), DefaultValue(5), GreatherThanZero]
    public int Steps { get; set; }

    [IncludeGenerate(Title = "dT", Description = "Time interval for one step"), DefaultValue(0.1), GreatherThanZero]
    public double dTime { get; set; }

    public MersonOptions()
    {
      Steps = 20;
      dTime = 0.01;
    } 
  }
}