using System;
using System.Xml;
using DSIS.Core.Ioc;

namespace DSIS.Scheme2.ObjectParsers
{
  public interface IObjectParser
  {
    object Parse(XmlElement element);
  }

  [UsedBySpring]
  public class ObjectParserFactory //: AbstractRegistry<IObjectParser>, IObjectParser
  {
    public object Parse(XmlElement element)
    {
      throw new NotImplementedException();
//      return ForEach<object>(delegate(IObjectParser instance) { return instance.Parse(element); });
    }
  }
}