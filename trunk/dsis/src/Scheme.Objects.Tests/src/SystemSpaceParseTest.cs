using System.Collections.Generic;
using System.Reflection;
using DSIS.Core.System;
using DSIS.Scheme.Objects.Systemx;
using DSIS.Scheme2;
using DSIS.Scheme2.Attributed;
using DSIS.Scheme2.Graph;
using DSIS.Scheme2.Tests.src.Xml;
using DSIS.Scheme2.Tests.testData;
using DSIS.Scheme2.Tests.Xml;
using NUnit.Framework;

namespace DSIS.Scheme.Objects.Tests
{
  [TestFixture]
  public class SystemSpaceParseTest : SchemeGraphBaseTest
  {
    protected override IEnumerable<Assembly> SpringAssemblies
    {
      get
      {
        foreach (Assembly assembly in SpringAssembliesBase())
        {
          yield return assembly;
        }
        yield return typeof (SystemSpaceParser).Assembly;
      }
    }

    private IEnumerable<Assembly> SpringAssembliesBase()
    {
      return base.SpringAssemblies;
    }

    [Test]
    public void Test_01()
    {
      SchemeGraph build = myFactory.Build(Load("DSIS.Scheme.Objects.Tests.resources.SystemSpace_01.xml"));
      Assert.That(build, NIs.Not.Null);

      build.Start();

      TestGraphRegistry.AssertData("Data set: Dim=1, L=(-1, ), R=(1, ), Grid=(10, )");      
    }
  }

  [UsedByScheme]
  public class SystemSpaceAction
  {
    private ISystemSpace mySystemSpace;

    [Input("SystemSpace")]
    public ISystemSpace SystemSpace
    {
      get { return mySystemSpace; }
      set { 
        mySystemSpace = value;        
        TestGraphRegistry.Log("Data set: " + (mySystemSpace.ToString() ?? "NULL"));        
      }
    }
  }
}