using DSIS.Core.Ioc;
using DSIS.Scheme.Ctx;

namespace DSIS.Scheme.Objects.Systemx
{
  public class ComputeInveriantMeasureComponentAttribute : ComponentImplementationAttribute
  {
  }

  public interface IComputeInveriantMeasureFactory : IOptionsBasedFactory
  {
    bool Compatible(Context ctx);
    IAction CreateComputeAction(object options);
  }
}