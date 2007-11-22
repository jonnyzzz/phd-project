using System;
using System.Collections.Generic;
using DSIS.BoxIterators;
using DSIS.BoxIterators.Generator;
using NUnit.Framework;

namespace DSIS.PerformanceChecks
{
  [TestFixture]
  public class ArrayPerformance : PerformanceBase
  {
    public struct ArrayAsStruct
    {
      public long l1;
      public long l2;
      public long l3;

      public ArrayAsStruct(long l1, long l2, long l3)
      {
        this.l1 = l1;
        this.l2 = l2;
        this.l3 = l3;
      }

      public long this[int i]
      {
        get { switch(i)
        {
          case 0:
            return l1;
          case 1:
            return l2;
          case 2:
            return l3;
          default:
            throw new ArgumentException();
        }}
      }

      public ArrayAsStruct Clone()
      {
        return new ArrayAsStruct(l1, l2, l3);
      }
    }

    [Test]
    public void Test_Arrays_To_List()
    {
      const int MAX = 1000000;

      DoAction("Arrays ", delegate
                            {
                              List<long[]> data = new List<long[]>();
                              for (int i = 0; i < MAX; i++)
                              {
                                data.Add(new long[3]);
                              }
                            });
      DoAction("Structs ", delegate
                             {
                               List<ArrayAsStruct> data = new List<ArrayAsStruct>();
                               for (int i = 0; i < MAX; i++)
                               {
                                 data.Add(new ArrayAsStruct());
                               }
                             });
    }


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
                                     List<ArrayAsStruct> data = new List<ArrayAsStruct>();
                                     long j = 0;
                                     for (int i = 0; i < MAX; i++)
                                     {
                                       ArrayAsStruct ass = new ArrayAsStruct(j++, j++, j++);
                                       data.Add(ass);
                                     }

                                     foreach (ArrayAsStruct l in data)
                                     {
                                       j -= l.l1 + l.l2 + l.l3;
                                     }
                                   });

      DoAction("struct as array with indexer ", delegate
                                   {
                                     List<ArrayAsStruct> data = new List<ArrayAsStruct>();
                                     long j = 0;
                                     for (int i = 0; i < MAX; i++)
                                     {
                                       ArrayAsStruct ass = new ArrayAsStruct(j++, j++, j++);
                                       data.Add(ass);
                                     }

                                     foreach (ArrayAsStruct l in data)
                                     {
                                       j -= l[0] + l[1] + l[2];
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
      DoAction("Struct clone", delegate
                                {
                                  List<ArrayAsStruct> data = new List<ArrayAsStruct>();
                                  ArrayAsStruct ass = new ArrayAsStruct(1,2,4);
                                  for (int i = 0; i < MAX; i++)
                                  {
                                    ass.l1 += 1;
                                    ass.l2 -= 7;
                                    ass.l3 += 7;
                                    data.Add(ass.Clone());
                                  }
                                });      
    }
  }
}