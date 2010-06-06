using System;
using DSIS.Core.System;
using DSIS.Core.System.Impl;
using DSIS.Function.Predefined.Ikeda;
using DSIS.Scheme.Objects.Systemx;
using EugenePetrenko.Shared.Core.Ioc.Api;

namespace DSIS.Function.Predefined.OsipenkoBio
{
  public class OsipenkoBio3Function : Function<double>, IFunction<double>
  {
    public OsipenkoBio3Function() : base(2)
    {
    }

    public void Evaluate()
    {
      double x = Input[0];
      double y = Input[1];

      double sum = (x+y);
      Output[1] = y * (3.5 - 1.75*sum)/(1+0.1*sum);
      Output[0] = y;
    }
  }

  [Serializable]
  public class OsipenkoBio3 : ISystemInfoParameters
  {
  }

  [SystemInfoComponent]
  public class OsipenkoBio3Predefined : PredefinedSystemFactory<OsipenkoBio3Factory>
  {
    public override ISystemSpace Space
    {
      get { return Factory.Space; }
    }

    protected override ISystemInfoParameters Parameters
    {
      get { return new OsipenkoBio3(); }
    }
  }

  [SystemInfoComponent]
  public class OsipenkoBio3Factory : DoubleParametersSystemInfoFactoryBase<OsipenkoBio3>
  {
    public OsipenkoBio3Factory() : base(2, SystemType.Discrete, "Osipenko's Bio3")
    {
    }

    [Autowire]
    protected ISystemSpaceFactory InfoFactory { get; private set; }

    public ISystemSpace Space
    {
      get { return InfoFactory.CreateSpace(2, new[] { 0.15, 0.15 }, new[] { 1.2, 1.2 }, new[] { 3L, 3 }); }
    }

    protected override ISystemInfo CreateInfo(OsipenkoBio3 paramz)
    {
      return new OsipenkoBio3FunctionSystemInfo(Space);
    }
  }


  public class OsipenkoBio3FunctionSystemInfo : DoubleDescreteSystemInfoBase, ISystemInfoPreferences
  {
    private readonly ISystemSpace mySpace;

    public OsipenkoBio3FunctionSystemInfo(ISystemSpace space)
      : base(2)
    {
      mySpace = space;
    }

    public override string PresentableName
    {
      get { return string.Format("Osipenko's Bio3"); }
    }

    protected override IFunction<double> GetFunctionInternal()
    {
      return new OsipenkoBio3Function();
    }

    public ISystemSpace PreferredSystemSpace
    {
      get { return mySpace; }
    }
  }

}