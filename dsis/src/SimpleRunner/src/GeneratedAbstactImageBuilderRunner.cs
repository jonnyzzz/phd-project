using DSIS.Core.Util;
using DSIS.IntegerCoordinates;
using DSIS.IntegerCoordinates.Generated;

namespace DSIS.SimpleRunner
{
  public abstract class GeneratedAbstactImageBuilderRunner : IIntegerCoordinateCallback
  {
    public abstract AbstractImageBuilder<T, Q> CreateBuilder<T, Q>()
      where T : IIntegerCoordinateSystem<Q>
      where Q : IIntegerCoordinate;
    
    public void Do<T, Q>(CreateSystem<T> createSystem) where T : IIntegerCoordinateSystem<Q>
      where Q : IIntegerCoordinate
    {
      AbstractImageBuilder<T, Q> builder = CreateBuilder<T, Q>();
      builder.CreateSystem = createSystem;

      builder.ComputeAllMethods(NullProgressInfo.INSTANCE);

      ComputationFinished(builder);
    }    

    protected virtual void ComputationFinished<T,Q>(AbstractImageBuilder<T,Q> builder)
      where T : IIntegerCoordinateSystem<Q>
      where Q : IIntegerCoordinate
    {      
    }

    protected void Run(int dim)
    {
      GeneratedIntegerCoordinateSystemManager.Instance.CreateSystem(dim).WithIntegerCoordinateSystem(this);
    }
  }
}