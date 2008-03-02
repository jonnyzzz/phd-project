using System.Xml;

namespace DSIS.Scheme2.ObjectParsers
{
  public interface IObjectParser
  {
    object Parse(XmlElement element);
  }
}