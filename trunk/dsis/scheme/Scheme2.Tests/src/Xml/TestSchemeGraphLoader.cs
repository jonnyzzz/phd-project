using System;
using System.IO;
using System.Reflection;
using DSIS.Scheme2.Tests.src.Xml;
using DSIS.Scheme2.XmlModel;
using NUnit.Framework;

namespace DSIS.Scheme2.Tests.Xml
{
  [TestFixture]
  public class TestSchemeGraphLoader
  {
    [Test]
    public void Test_01()
    {
      Assert.That(LoadTest_01(), NIs.Not.Null);
    }

    public static XsdComputationScheme LoadTest_01()
    {      
      return Load("test_01.xml");
    }

    public static XsdComputationScheme LoadTest_02()
    {      
      return Load("test_02.xml");
    }

    public static XsdComputationScheme LoadTest_03()
    {      
      return Load("test_03.xml");
    }

    public static XsdComputationScheme LoadTest_04()
    {      
      return Load("test_04.xml");
    }

    public static XsdComputationScheme LoadTest_05()
    {      
      return Load("test_05.xml");
    }

    private static XsdComputationScheme Load(string xml)
    {
      SchemeGraphLoader l = new SchemeGraphLoader();
      return l.Parse(Stream(xml));
    }

    private static Stream Stream(string name)
    {
      try
      {
        Stream stream =
          typeof (TestSchemeGraphLoader).Assembly.GetManifestResourceStream("DSIS.Scheme2.Tests.resources." + name);
        Assert.That(stream, NIs.Not.Null);
        return stream;
      }
      catch (Exception e)
      {
        Assembly assembly = typeof (TestSchemeGraphLoader).Assembly;
        DumpResources(assembly);
        throw new Exception(e.Message, e);
      }
    }

    private static void DumpResources(Assembly assembly)
    {
      foreach (string resourceName in assembly.GetManifestResourceNames())
      {
        Console.Out.WriteLine("resourceName = {0}", resourceName);
      }
    }
  }
}