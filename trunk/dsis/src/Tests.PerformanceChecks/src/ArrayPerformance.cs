using System;
using System.Collections.Generic;
using NUnit.Framework;

namespace DSIS.PerformanceChecks
{
  [TestFixture]
  public class ArrayPerformance : PerformanceBase
  {
    public interface IFoo
    {
      long this[int i] { get; }
    }

    public class ArrayAsStruct3 : IFoo
    {
      public readonly long l1;
      public readonly long l2;
      public readonly long l3;

      public ArrayAsStruct3(long l1, long l2, long l3)
      {
        this.l1 = l1;
        this.l2 = l2;
        this.l3 = l3;
      }

      public long this[int i]
      {
        get
        {
          switch (i)
          {
            case 0:
              return l1;
            case 1:
              return l2;
            case 2:
              return l3;
            default:
              throw new ArgumentException();
          }
        }
      }

      public ArrayAsStruct3 Clone()
      {
        return new ArrayAsStruct3(l1, l2, l3);
      }
    }

    public class ArrayAsStruct2 : IFoo
    {
      public readonly long l1;
      public readonly long l2;

      public ArrayAsStruct2(long l1, long l2)
      {
        this.l1 = l1;
        this.l2 = l2;
      }

      public long this[int i]
      {
        get
        {
          switch (i)
          {
            case 0:
              return l1;
            case 1:
              return l2;
            default:
              throw new ArgumentException();
          }
        }
      }

      public ArrayAsStruct2 Clone()
      {
        return new ArrayAsStruct2(l1, l2);
      }
    }

    public class ArrayAsArray : IFoo
    {
      public readonly long[] myArray;

      public ArrayAsArray(long[] array)
      {
        myArray = array;
      }


      public long this[int i]
      {
        get { return myArray[i]; }
      }
    }


    [Test]
    public void Test_Arrays_To_List()
    {
      const int MAX = 1000000;

      DoAction("Arrays 3", delegate
                             {
                               var data = new List<IFoo>();
                               for (int i = 0; i < MAX; i++)
                               {
                                 data.Add(new ArrayAsArray(new long[3]));
                               }
                             }, 5);
      DoAction("Structs 3", delegate
                              {
                                var data = new List<IFoo>();
                                for (int i = 0; i < MAX; i++)
                                {
                                  data.Add(new ArrayAsStruct3(1,2,3));
                                }
                              }, 5);
      DoAction("Arrays 2", delegate
                             {
                               var data = new List<IFoo>();
                               for (int i = 0; i < MAX; i++)
                               {
                                 data.Add(new ArrayAsArray(new long[2]));
                               }
                             }, 5);
      DoAction("Structs 2", delegate
                              {
                                var data = new List<IFoo>();
                                for (int i = 0; i < MAX; i++)
                                {
                                  data.Add(new ArrayAsStruct2(1,2));
                                }
                              }, 5);
    }

    [Test]
    public void Test_Arrays_To_List_Memory()
    {
      const int MAX = 1000000;

      DoAction("Arrays 3", delegate
                             {
                               long init = Memory;
                               var data = new List<IFoo>();
                               for (int i = 0; i < MAX; i++)
                               {
                                 data.Add(new ArrayAsArray(new long[3]));
                               }
                               Usage(init);
                               data.Clear();
                             });
      DoAction("Structs 3", delegate
                              {
                                long init = Memory;
                                var data = new List<IFoo>();
                                for (int i = 0; i < MAX; i++)
                                {
                                  data.Add(new ArrayAsStruct3(1,2,3));
                                }
                                Usage(init);
                                data.Clear();
                              });
      DoAction("Arrays 2", delegate
                             {
                               long init = Memory;
                               var data = new List<IFoo>();
                               for (int i = 0; i < MAX; i++)
                               {
                                 data.Add(new ArrayAsArray(new long[2]));
                               }
                               Usage(init);
                               data.Clear();
                             });
      DoAction("Structs 2", delegate
                              {
                                long init = Memory;
                                var data = new List<IFoo>();
                                for (int i = 0; i < MAX; i++)
                                {
                                  data.Add(new ArrayAsStruct2(1,2));
                                }
                                Usage(init);
                                data.Clear();
                              });
    }

    private static void DoAccessTest(string name, int dim, List<IFoo> data)
    {
      long q = 0;
      DoAction(name, delegate
                       {                         
                         foreach (var foo in data)
                         {
                           for (int i = 0; i < dim; i++)
                           {
                             q += foo[i];
                           }
                         }                        
                       }, 15);
    }

    [Test]
    public void Test_Arrays_To_List_Access()
    {
      const int MAX = 10000000;

      {
        var data = new List<IFoo>();
        for (int i = 0; i < MAX; i++)
        {
          data.Add(new ArrayAsArray(new long[3]));
        }
        DoAccessTest("Arrays 3", 3, data);
        data.Clear();
      }

      {
        var data = new List<IFoo>();
        for (int i = 0; i < MAX; i++)
        {
          data.Add(new ArrayAsStruct3(1,2,3));
        }
        DoAccessTest("Struct 3", 3, data);
        data.Clear();
      }
      {
        var data = new List<IFoo>();
        for (int i = 0; i < MAX; i++)
        {
          data.Add(new ArrayAsArray(new long[2]));
        }
        DoAccessTest("Arrays 2", 2, data);
        data.Clear();
      }

      {
        var data = new List<IFoo>();
        for (int i = 0; i < MAX; i++)
        {
          data.Add(new ArrayAsStruct2(1,2));
        }
        DoAccessTest("Struct 2", 2, data);
        data.Clear();
      }
    }

    [Test]
    public void Test_Array_Foreach()
    {
      const int MAX = 1000000;
      DoAction("Foreach ", delegate
                             {
                               List<long[]> data = new List<long[]>();
                               long j = 0;
                               for (int i = 0; i < MAX; i++)
                               {
                                 long[] ls = new long[3];
                                 ls[0] = j++;
                                 ls[1] = j++;
                                 ls[2] = j++;
                                 data.Add(ls);
                               }

                               foreach (long[] longs in data)
                               {
                                 long k = 0;
                                 foreach (long l in longs)
                                 {
                                   k += l;
                                 }
                                 j -= k;
                               }
                             });
      DoAction("for ", delegate
                         {
                           List<long[]> data = new List<long[]>();
                           long j = 0;
                           for (int i = 0; i < MAX; i++)
                           {
                             long[] ls = new long[3];
                             ls[0] = j++;
                             ls[1] = j++;
                             ls[2] = j++;
                             data.Add(ls);
                           }

                           foreach (long[] longs in data)
                           {
                             long k = 0;
                             for (int i = 0; i < longs.Length; i++)
                             {
                               k += longs[i];
                             }
                             j -= k;
                           }
                         });
      DoAction("unchecked for ", delegate
                                   {
                                     List<long[]> data = new List<long[]>();
                                     long j = 0;
                                     for (int i = 0; i < MAX; i++)
                                     {
                                       long[] ls = new long[3];
                                       ls[0] = j++;
                                       ls[1] = j++;
                                       ls[2] = j++;
                                       data.Add(ls);
                                     }

                                     foreach (long[] longs in data)
                                     {
                                       long k = 0;
                                       unchecked
                                       {
                                         for (int i = 0; i < longs.Length; i++)
                                         {
                                           k += longs[i];
                                         }
                                       }
                                       j -= k;
                                     }
                                   });
      DoAction("struct as array ", delegate
                                     {
                                       List<ArrayAsStruct3> data = new List<ArrayAsStruct3>();
                                       long j = 0;
                                       for (int i = 0; i < MAX; i++)
                                       {
                                         ArrayAsStruct3 ass = new ArrayAsStruct3(j++, j++, j++);
                                         data.Add(ass);
                                       }

                                       foreach (ArrayAsStruct3 l in data)
                                       {
                                         j -= l.l1 + l.l2 + l.l3;
                                       }
                                     });

      DoAction("struct as array with indexer ", delegate
                                                  {
                                                    List<ArrayAsStruct3> data = new List<ArrayAsStruct3>();
                                                    long j = 0;
                                                    for (int i = 0; i < MAX; i++)
                                                    {
                                                      ArrayAsStruct3 ass = new ArrayAsStruct3(j++, j++, j++);
                                                      data.Add(ass);
                                                    }

                                                    foreach (ArrayAsStruct3 l in data)
                                                    {
                                                      j -= l[0] + l[1] + l[2];
                                                    }
                                                  });

      DoAction("struct as array with indexer 2", delegate
                                                   {
                                                     List<ArrayAsStruct3> data = new List<ArrayAsStruct3>();
                                                     long j = 0;
                                                     for (int i = 0; i < MAX; i++)
                                                     {
                                                       ArrayAsStruct3 ass = new ArrayAsStruct3(j++, j++, j++);
                                                       data.Add(ass);
                                                     }

                                                     int q = 0;
                                                     foreach (ArrayAsStruct3 l in data)
                                                     {
                                                       j -= l[q++] + l[q++] + l[q++];
                                                       q -= q;
                                                     }
                                                   });
    }

    [Test]
    public void ArrayCloneTest()
    {
      const int MAX = 1000000;
      DoAction("Array clone", delegate
                                {
                                  List<long[]> data = new List<long[]>();
                                  long[] arr = new long[] {1, 4, 6};
                                  for (int i = 0; i < MAX; i++)
                                  {
                                    arr[0] += 1;
                                    arr[1] -= 7;
                                    arr[2] += 7;
                                    data.Add((long[]) arr.Clone());
                                  }
                                });
      DoAction("Struct clone var", delegate
                                     {
                                       List<ArrayAsStruct3> data = new List<ArrayAsStruct3>();
                                       ArrayAsStruct3 ass = new ArrayAsStruct3(1, 2, 4);
                                       for (int i = 0; i < MAX; i++)
                                       {
                                         data.Add(ass.Clone());
                                       }
                                     });
    }
  }
}