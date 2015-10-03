using System;
using DSIS.CodeCompiler;
using DSIS.Utils;
using EugenePetrenko.Shared.Core.Ioc;
using EugenePetrenko.Shared.Core.Ioc.Api;
using EugenePetrenko.Shared.Core.Ioc.JC;
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

    [TestFixtureSetUp]
    public void SetUp()
    {
      CodeCompilerFilenameGenerator.DeleteAllGeneratedFiles();

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

    [TestFixtureTearDown]
    public void TearDown()
    {
      myContainer.Dispose();      
    }
  }
}