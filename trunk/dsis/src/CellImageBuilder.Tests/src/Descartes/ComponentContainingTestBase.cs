using System;
using DSIS.Core.Ioc;
using DSIS.Core.Ioc.JC;
using DSIS.Utils;
using NUnit.Framework;

namespace DSIS.CellImageBuilder.Tests.Descartes
{
  public class ComponentContainingTestBase
  {
    private IComponentContainer myContainer;

    public IComponentContainer Container
    {
      get { return myContainer; }
    }

    [SetUp]
    public void SetUp()
    {
      myContainer = new JComponentContainer<ComponentImplementationAttribute>();
      new ScanCurrentFolder(myContainer);
      myContainer.ScanAssemblies(AppDomain.CurrentDomain.GetAssemblies());

      myContainer.Start();  

      var info = myContainer.GetType().GetMethod("GetComponent");
      foreach (var prop in GetType().GetProperties())
      {
        if (prop.IsDefined<AutowireAttribute>())
        {
          var obj = info.MakeGenericMethod(prop.PropertyType).Invoke(myContainer, new object[0]);
          prop.SetValue(this, obj, null);
        }
      }
    }

    [TearDown]
    public void TearDown()
    {
      myContainer.Dispose();      
    }
  }
}