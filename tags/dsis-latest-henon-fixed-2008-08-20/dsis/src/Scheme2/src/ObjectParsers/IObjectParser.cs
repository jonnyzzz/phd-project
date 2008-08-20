using System.Xml;
using DSIS.Spring;
using DSIS.Spring.Util;

namespace DSIS.Scheme2.ObjectParsers
{
  public interface IObjectParser
  {
    object Parse(XmlElement element);
  }

  [UsedBySpring]
  public class ObjectParserFactory : AbstractRegistry<IObjectParser>, IObjectParser
  {
    public object Parse(XmlElement element)
    {
      return ForEach<object>(delegate(IObjectParser instance) { return instance.Parse(element); });
    }
  }
}