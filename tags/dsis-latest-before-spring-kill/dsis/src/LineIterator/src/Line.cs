using System.Collections.Generic;
using System.IO;
using DSIS.Core.System;

namespace DSIS.LineIterator
{
  public class Line<T> : ILine
    where T : ILinePoint<T>
  {
    private readonly double myEps;

    private List<LinkedList<LinePoint>> myPoints = new List<LinkedList<LinePoint>>();
    private LinePoint myLastPoint;
    private readonly int myDimension;

    public Line(double eps, T initial)
    {
      myEps = eps;
      myLastPoint = new LinePoint(initial);
      myPoints.Add(new LinkedList<LinePoint>());
      myPoints[myPoints.Count-1].AddFirst(myLastPoint);
      myDimension = initial.Dimension;
    }

    private Line(double eps, List<LinkedList<LinePoint>> points, LinePoint lastPoint)
    {
      myEps = eps;
      myPoints = points;
      myDimension = lastPoint.Point.Dimension;
    }

    public void AddPointToEnd(T point)
    {
      if (myLastPoint.Distance(point) >= myEps)
        myPoints[myPoints.Count-1].AddLast(myLastPoint = new LinePoint(point));
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
      var list = new List<LinkedList<LinePoint>>(Iterate(myEps, myPoints, function, space));
      myPoints = list;
      myLastPoint = list[list.Count-1].Last.Value;
    }

    public void Save(TextWriter tw)
    {
      foreach (var list in myPoints)
      {
        foreach (var point in list)
        {
          point.Point.Save(tw);
          tw.WriteLine();
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
          var pt = list.First.Value;
          foreach (var point in list)
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
      var list = new List<LinkedList<LinePoint>>();
      foreach (var points in myPoints)
      {
        list.Add(new LinkedList<LinePoint>(points));
      }
      return new Line<T>(myEps, list, myLastPoint);
    }

    public int Dimension
    {
      get { return myDimension; }
    }

    private static IEnumerable<LinkedList<LinePoint>> Iterate(double eps, IEnumerable<LinkedList<LinePoint>> list,
                                                              IFunction<double> function, ISystemSpace space)
    {
      foreach (var points in list)
      {
        foreach (var linePoints in Iterate(eps, points, function, space))
        {
          yield return linePoints;
        }
      }
    }
      
    private static IEnumerable<LinkedList<LinePoint>> Iterate(double eps, LinkedList<LinePoint> list,
                                                              IFunction<double> function, ISystemSpace space)
    {
      while (list.Count > 0)
      {
        var result = new LinkedList<LinePoint>();

        LinePoint prevBase = list.First.Value;
        list.RemoveFirst();
        LinePoint prevImage = prevBase.Compute(function);
        if (!prevImage.Point.IsContained(space))
          continue;

        result.AddFirst(prevImage);

        while (list.Count > 0)
        {
          LinePoint nextBase = list.First.Value;
          LinePoint nextImage = nextBase.Compute(function);

          if (!nextImage.Point.IsContained(space))
            break;

          if (prevImage.Distance(nextImage) < eps)
          {
            result.AddLast(prevImage = nextImage);
            prevBase = nextBase;
            list.RemoveFirst();
          }
          else
          {
            list.AddFirst(prevBase.Middle(nextBase));
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