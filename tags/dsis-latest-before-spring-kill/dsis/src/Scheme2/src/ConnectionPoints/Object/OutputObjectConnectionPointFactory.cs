using System.Reflection;
using DSIS.Spring;
using DSIS.Spring.Util;

namespace DSIS.Scheme2.ConnectionPoints.Object
{
  [UsedBySpring]
  public class OutputObjectConnectionPointFactory : AbstractRegistry<IOutputObjectConnectionPointFactoryExtension>,
                                                    IOutputObjectConnectionPointFactoryExtension 
  {
    public IOutputConnectionPoint Output(string name, object instance, MemberInfo member)
    {
      return
        ForEach<IOutputConnectionPoint>(
          delegate(IOutputObjectConnectionPointFactoryExtension factory) { return factory.Output(name, instance, member); });
    }
  }
}