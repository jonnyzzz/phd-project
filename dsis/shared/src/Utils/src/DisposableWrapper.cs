using System;

namespace DSIS.Utils
{
  public class DisposableWrapper : IDisposable
  {
    private readonly Action myDelegate;

    public DisposableWrapper(Action myDelegate)
    {
      this.myDelegate = myDelegate;
    }

    public void Dispose()
    {
      myDelegate();
    }
  }
}