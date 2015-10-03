using System;

namespace DSIS.Utils
{
  public class DisposableWrapper : IDisposable
  {
    private readonly VoidDelegate myDelegate;

    public DisposableWrapper(VoidDelegate myDelegate)
    {
      this.myDelegate = myDelegate;
    }

    public void Dispose()
    {
      myDelegate();
    }
  }
}