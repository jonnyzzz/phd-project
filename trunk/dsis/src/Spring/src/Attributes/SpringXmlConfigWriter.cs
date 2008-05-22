using System;
using System.IO;
using System.Xml;
using DSIS.Utils;

namespace DSIS.Spring.Attributes
{
  [UsedBySpring]
  public class SpringXmlConfigWriter
  {
    private const string OBJECTS_NAMESPACE = "http://www.springframework.net";

    private readonly XmlDocument myDoc;
    private readonly XmlElement myObjectsElement;

    public SpringXmlConfigWriter()
    {
      myDoc = new XmlDocument();

      myDoc.LoadXml(  
        @"
       <objects xmlns='http://www.springframework.net'
         xmlns:xsi='http://www.w3.org/2001/XMLSchema-instance'
         xsi:schemaLocation='http://www.springframework.net http://www.springframework.net/xsd/spring-objects.xsd'
         default-autowire='autodetect'
         default-dependency-check='all'
         default-lazy-init='false'>
        </objects>
      ");

      myObjectsElement = myDoc.DocumentElement;
    }

    public void RegisterBean(string name, Type type)
    {
      XmlElement element = myObjectsElement.CreateChildElement("object", OBJECTS_NAMESPACE);
      element.CreateAttribute("id", name);
      element.CreateAttribute("type", type.AssemblyQualifiedName);
    }

    public void WriteConfig(string file)
    {
      using (TextWriter tw = File.CreateText(file))
        myDoc.Save(tw);
    }
  }
}