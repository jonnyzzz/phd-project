using System;
using DSIS.Core.System;
using DSIS.Scheme.Objects.Systemx;

namespace DSIS.Function.Predefined
{
  public abstract class DoubleParametersSystemInfoFactoryBase<T> : SystemInfoFactoryBase
    where T : ISystemInfoParameters
  {
    protected DoubleParametersSystemInfoFactoryBase(int dim, SystemType type, string factoryName) : base(dim, type, factoryName)
    {
    }

    public sealed override Type OptionsObjectType
    {
      get { return typeof(T); }
    }

    public sealed override ISystemInfo Create(ISystemInfoParameters parameters)
    {
      return CreateInfo((T) parameters);
    }

    protected abstract ISystemInfo CreateInfo(T paramz);
  }
}