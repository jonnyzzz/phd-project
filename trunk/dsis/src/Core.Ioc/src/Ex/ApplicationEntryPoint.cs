namespace DSIS.Core.Ioc.Ex
{
  public static class ApplicationEntryPoint
  {
    public static int DoMain(string[] args)
    {
      using (var rootContainer = new ComponentContainer<ComponentInterfaceAttribute, ComponentImplemetationAttribute>())
      {
        rootContainer.RegisterComponentInstance<ICommandLine>(new CommandLineImpl(args));
        rootContainer.Subscribe();


        var app = rootContainer.GetComponent<IApplication>();
        return app.Main();
      }
    }
  }
}
