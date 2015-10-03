using System;
using System.Collections.Generic;
using System.Globalization;
using System.Text;
using DSIS.Graph;
using DSIS.IntegerCoordinates;
using DSIS.Scheme;
using DSIS.Scheme.Ctx;
using DSIS.Scheme.Exec;
using DSIS.Scheme.Impl;
using DSIS.TrajectoryBuilder;
using NUnit.Framework;

namespace DSIS.Tests.BlackBox
{
  public abstract class InvariantSetTestBase : SimbolicImageBuildTestBase2
  {
    protected void DoTest(int steps, int startPoint, int endPoint, double[] error, params double[][] testPoints)
    {
      SimpleTrajectoryBuilder bld = new SimpleTrajectoryBuilder(mySystemSpace, mySystemInfo, 1 << 40);
      DoTest(steps,
             delegate(ActionBuilderAdapter ad, IAction leaf)
               {
                 ad.AddEdge(leaf,
                            new RememberGraphAction(startPoint, endPoint, bld, new List<double[]>(testPoints), error));
               });
    }

    private class RememberGraphAction : IntegerCoordinateSystemActionBase2
    {
      private readonly int myStartPoint;
      private readonly int myEndPoint;
      private readonly SimpleTrajectoryBuilder myBuilder;
      private readonly List<double[]> myTestPoints;
      private readonly double[] myError;

      public RememberGraphAction(int startPoint, int endPoint, SimpleTrajectoryBuilder builder,
                                 List<double[]> testPoints, double[] error)
      {
        myStartPoint = startPoint;
        myError = error;
        myTestPoints = testPoints;
        myEndPoint = endPoint;
        myBuilder = builder;
      }


      protected override ICollection<ContextMissmatchCheck> Check<T, Q>(T system, Context ctx)
      {
        return ColBase(base.Check<T, Q>(system, ctx), Create(Keys.GraphComponents<Q>()), Create(Keys.Graph<Q>()));
      }

      protected override void Apply<T, Q>(T system, Context input, Context output)
      {
        IGraph<Q> graph = Keys.Graph<Q>().Get(input);

        Assert.AreSame(graph.CoordinateSystem, system);

        foreach (double[] point in myTestPoints)
        {
          myBuilder.Point = point;
          for (int i = 0; i < myStartPoint; i++)
          {
            myBuilder.Next();
          }

          IRadiusProcessor<Q> processor = system.ProcessorFactory.CreateRadiusProcessor();
          double[] error = new double[system.Dimension];
          for (int i = 0; i < system.Dimension; i++)
          {
            error[i] = myError[i]*system.CellSize[i];
          }
          for (int i = myStartPoint; i < myEndPoint; i++)
          {
            bool found = false;
            foreach (Q pt in processor.ConnectCellToRadius(myBuilder.Point, error))
            {
              if (graph.Contains(pt))
              {
                found = true;
                break;
              }
            }
            if (!found)
            {
              StringBuilder sb = new StringBuilder();
              sb.Append("{");
              foreach (double v in myBuilder.Point)
              {
                sb.AppendFormat("{0}, ", v);
              }
              sb.Append("}").AppendLine();

              foreach (INode<Q> node in graph.Nodes)
              {                
                for(int n = 0; n < system.Dimension; n++)
                {
                  sb.AppendFormat("{0}, ", system.ToExternal(node.Coordinate.GetCoordinate(n), n));
                }
                sb.AppendLine();                                
              }

              Assert.IsTrue(found, "Point {0} was not found in the resulting symbolic image on iteration {1}", sb, i);
            }
            myBuilder.Next();
          }
        }
      }
    }

    protected static List<double[]> Parse(string points) {
      List<double[]> result = new List<double[]>();
      foreach (string line in points.Split('\n'))
      {
        if (line.Trim().Length == 0)
          continue;
        string[] data = line.Trim().Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
        double[] ddata = new double[data.Length];
        for(int i=0; i<data.Length; i++)
        {
          string str = data[i].Trim();          
          ddata[i] = double.Parse(str.Trim(), CultureInfo.InvariantCulture);
          result.Add(ddata);
        }
      }
      return result;
      
    }
  }
}