/*
 * Created by: Eugene Petrenko
 * Created: 5 ÿםגאנÿ 2007 ד.
 */

using System;
using System.Text;
using DSIS.Utils;

namespace DSIS.Core.System.Impl
{
  [Serializable]
  public class SystemSpaceData
  {
    public int Dimension { get; set; }
    public double[] AreaLeftPoint { get; set; }
    public double[] AreaRightPoint { get; set; }
    public long[] Subdivision { get; set; }
  }

  //TODO: [Serializable]
  public class DefaultSystemSpace : ISystemSpace, IEquatable<DefaultSystemSpace>
  {
    private readonly int myDimension;
    private readonly double[] myAreaLeftPoint;
    private readonly double[] myAreaRightPoint;
    private readonly long[] myInitialSubdivision;

    public DefaultSystemSpace(int dimension, double[] areaLeftPoint, double[] areaRightPoint, long[] initialSubdivision)
    {
      myDimension = dimension;
      myAreaLeftPoint = areaLeftPoint;
      myAreaRightPoint = areaRightPoint;
      myInitialSubdivision = initialSubdivision;

      if (myAreaLeftPoint.Length != myDimension)
        throw new ArgumentException("wrong size", "areaLeftPoint");
      if (myAreaRightPoint.Length != myDimension)
        throw new ArgumentException("wrong size", "areaRightPoint");
      if (initialSubdivision.Length != myDimension)
        throw new ArgumentException("wrong size", "initialSubdivision");
    }

    public SystemSpaceData ToSystemSpaceData
    {
      get
      {
        return new SystemSpaceData
                 {
                   Dimension = Dimension,
                   AreaLeftPoint = AreaLeftPoint,
                   AreaRightPoint = AreaRightPoint,
                   Subdivision = InitialSubdivision
                 };
      }
    }

    public double[] AreaLeftPoint
    {
      get { return myAreaLeftPoint; }
    }

    public double[] AreaRightPoint
    {
      get { return myAreaRightPoint; }
    }

    public virtual bool Contains(double[] point)
    {
      for (int i = 0; i < Dimension; i++)
      {
        if (AreaLeftPoint[i] > point[i])
          return false;
        if (AreaRightPoint[i] < point[i])
          return false;
      }
      return true;
    }

    public virtual bool ContainsRect(double[] left, double[] right)
    {
      for (int i = 0; i < Dimension; i++)
      {
        if (!
            (((left[i] <= myAreaLeftPoint[i]) && (myAreaLeftPoint[i] <= right[i])) ||
             ((left[i] <= myAreaRightPoint[i]) && (myAreaRightPoint[i] <= right[i])) ||
             ((myAreaLeftPoint[i] <= left[i]) && (right[i] <= myAreaRightPoint[i])))
          ) return false;
      }
      return true;
    }

    public bool ContainedRect(double[] left, double[] right)
    {
      for (int i = 0; i < Dimension; i++)
      {
        if (!
             ((myAreaLeftPoint[i] <= left[i]) && (right[i] <= myAreaRightPoint[i]))
          ) return false;
      }
      return true;
    }

    public int Dimension
    {
      get { return myDimension; }
    }

    public long[] InitialSubdivision
    {
      get { return myInitialSubdivision; }
    }

    public override string ToString()
    {
      var sb = new StringBuilder();
      sb.AppendFormat("Dim={0}, L=({1}), R=({2}), Grid=({3})", 
        myDimension,
        myAreaLeftPoint.JoinString(", "),
        myAreaRightPoint.JoinString(", "),
        myInitialSubdivision.JoinString(", "));      
      return sb.ToString();
    }

    public bool Equals(DefaultSystemSpace other)
    {
      if (ReferenceEquals(null, other)) return false;
      if (ReferenceEquals(this, other)) return true;
      return 
        other.myDimension == myDimension 
        && Equals(other.myAreaLeftPoint, myAreaLeftPoint) 
        && Equals(other.myAreaRightPoint, myAreaRightPoint) 
        && Equals(other.myInitialSubdivision, myInitialSubdivision);
    }

    private static bool Equals<T>(T[] t1, T[] t2)
    {
      if (t1.Length != t2.Length)
        return false;

      for(int i=0; i<t1.Length; i++)
      {
        if (!Equals(t1[i],t2[i]))
          return false;
      }
      return true;
    }

    public override bool Equals(object other)
    {
      if (ReferenceEquals(null, other)) return false;
      if (ReferenceEquals(this, other)) return true;
      if (other.GetType() != typeof (DefaultSystemSpace)) return false;
      return Equals((DefaultSystemSpace) other);
    }

    public override int GetHashCode()
    {
      return myDimension 
        + myInitialSubdivision.FoldLeft(0, (x, y) => (int) (y*397 ^ x)) 
        + myAreaLeftPoint.FoldLeft(0, (d,y)=>y+d.GetHashCode())
        + myAreaRightPoint.FoldLeft(0, (d,y)=>y+d.GetHashCode());
    }
  }
}