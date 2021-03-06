﻿using DSIS.CellImageBuilder.BoxMethod;
using DSIS.CellImageBuilder.Shared;
using DSIS.IntegerCoordinates;
using DSIS.IntegerCoordinates.Tests;
using NUnit.Framework;

namespace DSIS.CellImageBuilder.Tests
{
  public abstract class BoxMethodBaseTest<T,Q> :
    MethodTestBase<T, Q, BoxMethod<Q>, BoxMethodSettings>
    where T : IIntegerCoordinateSystem<Q>
    where Q : IIntegerCoordinate
  {
    private static BoxMethodSettings GetBoxMethodDefaultSettings()
    {
      return new BoxMethodSettings { Eps = 0.1 };
    }


    [Test]
    public void Test_02()
    {
      var stategy = GetBoxMethodDefaultSettings();

      var ss = new MockSystemSpace(2, new double[] {0, 0}, new double[] {10, 10}, new long[] {10, 10});
      T ics = CreateCoordinateSystem(ss);

      DoTwoDimTest(ics, ics.Create(5, 5),
                   delegate(double[] ins, double[] outs)
                     {
                       outs[0] = ins[0];
                       outs[1] = ins[1];
                     }, stategy,
                   @"-------------------
                      ..........
                      ..........
                      ..........
                      ..........
                      ....xxx...
                      ....xxx...
                      ....xxx...
                      ..........
                      ..........
                      ..........
                      -------------------
                      ");
    }

    protected T CreateCoordinateSystem(MockSystemSpace ss)
    {
      return IntegerCoordinateSystemFactory.CreateCoordinateSystem<T,Q>(ss);
    }

    [Test]
    public void Test_03()
    {
      var stategy = GetBoxMethodDefaultSettings();

      var ss = new MockSystemSpace(2, new double[] {0, 0}, new double[] {10, 10}, new long[] {10, 10});
      T ics = CreateCoordinateSystem(ss);


      DoTwoDimTest(ics, ics.Create(5, 5),
                   delegate(double[] ins, double[] outs)
                     {
                       outs[0] = 5;
                       outs[1] = 5;
                     }, stategy,
                   @"-------------------
                      ..........
                      ..........
                      ..........
                      ..........
                      ....xx....
                      ....xx....
                      ..........
                      ..........
                      ..........
                      ..........
                      -------------------
                      ");
    }

    [Test]
    public void Test_04()
    {
      var stategy = GetBoxMethodDefaultSettings();

      var ss = new MockSystemSpace(2, new double[] {0, 0}, new double[] {10, 10}, new long[] {10, 10});
      T ics = CreateCoordinateSystem(ss);


      DoTwoDimTest(ics, ics.Create(2, 2),
                   delegate(double[] ins, double[] outs)
                     {
                       outs[0] = 2*ins[0];
                       outs[1] = 2*ins[1];
                     }, stategy,
                   @"-------------------
                      ..........
                      ..........
                      ..........
                      ...xxxx...
                      ...xxxx...
                      ...xxxx...
                      ...xxxx...
                      ..........
                      ..........
                      ..........
                      -------------------
                      ");
    }

    [Test]
    public void Test_05()
    {
      var stategy = GetBoxMethodDefaultSettings();

      var ss = new MockSystemSpace(2, new double[] {0, 0}, new double[] {10, 10}, new long[] {10, 10});
      T ics = CreateCoordinateSystem(ss);


      DoTwoDimTest(ics, ics.Create(1, 1),
                   delegate(double[] ins, double[] outs)
                     {
                       outs[0] = 0.1*ins[0];
                       outs[1] = 7*ins[1];
                     }, stategy,
                   @"-------------------
                      ......xxxx
                      ..........
                      ..........
                      ..........
                      ..........
                      ..........
                      ..........
                      ..........
                      ..........
                      ..........
                      -------------------
                      ");
    }

    [Test]
    public void Test_06()
    {
      var stategy = GetBoxMethodDefaultSettings();

      var ss = new MockSystemSpace(2, new double[] {0, 0}, new double[] {10, 10}, new long[] {10, 10});
      T ics = CreateCoordinateSystem(ss);


      DoTwoDimTest(ics, ics.Create(1, 1),
                   delegate(double[] ins, double[] outs)
                     {
                       outs[0] = 3 + 0.1*ins[0];
                       outs[1] = 7*ins[1] - 2;
                     }, stategy,
                   @"-------------------
                      ..........
                      ..........
                      ..........
                      ....xxxxxx
                      ..........
                      ..........
                      ..........
                      ..........
                      ..........
                      ..........
                      -------------------
                      ");
    }

    [Test]
    public void Test_07()
    {
      var stategy = GetBoxMethodDefaultSettings();

      var ss = new MockSystemSpace(2, new double[] {0, 0}, new double[] {10, 10}, new long[] {10, 10});
      T ics = CreateCoordinateSystem(ss);


      DoTwoDimTest(ics, ics.Create(1, 1),
                   delegate(double[] ins, double[] outs)
                     {
                       outs[0] = 3.45 + 0.001*ins[0];
                       outs[1] = 0.001*ins[1] + 2.66;
                     }, stategy,
                   @"-------------------
                      ..........
                      ..........
                      ..........
                      ..x.......
                      ..........
                      ..........
                      ..........
                      ..........
                      ..........
                      ..........
                      -------------------
                      ");
    }
  }
}