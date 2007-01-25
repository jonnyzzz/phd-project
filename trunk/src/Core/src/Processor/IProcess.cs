using System;
using DSIS.Core.Util;

namespace DSIS.Core.Processor
{
  public interface IProcess
  {
    void Execute(IProgressInfo info);
  }
}