using System;
using DSIS.Scheme2.XmlModel;

namespace DSIS.Scheme2.Tests.Xml
{
  public class XsdUtil : MockTestBase
  {
    protected static XsdAction Create(Type t)
    {
      return new XsdComputationSchemeCode
               {
                 Assembly = t.Assembly.FullName,
                 Class = t.FullName
               };
    }        
  }
}