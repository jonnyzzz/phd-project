using System;

namespace DSIS.Core.Ioc
{
  public class ScanAllLoadedAssemblies
  {
    public ScanAllLoadedAssemblies(IComponentContainer container)
    {
      container.ScanAssemblies(AppDomain.CurrentDomain.GetAssemblies());
    }
  }
}