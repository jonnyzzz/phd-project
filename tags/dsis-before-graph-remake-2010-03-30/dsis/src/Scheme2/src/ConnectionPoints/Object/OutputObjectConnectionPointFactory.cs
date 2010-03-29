using System;
using System.Reflection;
using DSIS.Core.Ioc;

namespace DSIS.Scheme2.ConnectionPoints.Object
{
  [UsedBySpring]
  public class OutputObjectConnectionPointFactory :// AbstractRegistry<IOutputObjectConnectionPointFactoryExtension>,
                                                    IOutputObjectConnectionPointFactoryExtension 
  {
    public IOutputConnectionPoint Output(string name, object instance, MemberInfo member)
    {
      throw new NotImplementedException();
//      return
//        ForEach<IOutputConnectionPoint>(
//          delegate(IOutputObjectConnectionPointFactoryExtension factory) { return factory.Output(name, instance, member); });
    }
  }
}