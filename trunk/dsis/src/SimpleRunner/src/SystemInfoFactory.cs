using DSIS.Core.System;
using DSIS.Core.System.Impl;
using DSIS.Function.Predefined.Duffing;
using DSIS.Function.Predefined.FoodChain;
using DSIS.Function.Predefined.Henon;
using DSIS.Function.Predefined.HomoLinear;
using DSIS.Function.Predefined.HomoSquare;
using DSIS.Function.Predefined.Ikeda;
using DSIS.Function.Predefined.Logistics;
using DSIS.Function.Predefined.Lorentz;
using DSIS.Function.Predefined.VanDerPol;
using DSIS.Function.Solvers.RungeKutt;
using DSIS.Scheme;
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

    private static ISystemSpace IkedaCutSpace()
    {
      return new DefaultSystemSpace(2, new[] {-1.1, -1.5}, new[] {3.5, 1.8}, new[] {3, 3L});
    }

    public static IAction Henon1_4()
    {
      return new SystemInfoAction(new HenonFunctionSystemInfoDecorator(1.4), TenTen());
    }

    public static IAction HenonDelnitz(double a, double b)
    {
      return new SystemInfoAction(new HenonDellnitzFunctionSystemInfoDecorator(a,b), TwoTwo());
    }

    public static IAction Ikeda()
    {
      return new SystemInfoAction(new IkedaFunctionSystemInfoDecorator(), TenTen());
    }

    public static IAction IkedaCut()
    {
      return new SystemInfoAction(new RenameSystem(new IkedaFunctionSystemInfoDecorator(), "Ikeda cut"), IkedaCutSpace());
    }

    public static IAction DoubleLogistic()
    {
      var log_sp = new DefaultSystemSpace(2, new double[] {0, 0}, new double[] {1, 4}, new long[] {3, 3});
      return new SystemInfoAction(new Logistic2dSystemInfo(), log_sp);
    }

    public static IAction Logistic(double a)
    {
      var log_sp1 = new DefaultSystemSpace(1, new double[] { 0 }, new double[] { 1 }, new long[] { 3 });
      return new SystemInfoAction(new LogisticSystemInfo(a), log_sp1);
    }

    public static IAction FoodChainDanny()
    {
      var sp3 = new DefaultSystemSpace(3, 0.01.Fill(3), 35d.Fill(3), 2L.Fill(3));
      return new SystemInfoAction(new FoodChainSystemInfo(3.4001, 1, 4), sp3);
    }

    public static IAction DuffingRunge()
    {
      return new SystemInfoAction(new RungeKuttSolver(new DuffingSystemInfo(1, 1, 0.01), 100, 0.001), Space(2,5));
    }

    public static IAction VanDerPolRunge()
    {
      return new SystemInfoAction(new RungeKuttSolver(new VanDerPolSystemInfo(1.5), 100, 0.001), Space(2, 5));
    }

    public static IAction HomoLinearRunge()
    {
      return new SystemInfoAction(new HomoLinearSystemInfo(1.35), TenTen());
    }
    
    public static IAction HomoDoubleRunge()
    {
      return new SystemInfoAction(new HomoSquareSystemInfo(0.4), TenTen());
    }

    public static IAction LorentzRunge()
    {
      var info = new LorentzSystemInfo(8.0/3.0, 20, 10);
      return new SystemInfoAction(new RungeKuttSolver(info, 100, 0.001), Space(3, 40));
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