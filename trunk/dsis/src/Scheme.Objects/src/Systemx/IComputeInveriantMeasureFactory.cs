using DSIS.Core.Ioc;

namespace DSIS.Scheme.Objects.Systemx
{
  public class ComputeInveriantMeasureComponentAttribute : ComponentImplementationAttribute
  {
  }

  public interface IComputeInveriantMeasureFactory : IOptionsBasedFactory
  {
    IAction CreateComputeAction(object options);
  }
}