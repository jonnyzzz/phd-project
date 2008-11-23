using DSIS.Core.Ioc;

namespace DSIS.Scheme.Objects.Systemx
{
  public class ComputeInveriantMeasureComponentAttribute : ComponentImplementationAttribute
  {
  }

  public interface IComputeInveriantMeasureFactory : IOptionsHolder
  {
    IAction CreateComputeAction(object options);
  }
}