using System;

namespace DSIS.SimpleRunner
{
  public class GeneratedImageBuilderRunner : GeneratedAbstactImageBuilderRunner    
  {
    private readonly Type myBuider;
    private readonly object[] myArgs;

    public GeneratedImageBuilderRunner(Type buider, params object[] args)
    {
      myBuider = buider;
      myArgs = args;
    }

    public override AbstractImageBuilder<T, Q> CreateBuilder<T, Q>()
    {
      Type concrete = myBuider.MakeGenericType(typeof (T), typeof (Q));
      return (AbstractImageBuilder<T, Q>) Activator.CreateInstance(concrete, myArgs);
    }
  }
}