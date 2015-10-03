using System.Collections.Generic;
using System.Globalization;
using System.Reflection;
using System.Text;
using DSIS.Core.Builders;
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
    public void Test_SystemSpace01()
    {
      SchemeGraph build = myFactory.Build(Load("DSIS.Scheme.Objects.Tests.resources.SystemSpace_01.xml"));
      Assert.That(build, NIs.Not.Null);

      build.Start();

      TestGraphRegistry.AssertData("Data set: Dim=1, L=(-1, ), R=(1, ), Grid=(10, )");      
    }

    [Test]
    public void Test_SystemInfo01()
    {
      SchemeGraph build = myFactory.Build(Load("DSIS.Scheme.Objects.Tests.resources.SystemInfo_01.xml"));
      Assert.That(build, NIs.Not.Null);

      build.Start();

      TestGraphRegistry.AssertData("Data set: Food Chain");      
    }

    [Test]
    public void Test_SystemInfo02()
    {
      SchemeGraph build = myFactory.Build(Load("DSIS.Scheme.Objects.Tests.resources.SystemInfo_02.xml"));
      Assert.That(build, NIs.Not.Null);

      build.Start();

      TestGraphRegistry.AssertData("Data set: Henon a=1.4");
    }
    
    [Test]
    public void Test_SystemInfo03()
    {
      SchemeGraph build = myFactory.Build(Load("DSIS.Scheme.Objects.Tests.resources.SystemInfo_03.xml"));
      Assert.That(build, NIs.Not.Null);

      build.Start();

      TestGraphRegistry.AssertData("Data set: Henon a=1.4", "Data set: Food Chain");
    }

    [Test]
    public void Test_DoubleArray01()
    {
      SchemeGraph build = myFactory.Build(Load("DSIS.Scheme.Objects.Tests.resources.DoubleArray_01.xml"));
      Assert.That(build, NIs.Not.Null);

      build.Start();

      TestGraphRegistry.AssertData("Data set: 5, -5, ");      
    }

    
    [Test]
    public void Test_PointMethodSettings_01()
    {
      SchemeGraph build = myFactory.Build(Load("DSIS.Scheme.Objects.Tests.resources.PointMethod_01.xml"));
      Assert.That(build, NIs.Not.Null);

      build.Start();

      TestGraphRegistry.AssertData("Data set: Point Method");
    }

    [Test]
    public void Test_BoxMethod_01()
    {
      SchemeGraph build = myFactory.Build(Load("DSIS.Scheme.Objects.Tests.resources.BoxMethod_01.xml"));
      Assert.That(build, NIs.Not.Null);

      build.Start();

      TestGraphRegistry.AssertData("Data set: Box Method");
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

  [UsedByScheme]
  public class InfoSpaceAction
  {
    private ISystemInfo mySystemInfo;

    [Input("SystemInfo")]
    public ISystemInfo SystemInfo
    {
      get { return mySystemInfo; }
      set { 
        mySystemInfo = value;        
        TestGraphRegistry.Log("Data set: " + mySystemInfo.PresentableName);        
      }
    }
  }


  [UsedByScheme]
  public class CellImageBuilderSettingsAction
  {
    [Input("Settings")]
    public ICellImageBuilderSettings SystemInfo
    {
      set { 
        TestGraphRegistry.Log("Data set: " + value.PresentableName);        
      }
    }
  }
  
  [UsedByScheme]
  public class DoubleArray
  {
    private double[] mySystemInfo;

    [Input("Arr")]
    public double[] SystemInfo
    {
      get { return mySystemInfo; }
      set { 
        mySystemInfo = value;        
        StringBuilder sb = new StringBuilder();
        sb.Append("Data set: ");
        foreach (double d in value)
        {
          sb.Append(d.ToString(CultureInfo.InvariantCulture)).Append(", ");
        }
        TestGraphRegistry.Log(sb.ToString());        
      }
    }
  }
}