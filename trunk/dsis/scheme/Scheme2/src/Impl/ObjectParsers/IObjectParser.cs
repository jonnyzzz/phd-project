using System.Xml;

namespace DSIS.Scheme2.Impl.ObjectParsers
{
  public interface IObjectParser
  {
    object Parse(XmlElement element);
  }
}