using System;
using DSIS.Utils.Bean;

namespace DSIS.UI.Application.Doc.Actions.Segments
{
  public class IterateLineOptions
  {
    private int mySteps = 1;

    [IncludeGenerate(Title = "Iterations count")]
    public int Steps
    {
      get { return mySteps; }
      set
      {
        if (value < 1) throw new ArgumentOutOfRangeException("", "Value should be >= 0");
        mySteps = value;
      }
    }
  }
}