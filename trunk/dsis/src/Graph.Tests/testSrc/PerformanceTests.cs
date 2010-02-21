using System;
using System.Runtime.InteropServices;
using DSIS.Graph.Abstract;
using DSIS.IntegerCoordinates.Impl;
using NUnit.Framework;

namespace DSIS.Graph.Tests
{
  [TestFixture]
  public class PerformanceTests
  {
    public class CLongHolder
    {
      private long myField;

      public void update1()
      {
        myField++;
      }

      public bool update2()
      {
        return (++myField ^ (myField - 1)) > 42;
      }
    }

    public struct SLongHolder
    {
      private long myField;

      public void update1()
      {
        myField++;
      }

      public bool update2()
      {
        return (++myField ^ (myField - 1)) > 42;
      }
    }

    public class CHolder
    {
      public readonly CLongHolder Field = new CLongHolder();
    }

    public class SHolder
    {
      public SLongHolder Field;
    }

    private object[] refs;
    protected double MeasureMemory<T>(Func<T> create)
    {
      const int sz = 1000000;

      refs = new object[sz];
      long wasTotalMemory = GC.GetTotalMemory(true);

      for(int i = 0; i < sz; i++)
      {
        refs[i] = create();
      }

      return (double)(GC.GetTotalMemory(true) - wasTotalMemory) / sz;
    }

    [Test]
    public void MeasureMemoryForHolders_Test()
    {
      Console.Out.WriteLine("IntPtr.Size = {0}", IntPtr.Size);
      var classUse = MeasureMemory(() => new CHolder());
      var structUse = MeasureMemory(() => new SHolder());

      Console.Out.WriteLine("structUse = {0}", structUse);
      Console.Out.WriteLine("classUse = {0}", classUse);
    }

    public struct S1
    {
      public readonly Int16 value;
    }

    public struct S2
    {
      public readonly Int16 value;
      public readonly Int16 value2;
    }

    public struct S3
    {
      public readonly Int16 value;
      public readonly Int16 value2;
      public readonly Int16 value3;
    }

    public struct S4
    {
      public readonly Int16 value;
      public readonly Int16 value2;
      public readonly Int16 value3;
      public readonly Int16 value4;
    }

    public struct S8
    {
      public readonly Int16 value;
      public readonly Int16 value2;
      public readonly Int16 value3;
      public readonly Int16 value4;
      public readonly Int16 valueA;
      public readonly Int16 valueA2;
      public readonly Int16 valueA3;
      public readonly Int16 valueA4;
    }

    [Test]
    public void MeasureMemoryForStructs()
    {
      Console.Out.WriteLine("MeasureMemory(()=>new S1()) = {0}", MeasureMemory(()=>new S1()));
      Console.Out.WriteLine("MeasureMemory(() => new S2()) = {0}", MeasureMemory(() => new S2()));
      Console.Out.WriteLine("MeasureMemory(() => new S3()) = {0}", MeasureMemory(() => new S3()));
      Console.Out.WriteLine("MeasureMemory(() => new S4()) = {0}", MeasureMemory(() => new S4()));
      Console.Out.WriteLine("MeasureMemory(() => new S8()) = {0}", MeasureMemory(() => new S8()));

      Console.Out.WriteLine("Marshal.SizeOf(typeof(S1)) = {0}", Marshal.SizeOf(typeof(S1)));
      Console.Out.WriteLine("Marshal.SizeOf(typeof(S2)) = {0}", Marshal.SizeOf(typeof(S2)));
      Console.Out.WriteLine("Marshal.SizeOf(typeof(S3)) = {0}", Marshal.SizeOf(typeof(S3)));
      Console.Out.WriteLine("Marshal.SizeOf(typeof(S4)) = {0}", Marshal.SizeOf(typeof(S4)));
      Console.Out.WriteLine("Marshal.SizeOf(typeof(S8)) = {0}", Marshal.SizeOf(typeof(S8)));
    }

    [Test]
    public void MeasureGraphNode()
    {
      var c = new IntegerCoordinate(1,2,3,45);
      var mem = MeasureMemory(() => new TarjanNode<IntegerCoordinate>(c));

      Console.Out.WriteLine("TarjanNode<IntegerCoordinate> = {0}", mem);
    }
  }
}