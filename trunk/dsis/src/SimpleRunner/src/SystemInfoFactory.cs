using DSIS.Core.System;
using DSIS.Core.System.Impl;
using DSIS.Function.Predefined.Ampilova;
using DSIS.Function.Predefined.Brusselator;
using DSIS.Function.Predefined.Chua;
using DSIS.Function.Predefined.Delayed;
using DSIS.Function.Predefined.Duffing;
using DSIS.Function.Predefined.FoodChain;
using DSIS.Function.Predefined.Henon;
using DSIS.Function.Predefined.HomoLinear;
using DSIS.Function.Predefined.HomoSquare;
using DSIS.Function.Predefined.Ikeda;
using DSIS.Function.Predefined.LeonovP50;
using DSIS.Function.Predefined.Linear;
using DSIS.Function.Predefined.Logistics;
using DSIS.Function.Predefined.Lorentz;
using DSIS.Function.Predefined.Osipenko2011;
using DSIS.Function.Predefined.OsipenkoBio;
using DSIS.Function.Predefined.Rossel;
using DSIS.Function.Predefined.VanDerPol;
using DSIS.Function.Solvers.RungeKutt;
using DSIS.Scheme.Impl.Actions;
using DSIS.Utils;

namespace DSIS.SimpleRunner
{
  public static class SystemInfoFactory
  {
    private static ISystemSpace TenTen()
    {
      return new DefaultSystemSpace(2, new double[] {-10, -10}, new double[] {10, 10}, new long[] {3, 3});
    }
    
    private static ISystemSpace TwoTwo()
    {
      return new DefaultSystemSpace(2, new double[] {-2, -2}, new double[] {2, 2}, new long[] {3, 3});
    }
    
    private static ISystemSpace Space(int dim, double v)
    {
      return new DefaultSystemSpace(dim, (-v).Fill(dim), v.Fill(dim), 3L.Fill(dim));
    }

    private static ISystemSpace PSpace(int dim, double v)
    {
      return new DefaultSystemSpace(dim, (.0).Fill(dim), v.Fill(dim), 3L.Fill(dim));
    }

    private static ISystemSpace IkedaCutSpace()
    {
      return new DefaultSystemSpace(2, new[] {-1.1, -1.5}, new[] {3.5, 1.8}, new[] {3, 3L});
    }

    public static SystemInfoAction Henon1_4()
    {
      return new SystemInfoAction(new HenonFunctionSystemInfoDecorator(1.4), TenTen());
    }

    public static SystemInfoAction Henon1_4_InfSpace()
    {
      return new SystemInfoAction(new HenonFunctionSystemInfoDecorator(1.4), Space(2, 10000));
    }

    public static SystemInfoAction HenonDelnitz(double a, double b)
    {
      return new SystemInfoAction(new HenonDellnitzFunctionSystemInfoDecorator(a,b), TwoTwo());
    }

    public static SystemInfoAction Ikeda()
    {
      return new SystemInfoAction(new IkedaFunctionSystemInfoDecorator(), TenTen());
    }

    public static SystemInfoAction IkedaCut()
    {
      return new SystemInfoAction(new IkedaFunctionSystemInfoDecorator().RenameSystemInfo("Ikeda cut"), IkedaCutSpace());
    }

    public static SystemInfoAction DoubleLogistic()
    {
      var log_sp = new DefaultSystemSpace(2, new double[] {0, 0}, new double[] {1, 4}, new long[] {3, 3});
      return new SystemInfoAction(new Logistic2dSystemInfo(), log_sp);
    }

    public static SystemInfoAction Logistic(double a)
    {
      var log_sp1 = new DefaultSystemSpace(1, new double[] { 0 }, new double[] { 1 }, new long[] { 3 });
      return new SystemInfoAction(new LogisticSystemInfo(a), log_sp1);
    }

    public static SystemInfoAction FoodChainDanny()
    {
      var sp3 = new DefaultSystemSpace(3, 0.01.Fill(3), 35d.Fill(3), 2L.Fill(3));
      return new SystemInfoAction(new FoodChainSystemInfo(3.4001, 1, 4), sp3);
    }

    public static SystemInfoAction OsipenkoBio3()
    {
      var sp = new DefaultSystemSpace(2, 0.15.Fill(2), 1.2.Fill(2), 3L.Fill(2));
      return new SystemInfoAction(new OsipenkoBio3FunctionSystemInfo(sp), sp);
    }

    public static SystemInfoAction Delayed(double a)
    {
      return new SystemInfoAction((new DelayedFunctionSystemInfo(a)), PSpace(2, 3));
    }

    public static SystemInfoAction DuffingRunge()
    {
      return new SystemInfoAction(new RungeKuttSolver(new DuffingSystemInfo(1, 1, 0.01), 100, 0.001), Space(2,5));
    }

    public static SystemInfoAction Duffing2x2Runge()
    {
      return new SystemInfoAction(new RungeKuttSolver(new DuffingSystemInfo(1, 1, 0.01).RenameSystemInfoTemplate("{0}(-2,2)"), 100, 0.001), Space(2,2));
    }

    public static SystemInfoAction Duffing1_5x1_5Runge()
    {
      return new SystemInfoAction(new RungeKuttSolver(new DuffingSystemInfo(1, 1, 0.01).RenameSystemInfoTemplate("{0}(-1.5,1.5)"), 100, 0.001), Space(2,1.5));
    }

    public static SystemInfoAction Duffing1_4x1_4Runge()
    {
      return new SystemInfoAction(new RungeKuttSolver(new DuffingSystemInfo(1, 1, 0.01).RenameSystemInfoTemplate("{0}(-1.4,1.4)"), 100, 0.001), Space(2,1.4));
    }

    public static SystemInfoAction Duffing1_3x1_3Runge()
    {
      return new SystemInfoAction(new RungeKuttSolver(new DuffingSystemInfo(1, 1, 0.01).RenameSystemInfoTemplate("{0}(-1.3,1.3)"), 100, 0.001), Space(2,1.3));
    }

    public static SystemInfoAction Duffing1_2x1_2Runge()
    {
      return new SystemInfoAction(new RungeKuttSolver(new DuffingSystemInfo(1, 1, 0.01).RenameSystemInfoTemplate("{0}(-1.2,1.2)"), 100, 0.001), Space(2,1.2));
    }

    public static SystemInfoAction DuffingRunge(double space, int steps, double dt)
    {
      return new SystemInfoAction(new RungeKuttSolver(new DuffingSystemInfo(1, 1, 0.01).RenameSystemInfoTemplate("{0}(-" + space + "," + space + ")"), steps, dt), Space(2,space));
    }

    public static SystemInfoAction VanDerPolRunge()
    {
      return new SystemInfoAction(new RungeKuttSolver(new VanDerPolSystemInfo(1.5), 100, 0.001), Space(2, 5));
    }

    public static SystemInfoAction HomoLinearRunge()
    {
      return new SystemInfoAction(new HomoLinearSystemInfo(1.35), TenTen());
    }

    public static SystemInfoAction HomoDoubleRunge()
    {
      return new SystemInfoAction(new HomoSquareSystemInfo(0.4), TenTen());
    }

    public static SystemInfoAction LorentzRunge()
    {
      var info = new LorenzSystemInfo(8.0/3.0, 20, 10);
      return new SystemInfoAction(new RungeKuttSolver(info, 100, 0.001), Space(3, 40));
    }

    public static SystemInfoAction RosslerRunge()
    {
      var info = new RosslerSystemInfo(0.2, 0.2, 5.7);
      return new SystemInfoAction(new RungeKuttSolver(info, 100, 0.01), Space(3, 30));
    }

    public static SystemInfoAction BrusselatorRunge()
    {
      var info = new BrusselatorSystemInfo(new BrusselatorOptions{P1 = 0.5, P2 = 0});
      return new SystemInfoAction(new RungeKuttSolver(info, 50, 0.001), Space(2, 10));
    }

    public static SystemInfoAction ChuaRunge()
    {
      var info = new ChuaSystemInfo(new ChuaOptions{P1 = 9.85, P2 = 14.3, P3=-0.14, P4=0.28});
      return new SystemInfoAction(new RungeKuttSolver(info, 50, 0.001), Space(3, 30));
    }

    public static SystemInfoAction ChuaRunge2()
    {
      var info = new ChuaSystemInfo2(new ChuaOptions2{A = 18, B = 33, M0 = -0.2, M1 = 0.01});
      var space = new DefaultSystemSpace(3, new[]{-12, -2.5, -20}, new[]{12, 2.5, 20}, 2L.Fill(3));
      return new SystemInfoAction(new RungeKuttSolver(info, 100, 0.0005), space);
    }

    public static SystemInfoAction AlphaX(double d)
    {
      return new SystemInfoAction(new Linear1DSystemInfo(d, 0), Space(1, 1));
    }

    public static SystemInfoAction Ref9_Inf(double mu) //.5
    {
      return new SystemInfoAction(new Ref9(mu), Space(3, 10000));
    }

    public static SystemInfoAction Ref9(double mu) //.5
    {
      return new SystemInfoAction(new Ref9(mu), Space(3, 3));
    }

    public static SystemInfoAction LeonovSystem(double step, int times)
    {
      return new SystemInfoAction(new RungeKuttSolver(new LeonovP50_1System(), times, step), Space(2, 0.1));
    }

    public static SystemInfoAction LeonovSystem(double step, int times, double size)
    {
      return new SystemInfoAction(new RungeKuttSolver(new LeonovP50_1System(), times, step).RenameSystemInfoTemplate("{0}-" + size), Space(2, size));
    }

    public static SystemInfoAction LeonovSystemEx(double step, int times)
    {
      return new SystemInfoAction(
        new RungeKuttSolver(new LeonovP50_1System(), times, step).RenameSystemInfoTemplate("{0}-[-0.15,0.15]x[-0.2, 0.15]"), 
        new DefaultSystemSpace(2, new[]{-0.15, -0.2}, new[]{0.15, 0.15}, 3L.Fill(2))
        );
    }

    public static SystemInfoAction LeonovSystemEx(double step, int times, LeonovP50_2Parameters d)
    {
      return new SystemInfoAction(
        new RungeKuttSolver(new LeonovP50_2System(d), times, step).RenameSystemInfoTemplate("{0}[-0.15][-0.2,0.15]"), 
        new DefaultSystemSpace(2, new[]{-0.15, -0.2}, new[]{0.15, 0.15}, 3L.Fill(2))
        );
    }

    public static SystemInfoAction Osipenko_2011_1()
    {
      return new SystemInfoAction(
        new Osipenko2011_1_FunctionSystemInfo(new Osipenko2011_1_Parameters()),
        new Osipenko2011_1_Predefined().Space
        );
    }

    /*
     * 
     * var duffingSp = new DefaultSystemSpace(2, new[] {-4.3, -3}, new[] {4.3, 3}, new long[] {3, 3});

      var spIkedaCutted =
        new DefaultSystemSpace(2, new[] {-1.1, -1.5}, new[] {3.5, 1.8}, new[] {3, 3L});
      var sp =
        new DefaultSystemSpace(2, new double[] {-10, -10}, new double[] {10, 10}, new long[] {3, 3});
      var spD =
        new DefaultSystemSpace(2, new double[] {-2, -2}, new double[] {2, 2}, new long[] {2, 2});
      var sp3 =
        new DefaultSystemSpace(3, new double[] {0, 0, 0}, new double[] {200, 200, 200}, new long[] {2, 2, 2});

      var log_sp = new DefaultSystemSpace(2, new double[] {0, 0}, new double[] {1, 4}, new long[] {3, 3});
      var log_sp2 = new DefaultSystemSpace(2, new double[] {0, 3}, new[] {1, 3.7}, new long[] {3, 3});

      var log_sp1 = new DefaultSystemSpace(1, new double[] {0}, new double[] {1}, new long[] {3});


      IAction systemHenon = new SystemInfoAction(new HenonFunctionSystemInfoDecorator(1.4), sp);
      IAction systemHenonD = new SystemInfoAction(new HenonDellnitzFunctionSystemInfoDecorator(1.2, 0.2), spD);
      IAction systemHenonD_272 = new SystemInfoAction(new HenonDellnitzFunctionSystemInfoDecorator(1.272, 0.2), spD);
      IAction systemIked = new SystemInfoAction(new IkedaFunctionSystemInfoDecorator(), sp);
      IAction systemIkedaCut =
        new SystemInfoAction(new RenameSystem(new IkedaFunctionSystemInfoDecorator(), "Ikeda Cut"), spIkedaCutted);
      IAction systenLogistic2 = new SystemInfoAction(new Logistic2dSystemInfo(), log_sp);
      IAction systenLogistic2_x = new SystemInfoAction(new Logistic2dSystemInfo(), log_sp2);
      IAction systenLogistic3569 = new SystemInfoAction(new LogisticSystemInfo(3.569), log_sp1);
      IAction systenLogistic4 = new SystemInfoAction(new LogisticSystemInfo(4), log_sp1);
      IAction systenHomoLinear = new SystemInfoAction(new HomoLinearSystemInfo(1.35), sp);
      IAction systenHomoSquare = new SystemInfoAction(new HomoSquareSystemInfo(0.4), sp);
      IAction systemTorsten = new SystemInfoAction(new FoodChainSystemInfo(), sp3);

      IAction duffing = new SystemInfoAction(new RungeKuttSolver(new DuffingSystemInfo(1, 1, 0.01), 3, 0.01),
                                             duffingSp);
      IAction vanderpol = new SystemInfoAction(new RungeKuttSolver(new VanDerPolSystemInfo(1), 15, 0.1),
                                               duffingSp);

     * 
     * 
     */
  }
}