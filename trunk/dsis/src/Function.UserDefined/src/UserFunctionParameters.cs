using System;
using DSIS.Core.System;
using DSIS.Utils.Bean;

namespace DSIS.Function.UserDefined
{
  [Serializable]
  public class UserFunctionParameters
  {
    [IncludeGenerate(Title="Dimension", Description = "Enter system function dimension")]
    public int Dimension { get; set; }

    [IncludeGenerate(Title = "System type")]
    public SystemType SystemType { get; set; }

    [IncludeGenerate(Title = "Enter function code", Description = "TODO")]
    public string Code { get; set; }

    public UserFunctionParameters()
    {
      Dimension = 2;
      SystemType = SystemType.Discrete;
      Code = 
        @"//Use x1,..,x_n as coordinate values." + Environment.NewLine +
        @"//Use f1,...,f_n as results. " + Environment.NewLine + 
        @"//You may use var to define variable." + Environment.NewLine;
    }
  }
}