using System;
using System.Collections.Generic;
using DSIS.Core.System;
using DSIS.Core.System.Impl;
using DSIS.Function.Predefined.Henon;
using DSIS.Graph.Entropy.Impl.Loop.Strange;
using DSIS.Graph.Entropy.Impl.Loop.Weight;
using DSIS.Scheme;
using DSIS.Scheme.Actions;
using DSIS.Scheme.Ctx;
using DSIS.Scheme.Exec;
using DSIS.Scheme.Impl;
using DSIS.Scheme.Impl.Actions.Entropy;
using DSIS.Scheme.Impl.Tests;
using NUnit.Framework;

namespace DSIS.Graph.Entropy.Tests.StrangeComparison
{
  [TestFixture]
  public class StrangeComparison : SimbolicImageBuildTestBase
  {
    private readonly ISystemSpace mySystemSpace;
    private readonly ISystemInfo mySystemInfo;

    public StrangeComparison()
    {
      mySystemSpace = new DefaultSystemSpace(2, new double[] { -10, -10 }, new double[] { 10, 10 }, new long[] { 3, 3 });
      mySystemInfo = new HenonFunctionSystemInfoDecorator(1.4);
    }

    protected override ISystemInfo SystemInfo
    {
      get { return mySystemInfo; }
    }

    protected override ISystemSpace SystemSpace
    {
      get { return mySystemSpace; }
    }

    [Test]
    public void Test_3xSteps()
    {        
      DoTest(3, Null);
    }
    
    [Test]
    public void Test_4xSteps()
    {        
      DoTest(4, Null);
    }

    [Test]
    public void Test_5xSteps()
    {        
      DoTest(5, Null);
    }

    [Test]
    public void Test_6xSteps()
    {        
      DoTest(6, Null);
    }

    [Test]
    public void Test_7xSteps()
    {        
      DoTest(7, Null);
    }

    [Test]
    public void Test_8xSteps()
    {        
      DoTest(8, Null);
    }

    [Test]
    public void Test_9xSteps()
    {        
      DoTest(9, Null);
    }

    [Test]
    public void Test_10xSteps()
    {        
      DoTest(10, Null);
    }

    private static void Null(double eigen, double eigenPer, double first, double smart)
    {                    
    }

    protected delegate void AssertMe(double eigen, double eigenPer, double first, double smart);

    protected void DoTest(int steps, AssertMe asserter)
    {
      double? eigenE = null;
      double? eigenPerE = null;
      double? firstE = null;
      double? smartE = null;

      base.DoTest(steps, delegate(ActionBuilderAdapter ad, IAction leaf)
                           {
                             IAction eigen = new ChainAction( 
                               new EigenEntropyAction(), 
                               new GetEntropyAction(delegate(double entropy) {eigenE = entropy;})
                               );

                             IAction eigenPer = new ChainAction( 
                               new EigenPerComoponentAction(), 
                               new GetEntropyAction(delegate(double entropy) {eigenPerE = entropy;})
                               );

                             IAction first = new ChainAction(
                                  Strange(StrangeEvaluatorStrategy.FIRST),
                                  new GetEntropyAction(delegate(double e) { firstE = e; })
                                  );

                             IAction smart = 
                               new ChainAction(
                                 Strange(StrangeEvaluatorStrategy.SMART),
                                 new GetEntropyAction(delegate(double e) { smartE = e; })
                               );
                             ad.AddEdge(leaf, first);
                             ad.AddEdge(leaf, smart);

                             ad.AddEdge(leaf, eigen);
                             ad.AddEdge(leaf, eigenPer);
                             
                           });

      Assert.IsNotNull(eigenE);
      Assert.IsNotNull(eigenPerE);
      Assert.IsNotNull(firstE);
      Assert.IsNotNull(smartE);

      Assert.Greater(eigenE.Value, 0);
      Assert.Greater(eigenPerE.Value, 0);
      Assert.Greater(firstE.Value, 0);
      Assert.Greater(smartE.Value, 0);

      Assert.Less(firstE.Value, smartE.Value);
      Assert.Less(smartE.Value, eigenE.Value);
      Assert.Less(smartE.Value, eigenPerE.Value);

      Console.Out.WriteLine("eigenE = {0}", eigenE);
      Console.Out.WriteLine("eigenPerE = {0}", eigenPerE);
      Console.Out.WriteLine("firstE = {0}", firstE);
      Console.Out.WriteLine("smartE = {0}", smartE);

      asserter(eigenE.Value, eigenPerE.Value, firstE.Value, smartE.Value);
    }

    private static IAction Strange(StrangeEvaluatorStrategy strategy)
    {
      var ps = new StrangeEntropyEvaluatorParams(StrangeEvaluatorType.WeightSearch_1, strategy, EntropyLoopWeights.ONE);
      return new AgregateAction(delegate(IActionGraphPartBuilder bld)
                                               {
                                                 var set = new SetStrangeEntropyParamsAction(ps);
                                                 bld.AddEdge(bld.Start, set);
                                                 IAction main = new StrangeEntropyAction();
                                                 IAction mainProxy = new ProxyAction();
                                                 bld.AddEdge(bld.Start, mainProxy);
                                                 bld.AddEdge(mainProxy, main);
                                                 bld.AddEdge(set, main);
                                                 bld.AddEdge(main, bld.End);
                                               });
    }

    public class GetEntropyAction : ActionBase
    {
      public delegate void CallbackValue(double entropy);

      private readonly CallbackValue myCallback;

      public GetEntropyAction(CallbackValue callback)
      {
        myCallback = callback;
      }

      public override ICollection<ContextMissmatch> Compatible(Context ctx)
      {
        return CheckContext(ctx, Create(Keys.GraphEntropyKey));
      }

      protected override void Apply(Context ctx, Context result)
      {
        double value = Keys.GraphEntropyKey.Get(ctx).GetEntropy();
        myCallback(value);
      }
    }
  }  
}