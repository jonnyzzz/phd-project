using DSIS.Utils;

namespace DSIS.Spring.Lifecycle
{
  public interface ILifecycle
  {
    event VoidDelegate OnInit;
  }
}