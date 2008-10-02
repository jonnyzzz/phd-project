using System;
using DSIS.Core.System;
using DSIS.Scheme.Objects.Systemx;

namespace DSIS.Function.Predefined
{
  public abstract class DoubleParametersSystemInfoFactoryBase<T> : DoubleParametersSystemInfoFactoryBase
    where T : ISystemInfoParameters
  {
    protected DoubleParametersSystemInfoFactoryBase(int dim, SystemType type, string factoryName, int paramsCount, CreateDelegate factory, DoubleArrayParser parser, SystemInfoFactory systemFactory) : base(dim, type, factoryName, paramsCount, factory, parser, systemFactory)
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