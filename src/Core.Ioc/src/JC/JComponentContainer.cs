using System;
using System.Collections.Generic;
using System.Reflection;
using EugenePetrenko.Shared.Core.Ioc.Api;

namespace EugenePetrenko.Shared.Core.Ioc.JC
{
  public class JComponentContainer<TImpl> : JComponentContainerBase
    where TImpl : ComponentImplementationAttributeBase
  {
    private readonly IAssemblyScaner myScanner;
    private readonly HashSet<Type> myStartable = new HashSet<Type>();

    public JComponentContainer(IAssemblyScaner scanner, JContainer container, ITypesFilter filter)
      : base(container, filter)
    {
      myScanner = scanner;
    }

    public JComponentContainer(ITypesFilter filter)
      : this(new AssemblyScanerImpl(filter), CreateContainer(filter), filter)
    {
    }

    public JComponentContainer() : this(new AssemblyWithComponentsFilerImpl())
    {
    }

    private static JContainer CreateContainer(ITypesFilter filter)
    {
      return new JContainer(filter);
    }

    public override IComponentService Start()
    {
      Container.RegisterInstance(myScanner);
      base.Start();

      foreach (var type in myStartable)
        Container.GetComponents(type);

      return this;
    }

    protected override void LookupAssembly(Assembly assembly)
    {
      LookupAttributes<JContainerPredefinedComponentAttribute>(assembly);
      LookupAttributes<TImpl>(assembly);
    }

    private void LookupAttributes<TImpl2>(Assembly assembly)
      where TImpl2 : ComponentImplementationAttributeBase
    {
      foreach (var loadType in myScanner.LoadTypes<TImpl2>(assembly))
      {
        if (loadType.Second.Startable && !typeof (IStartableComponent).IsAssignableFrom(loadType.First))
          myStartable.Add(loadType.First);

        Container.RegisterComponent(loadType.First);
      }
    }

    protected override JComponentContainerBase CreateContainer<TImpl2>()
    {
      var newContainer = new JContainer(Filter, Container);
      return new JComponentContainer<TImpl2>(myScanner, newContainer, Filter);
    }
  }
}