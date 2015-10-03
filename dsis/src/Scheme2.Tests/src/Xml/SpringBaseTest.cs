using System.Collections.Generic;
using System.Reflection;
using DSIS.Scheme2.XmlModel;
using DSIS.Spring;
using NUnit.Framework;

namespace DSIS.Scheme2.Tests.Xml
{
  public abstract class SpringBaseTest
  {
    protected abstract IEnumerable<Assembly> SpringAssemblies {get; }

    [SetUp]
    public virtual void SetUp()
    {
      Log4NetConfigurator.SetUp();
      SpringIoCSetup.SetUp(new List<Assembly>(SpringAssemblies).ToArray());     
    }

    [TearDown]
    public void TearDown()
    {
      SpringIoCSetup.Dispose();
      Log4NetConfigurator.Dispose();
    }    


    protected XsdComputationScheme Load(string file)
    {
      return TestSchemeGraphLoader.Load(GetType().Assembly, file);
    }
  }
}