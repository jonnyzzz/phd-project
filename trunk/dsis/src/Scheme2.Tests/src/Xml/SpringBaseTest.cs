using System;
using System.Collections.Generic;
using System.Reflection;
using DSIS.Scheme2.XmlModel;
using NUnit.Framework;

namespace DSIS.Scheme2.Tests.Xml
{
  public abstract class SpringBaseTest
  {
    protected abstract IEnumerable<Assembly> SpringAssemblies {get; }
//    public static IServiceProvider myServiceProvider;

    [SetUp]
    public virtual void SetUp()
    {
      throw new NotImplementedException();
//      myServiceProvider = null;
//      SpringIoCSetup.SetUp(new List<Assembly>(SpringAssemblies).ToArray());     
    }

    [TearDown]
    public void TearDown()
    {
      throw new NotImplementedException();
//      SpringIoCSetup.Dispose();
    }    


    protected XsdComputationScheme Load(string file)
    {
      return TestSchemeGraphLoader.Load(GetType().Assembly, file);
    }
  }
}