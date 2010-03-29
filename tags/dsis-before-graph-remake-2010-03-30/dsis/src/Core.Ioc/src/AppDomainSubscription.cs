using System;

namespace DSIS.Core.Ioc
{
  public class AppDomainSubscription : IDisposable
  {
    private readonly IComponentContainer myContainer;

    public AppDomainSubscription(IComponentContainer container)
    {
      myContainer = container;
      AppDomain.CurrentDomain.AssemblyLoad += CurrentDomain_AssemblyLoad;
    }

    private void CurrentDomain_AssemblyLoad(object sender, AssemblyLoadEventArgs args)
    {
      myContainer.ScanAssemblies(new[]{args.LoadedAssembly});
    }

    public void Dispose()
    {
      AppDomain.CurrentDomain.AssemblyLoad -= CurrentDomain_AssemblyLoad;
    }
  }
}