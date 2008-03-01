using System;
using DSIS.Scheme2.XmlModel;

namespace DSIS.Scheme2.Tests.Xml
{
  public class XsdUtil
  {
    public static XsdAction Create(Type t)
    {
      XsdUserAction action = new XsdUserAction();
      action.Assembly = t.Assembly.FullName;
      action.Class = t.FullName;
      return action;
    }        
  }
}