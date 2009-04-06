using System;
using System.Collections.Generic;
using System.IO;
using DSIS.Core.System;
using DSIS.Utils;

namespace DSIS.LineIterator
{
  public class Line<T> : ILine
    where T : ILinePoint<T>
  {
    private readonly double[] myEps;
    private readonly double myDistanceEps;

    private List<IPointList<LinePoint>> myPoints = new List<IPointList<LinePoint>>();
    private LinePoint myLastPoint;
    private readonly int myDimension;

    private Line(double[] eps)
    {
      myEps = eps;
      myDistanceEps = myEps.FoldLeft(0.0, Math.Max);
    }

    public Line(double[] eps, T initial) : this(eps)
    {
      myLastPoint = new LinePoint(initial);
      var list = CreatePointList<LinePoint>();
      list.AddLast(myLastPoint);
      myPoints.Add(list);
      myDimension = initial.Dimension;
    }

    private Line(double[] eps, List<IPointList<LinePoint>> points, LinePoint lastPoint) :
      this(eps)
    {
      myDimension = lastPoint.Point.Dimension;
      myPoints = points;
    }

    public void AddPointToEnd(T point)
    {
      if (myLastPoint.Distance(point) >= myDistanceEps)
        myPoints[myPoints.Count - 1].AddLast(myLastPoint = new LinePoint(point));
    }

    public int Count
    {
      get
      {
        var cnt = 0;
        foreach (var list in myPoints)
        {
          cnt += list.Count;
        }
        return cnt;
      }
    }

    public void Iterate(ISystemSpace space, ISystemInfo system)
    {
      var function = system.GetFunction(myEps);
      var list = new List<IPointList<LinePoint>>(Iterate(myDistanceEps, myPoints, function, space));
      myPoints = list;
      myLastPoint = list.Count > 0 ? list[list.Count - 1].Last : null;
    }

    public void Save(TextWriter tw)
    {
      foreach (var list in myPoints)
      {
        foreach (var point in list.Values)
        {
          point.Point.Save(tw);
          tw.WriteLine();
        }
      }
    }

    public void Visit(Action<double[]> tw)
    {
      foreach (var list in myPoints)
      {
        foreach (var point in list.Values)
        {
          point.Point.Visit(tw);
        }
      }
    }

    public double Length
    {
      get
      {
        double length = 0;
        foreach (var list in myPoints)
        {
          var pt = list.First;
          foreach (var point in list.Values)
          {
            length += pt.EuclidDistance(point);
            pt = point;
          }
        }
        return length;
      }
    }

    public ILine Clone()
    {
      //todo: Clone all objects?
      var list = new List<IPointList<LinePoint>>();
      foreach (var points in myPoints)
      {
        var item = CreatePointList<LinePoint>();
        item.AddAll(points);
        list.Add(item);
      }
      return new Line<T>(myEps, list, myLastPoint);
    }

    protected IPointList<TT> CreatePointList<TT>()
    {
      return new PointList<TT>();
    }

    public int Dimension
    {
      get { return myDimension; }
    }

    private IEnumerable<IPointList<LinePoint>> Iterate(double dispanceEps,
                                                       IEnumerable<IPointList<LinePoint>> list,
                                                       IFunction<double> function,
                                                       ISystemSpace space)
    {
      foreach (var points in list)
      {
        foreach (var linePoints in Iterate(dispanceEps, points.StackEnumerator(), function, space))
        {
          yield return linePoints;
        }
      }
    }

    private IEnumerable<IPointList<LinePoint>> Iterate(double distanceEps,
                                                       IStackEnumerator<LinePoint> list,
                                                       IFunction<double> function,
                                                       ISystemSpace space)
    {
      while (!list.IsEmpty)
      {
        var result = CreatePointList<LinePoint>();

        var prevBase = list.Peek();
        list.Pop();
        var prevImage = prevBase.Compute(function);
        if (!prevImage.Point.IsContained(space))
          continue;

        result.AddLast(prevImage);

        while (!list.IsEmpty)
        {
          var nextBase = list.Peek();
          var nextImage = nextBase.Compute(function);

          if (!nextImage.Point.IsContained(space))
            break;

          if (prevImage.Distance(nextImage) < distanceEps)
          {
            result.AddLast(prevImage = nextImage);
            prevBase = nextBase;
            list.Pop();
          }
          else
          {
            list.Push(prevBase.Middle(nextBase));
          }
        }

        if (result.Count >= 2)
          yield return result;
      }
    }

    private class LinePoint
    {
      public readonly T Point;
      private LinePoint myImage;

      public LinePoint(T point)
      {
        Point = point;
      }

      public double Distance(LinePoint pt)
      {
        return pt.Point.Distance(Point);
      }

      public double EuclidDistance(LinePoint pt)
      {
        return pt.Point.EuclidDistance(Point);
      }

      public double Distance(T pt)
      {
        return pt.Distance(Point);
      }

      public LinePoint Middle(LinePoint pt)
      {
        return new LinePoint(Point.Middle(pt.Point));
      }

      public LinePoint Compute(IFunction<double> function)
      {
        if (myImage == null)
        {
          myImage = new LinePoint(Point.Compute(function));
        }
        return myImage;
      }

      public override string ToString()
      {
        return string.Format("Pt: {0}, Image: {1}", Point, (object) myImage ?? "<none>");
      }
    }
  }
}