namespace DSIS.Core.Ioc.Ex
{
  public static class ApplicationEntryPoint
  {
    public static int DoMain(string[] args)
    {
      using (var rootContainer = new ComponentContainer<ComponentInterfaceAttribute, ComponentImplemetationAttribute>())
      {        
        new ScanCurrentFolder(rootContainer);
        new AppDomainSubscription(rootContainer);

        rootContainer.RegisterComponentInstance<ICommandLine>(new CommandLineImpl(args));
        
        var app = rootContainer.GetComponent<IApplication>();
        return app.Main();
      }
    }
  }
}
