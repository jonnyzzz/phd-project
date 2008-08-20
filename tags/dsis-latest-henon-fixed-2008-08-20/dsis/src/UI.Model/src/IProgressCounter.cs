using System;

namespace DSIS.UI.Model
{
  public interface IProgressCounter : IProgressTick, IProgressInfo, IDisposable
  {    
  }
}