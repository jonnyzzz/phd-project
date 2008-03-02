using System;

namespace DSIS.Scheme2.XmlModel
{
  public class CurrentAppDomainFactoryException : Exception
  {
    public CurrentAppDomainFactoryException(string message, Exception innerException) : base(message, innerException)
    {
    }

    public CurrentAppDomainFactoryException(string message) : base(message)
    {
    }
  }
}