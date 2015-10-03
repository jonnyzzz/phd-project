using System;
using DSIS.Scheme2.XmlModel;

namespace DSIS.Scheme2.Tests.Xml
{
  public class XsdUtil : MockTestBase
  {
    public static XsdAction Create(Type t)
    {
      XsdComputationSchemeCode action = new XsdComputationSchemeCode();
      action.Assembly = t.Assembly.FullName;
      action.Class = t.FullName;
      return action;
    }        
  }
}