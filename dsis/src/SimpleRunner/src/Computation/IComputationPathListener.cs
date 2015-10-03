using System;
using System.Collections.Generic;
using DSIS.Utils;

namespace DSIS.SimpleRunner.Computation
{
  public interface IComputationPathListener
  {
    /// <summary>
    /// Pair.First - format string for Path from title as {0}. 
    /// path will be Path.Combine(basePath, string.Format(pair.Firse, title)).
    /// </summary>
    IEnumerable<Pair<string, Action<string>>>  FormatPath { get;}
    void ComputationTitle(string title);
  }
}