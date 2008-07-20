using System;
using System.IO;
using System.Reflection;
using System.Xml;
using System.Xml.Schema;
using System.Xml.Serialization;
using DSIS.Scheme.Xml;
using DSIS.Scheme2.Tests.src.Xml; 
using NUnit.Framework;
using NUnit.Framework.SyntaxHelpers;

namespace DSIS.Scheme.Tests.Xml
{
  [TestFixture]
  public class XmlSchemeTests
  {
    [Test]
    public void Test_01()
    {
      var gr = Load("XmlTest_01.xml");
      var bld = new XsdGraphBuilder();
      var actions = bld.BuildActions(gr);
      var code = actions["Test_01"].ToString();
      try
      {
        Assert.That(code, Is.EqualTo(@"AgragateAction:
A|DSIS.Scheme.Tests.testData.A => 
    B|DSIS.Scheme.Tests.testData.B
B|DSIS.Scheme.Tests.testData.B => 
    EndAction|DSIS.Scheme.Actions.AgregateAction+EndAction
EndAction|DSIS.Scheme.Actions.AgregateAction+EndAction => 
StartAction|DSIS.Scheme.Actions.AgregateAction+StartAction => 
    A|DSIS.Scheme.Tests.testData.A
"));
      } catch(Exception e)
      {
        Console.Out.WriteLine("code = {0}", code);
        throw new Exception(e.Message, e);
      }
    }

    [Test]
    public void Test_02()
    {
      var gr = Load("XmlTest_02.xml");
      var bld = new XsdGraphBuilder();
      var actions = bld.BuildActions(gr);
      var code = actions["Test_02"].ToString();
      try
      {
        Assert.That(code.Trim(), Is.EqualTo(@"AgragateAction:
C|C:     AgragateAction:
     A|DSIS.Scheme.Tests.testData.A => 
         B|DSIS.Scheme.Tests.testData.B
     B|DSIS.Scheme.Tests.testData.B => 
         EndAction|DSIS.Scheme.Actions.AgregateAction+EndAction
     EndAction|DSIS.Scheme.Actions.AgregateAction+EndAction => 
     StartAction|DSIS.Scheme.Actions.AgregateAction+StartAction => 
         A|DSIS.Scheme.Tests.testData.A
      => 
    EndAction|DSIS.Scheme.Actions.AgregateAction+EndAction
EndAction|DSIS.Scheme.Actions.AgregateAction+EndAction => 
StartAction|DSIS.Scheme.Actions.AgregateAction+StartAction => 
    C|C:     AgragateAction:
     A|DSIS.Scheme.Tests.testData.A => 
         B|DSIS.Scheme.Tests.testData.B
     B|DSIS.Scheme.Tests.testData.B => 
         EndAction|DSIS.Scheme.Actions.AgregateAction+EndAction
     EndAction|DSIS.Scheme.Actions.AgregateAction+EndAction => 
     StartAction|DSIS.Scheme.Actions.AgregateAction+StartAction => 
         A|DSIS.Scheme.Tests.testData.A"  ));
      } catch(Exception e)
      {
        Console.Out.WriteLine("code = '{0}'", code);
        throw new Exception(e.Message, e);
      }
    }

    private Graphs Load(string res)
    {
      return Parse(Stream(GetType().Assembly, "DSIS.Scheme.Tests.testData." + res));
    }

    private static Stream Stream(Assembly assembly, string name)
    {
      try
      {
        Stream stream = assembly.GetManifestResourceStream(name);
        Assert.That(stream, NIs.Not.Null);
        return stream;
      }
      catch (Exception e)
      {
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

    private static XmlSchema Schema
    {
      get
      {
        using (
          Stream str =
            typeof(XsdGraphBuilder).Assembly.GetManifestResourceStream(
              "DSIS.Scheme.Xml.resources.computation-graph-scheme-xml.xsd"))
        {
          return XmlSchema.Read(str, null);
        }
      }
    }

    public Graphs Parse(Stream stream)
    {
      var settings = new XmlReaderSettings { ValidationType = ValidationType.Schema };
      settings.Schemas.Add(Schema);

      // Load the AllAssembliesXml, validating against the schema
      Graphs graph;
      using (XmlReader xmlrValidating = XmlReader.Create(stream, settings))
        graph = (Graphs)new XmlSerializer(typeof(Graphs)).Deserialize(xmlrValidating);

      return graph;
    }


  }
}