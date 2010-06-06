using DSIS.Scheme.Ctx;
using EugenePetrenko.Shared.Core.Ioc.Api;
using JetBrains.Annotations;

namespace DSIS.Scheme.Objects.Systemx
{
  [MeansImplicitUse]
  //TODO: Why not Base
  public class ComputeInveriantMeasureComponentAttribute : ComponentImplementationAttribute
  {
  }

  public interface IComputeInveriantMeasureFactory : IOptionsBasedFactory
  {
    bool Compatible(Context ctx);
    IAction CreateComputeAction(object options);
  }
}