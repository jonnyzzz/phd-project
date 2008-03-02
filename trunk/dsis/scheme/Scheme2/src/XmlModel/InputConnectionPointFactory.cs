using DSIS.Spring;

namespace DSIS.Scheme2.XmlModel
{
  [UsedBySpring]
  public class InputConnectionPointFactory : AbstractRegistry<IInputConnectionPointExtension>, IInputConnectionPointExtension
  {
    public IInputConnectionPoint Create(ISchemeGraphBuildContext ctx, XsdConnectionsArcTO arc)
    {
      return ForEach<IInputConnectionPoint>(delegate(IInputConnectionPointExtension instance)
                                               {
                                                 return instance.Create(ctx, arc);
                                               });
    }
  }
}