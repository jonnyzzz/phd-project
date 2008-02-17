using System.Collections.Generic;
using System.IO;
using DSIS.Core.System;

namespace DSIS.LineIterator
{
  public class Line<T> : ILine
    where T : ILinePoint<T>
  {
    private readonly double myEps;

    private LinkedList<LinePoint> myPoints = new LinkedList<LinePoint>();
    private LinePoint myLastPoint;
    private readonly int myDimension;

    public Line(double eps, T initial)
    {
      myEps = eps;
      myLastPoint = new LinePoint(initial);
      myPoints.AddFirst(myLastPoint);
      myDimension = initial.Dimension;
    }

    private Line(double eps, LinkedList<LinePoint> points, LinePoint lastPoint)
    {
      myEps = eps;
      myPoints = points;
      myLastPoint = lastPoint;
      myDimension = lastPoint.Point.Dimension;
    }

    public void AddPointToEnd(T point)
    {
      if (myLastPoint.Distance(point) > myEps)
        myPoints.AddLast(myLastPoint = new LinePoint(point));
    }

    public int Count
    {
      get { return myPoints.Count; }
    }

    public void Iterate(ISystemInfo system)
    {
      IFunction<double> function = system.GetFunction(myEps);
      LinkedList<LinePoint> list = Iterate(myEps, myPoints, function, system.SystemSpace);
      myPoints = list;
      myLastPoint = list.Last.Value;
    }

    public void Save(TextWriter tw)
    {
      foreach (LinePoint point in myPoints)
      {
        point.Point.Save(tw);
        tw.WriteLine();
      }
    }

    public double Length
    {
      get
      {
        double length = 0;

        LinePoint pt = myPoints.First.Value;
        foreach (LinePoint point in myPoints)
        {
          length += pt.EuclidDistance(point);
          pt = point;
        }
        return length;        
      }
    }

    public ILine Clone()
    {
      //todo: Clone all objects?
      return new Line<T>(myEps, new LinkedList<LinePoint>(myPoints), myLastPoint);
    }

    public int Dimension
    {
      get { return myDimension; }
    }

    private static LinkedList<LinePoint> Iterate(double eps, LinkedList<LinePoint> list, IFunction<double> function, ISystemSpace space)
    {
      LinkedList<LinePoint> result = new LinkedList<LinePoint>();

      LinePoint prevBase = list.First.Value;
      list.RemoveFirst();
      LinePoint prevImage = prevBase.Compute(function);
      result.AddFirst(prevImage);

      while (list.Count > 0)
      {
        LinePoint nextBase = list.First.Value;
        LinePoint nextImage = nextBase.Compute(function);
        
        if (prevImage.Distance(nextImage) < eps || !nextImage.Point.IsContained(space))
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
      return result;
    }

    private class LinePoint
    {
      public readonly T Point;
      private LinePoint myImage = null;

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
        return string.Format("Pt: {0}, Image: {1}", Point, (object)myImage ?? "<none>");
      }
    }
  }
}