using DSIS.Spring;

namespace DSIS.Scheme2.XmlModel
{
  [UsedBySpring]
  public class OutputConnectionPointFactory : AbstractRegistry<IOutputConnectionPointExtension>, IOutputConnectionPointExtension
  {
    public IOutputConnectionPoint Create(ISchemeGraphBuildContext ctx, XsdConnectionsArcFrom arc)
    {
      return ForEach<IOutputConnectionPoint>(delegate(IOutputConnectionPointExtension instance)
                                               {
                                                 return instance.Create(ctx, arc);
                                               });
    }
  }
}