using NUnit.Framework;

namespace DSIS.Graph.Morse.Tests
{
  [TestFixture]
  public class  MorseTest : MorseBaseTest
  {
    [Test]
    public void Test_001()
    {
      DoTest(1, delegate(CostContext ctx) { ctx.DefaultCost = 1; ctx.AddEdge(1,1); });
    }
    
    [Test]
    public void Test_002()
    {
      DoTest(1, delegate(CostContext ctx) { ctx.DefaultCost = 1; ctx.AddEdge(1,2);ctx.AddEdge(2,1); });
    }
    
    [Test]
    public void Test_003()
    {
      DoTest(1, delegate(CostContext ctx) { ctx.DefaultCost = 1; ctx.AddEdge(1, 2); ctx.AddEdge(2, 3); ctx.AddEdge(3, 1); });
    }
    
    [Test]
    public void Test_004()
    {
      for (int n = 4; n < 50; n++)
        DoTest(1, delegate(CostContext ctx)
                    {
                      ctx.DefaultCost = 1;
                      int i = 0;
                      for (; i < n; i++ )
                        ctx.AddEdge(i, i+1);
                      ctx.AddEdge(n, 0);
                    });
    }

    [Test]
    public void Test_006()
    {
       DoTest(1.666666666666666, delegate(CostContext ctx)
                    {
                      ctx.DefaultCost = 1;
                      
                      ctx.AddEdge(1, 3);
                      ctx.AddEdge(1, 2);
                      ctx.AddEdge(2, 3);

                      ctx.AddEdge(3, 1);
                      
                      ctx.AddCost(2, 3);
                    });
    }
    
    [Test]
    public void Test_007()
    {
       DoTest(1, delegate(CostContext ctx)
                    {
                      ctx.DefaultCost = 1;
                      
                      ctx.AddEdge(1, 3);
                      ctx.AddEdge(1, 2);
                      ctx.AddEdge(2, 3);

                      ctx.AddEdge(3, 1);
                      
                      ctx.AddCost(2, 0.1);
                    });
    }
    
    [Test, Ignore]
    public void Test_Hung_105()
    {
      DoTest(0, 1.95280889074647d, delegate(CostContext ctx)
                    {
                      ctx.AddCost(0, 1.95280889074647); //[Node: [  0 , 0  ]]
                      ctx.AddCost(1, 0.85419660207836012); //[Node: [  0 , 1  ]]
                      ctx.AddCost(2, 0.34337097831236957); //[Node: [  0 , 2  ]]
                      ctx.AddCost(3, 1.95280889074647); //[Node: [  1 , 0  ]]
                      ctx.AddCost(4, 0.85419660207836012); //[Node: [  1 , 1  ]]
                      ctx.AddCost(5, 0.34337097831236957); //[Node: [  1 , 2  ]]
                      ctx.AddCost(6, 1.95280889074647); //[Node: [  2 , 0  ]]
                      ctx.AddCost(7, 1.95280889074647); //[Node: [  3 , 0  ]]
                      ctx.AddCost(8, 1.95280889074647); //[Node: [  4 , 0  ]]
                      ctx.AddCost(9, 1.95280889074647); //[Node: [  5 , 0  ]]
                      ctx.AddCost(10, -0.24441568658974944); //[Node: [  2 , 4  ]]
                      ctx.AddCost(11, 0.00689874169115659); //[Node: [  0 , 3  ]]
                      ctx.AddCost(12, 0.34337097831236957); //[Node: [  2 , 2  ]]
                      ctx.AddCost(13, 0.00689874169115659); //[Node: [  1 , 3  ]]
                      ctx.AddCost(14, -0.24441568658974944); //[Node: [  0 , 4  ]]
                      ctx.AddCost(15, 0.00689874169115659); //[Node: [  2 , 3  ]]
                      ctx.AddCost(16, -0.24441568658974944); //[Node: [  1 , 4  ]]
                      ctx.AddCost(17, 0.85419660207836012); //[Node: [  2 , 1  ]]
                      ctx.AddCost(18, 1.95280889074647); //[Node: [  6 , 0  ]]
                      ctx.AddCost(19, 1.95280889074647); //[Node: [  7 , 0  ]]
                      ctx.AddCost(20, 1.95280889074647); //[Node: [  8 , 0  ]]
                      ctx.AddCost(21, 0.85419660207836012); //[Node: [  3 , 1  ]]
                      ctx.AddCost(22, 1.95280889074647); //[Node: [  9 , 0  ]]
                      ctx.AddCost(23, 0.85419660207836012); //[Node: [  4 , 1  ]]
                      ctx.AddCost(24, 1.95280889074647); //[Node: [  10 , 0  ]]
                      ctx.AddCost(25, 0.85419660207836012); //[Node: [  5 , 1  ]]
                      ctx.AddCost(26, 1.95280889074647); //[Node: [  11 , 0  ]]
                      ctx.AddCost(27, -0.61214046671506683); //[Node: [  3 , 6  ]]
                      ctx.AddCost(28, -0.44508638205190054); //[Node: [  1 , 5  ]]
                      ctx.AddCost(29, -0.24441568658974944); //[Node: [  3 , 4  ]]
                      ctx.AddCost(30, -0.44508638205190054); //[Node: [  2 , 5  ]]
                      ctx.AddCost(31, -0.61214046671506683); //[Node: [  1 , 6  ]]
                      ctx.AddCost(32, -0.44508638205190054); //[Node: [  3 , 5  ]]
                      ctx.AddCost(33, -0.61214046671506683); //[Node: [  2 , 6  ]]
                      ctx.AddCost(34, 0.00689874169115659); //[Node: [  3 , 3  ]]
                      ctx.AddCost(35, 0.85419660207836012); //[Node: [  6 , 1  ]]
                      ctx.AddCost(36, 1.95280889074647); //[Node: [  12 , 0  ]]
                      ctx.AddCost(37, 0.85419660207836012); //[Node: [  7 , 1  ]]
                      ctx.AddCost(38, 1.95280889074647); //[Node: [  13 , 0  ]]
                      ctx.AddCost(39, 0.34337097831236957); //[Node: [  3 , 2  ]]
                      ctx.AddCost(40, 0.85419660207836012); //[Node: [  8 , 1  ]]
                      ctx.AddCost(41, 1.95280889074647); //[Node: [  14 , 0  ]]
                      ctx.AddCost(42, 1.95280889074647); //[Node: [  15 , 0  ]]
                      ctx.AddCost(43, 0.34337097831236957); //[Node: [  4 , 2  ]]
                      ctx.AddCost(44, 0.34337097831236957); //[Node: [  5 , 2  ]]
                      ctx.AddCost(45, 1.95280889074647); //[Node: [  16 , 0  ]]
                      ctx.AddCost(46, -0.88040445330974626); //[Node: [  4 , 8  ]]
                      ctx.AddCost(47, -0.75524131035574); //[Node: [  2 , 7  ]]
                      ctx.AddCost(48, -0.99163008841997058); //[Node: [  3 , 9  ]]
                      ctx.AddCost(49, -0.61214046671506683); //[Node: [  4 , 6  ]]
                      ctx.AddCost(50, -0.75524131035574); //[Node: [  3 , 7  ]]
                      ctx.AddCost(51, -0.99163008841997058); //[Node: [  4 , 9  ]]
                      ctx.AddCost(52, -0.88040445330974626); //[Node: [  2 , 8  ]]
                      ctx.AddCost(53, -0.75524131035574); //[Node: [  4 , 7  ]]
                      ctx.AddCost(54, -0.88040445330974626); //[Node: [  3 , 8  ]]
                      ctx.AddCost(55, -0.99163008841997058); //[Node: [  2 , 9  ]]
                      ctx.AddCost(56, -0.44508638205190054); //[Node: [  4 , 5  ]]
                      ctx.AddCost(57, 1.95280889074647); //[Node: [  17 , 0  ]]
                      ctx.AddCost(58, 0.34337097831236957); //[Node: [  6 , 2  ]]
                      ctx.AddCost(59, 0.34337097831236957); //[Node: [  7 , 2  ]]
                      ctx.AddCost(60, 1.95280889074647); //[Node: [  18 , 0  ]]
                      ctx.AddCost(61, -0.24441568658974944); //[Node: [  4 , 4  ]]
                      ctx.AddCost(62, 0.34337097831236957); //[Node: [  8 , 2  ]]
                      ctx.AddCost(63, 0.00689874169115659); //[Node: [  4 , 3  ]]
                      ctx.AddCost(64, 0.00689874169115659); //[Node: [  5 , 3  ]]
                      ctx.AddCost(65, -0.88040445330974626); //[Node: [  5 , 8  ]]
                      ctx.AddCost(66, -0.99163008841997058); //[Node: [  5 , 9  ]]
                      ctx.AddCost(67, -0.75524131035574); //[Node: [  5 , 7  ]]
                      ctx.AddCost(68, 0.00689874169115659); //[Node: [  6 , 3  ]]
                      ctx.AddCost(69, -0.61214046671506683); //[Node: [  5 , 6  ]]
                      ctx.AddCost(70, 0.00689874169115659); //[Node: [  7 , 3  ]]
                      ctx.AddCost(71, -0.44508638205190054); //[Node: [  5 , 5  ]]
                      ctx.AddCost(72, 0.00689874169115659); //[Node: [  8 , 3  ]]
                      ctx.AddCost(73, -0.24441568658974944); //[Node: [  5 , 4  ]]
                      ctx.AddCost(74, -0.24441568658974944); //[Node: [  6 , 4  ]]
                      ctx.AddCost(75, -0.88040445330974626); //[Node: [  6 , 8  ]]
                      ctx.AddCost(76, -0.99163008841997058); //[Node: [  6 , 9  ]]
                      ctx.AddCost(77, -0.24441568658974944); //[Node: [  7 , 4  ]]
                      ctx.AddCost(78, -0.75524131035574); //[Node: [  6 , 7  ]]
                      ctx.AddCost(79, -0.61214046671506683); //[Node: [  6 , 6  ]]
                      ctx.AddCost(80, -0.24441568658974944); //[Node: [  8 , 4  ]]
                      ctx.AddCost(81, -0.44508638205190054); //[Node: [  6 , 5  ]]
                      ctx.AddCost(82, -1.2660669341217308); //[Node: [  7 , 12  ]]
                      ctx.AddCost(83, -1.4144869392400041); //[Node: [  7 , 14  ]]
                      ctx.AddCost(84, -1.091713546976953); //[Node: [  7 , 10  ]]
                      ctx.AddCost(85, -1.3430279752578591); //[Node: [  7 , 13  ]]
                      ctx.AddCost(86, -1.1826853251826799); //[Node: [  7 , 11  ]]
                      ctx.AddCost(87, -0.44508638205190054); //[Node: [  7 , 5  ]]
                      ctx.AddCost(88, -0.99163008841997058); //[Node: [  7 , 9  ]]
                      ctx.AddCost(89, -0.88040445330974626); //[Node: [  7 , 8  ]]
                      ctx.AddCost(90, -0.44508638205190054); //[Node: [  8 , 5  ]]
                      ctx.AddCost(91, -0.61214046671506683); //[Node: [  7 , 6  ]]
                      ctx.AddCost(92, -0.75524131035574); //[Node: [  7 , 7  ]]
                      ctx.AddCost(93, -1.1826853251826799); //[Node: [  8 , 11  ]]
                      ctx.AddCost(94, -0.99163008841997058); //[Node: [  8 , 9  ]]
                      ctx.AddCost(95, -1.2660669341217308); //[Node: [  8 , 12  ]]
                      ctx.AddCost(96, -1.091713546976953); //[Node: [  8 , 10  ]]
                      ctx.AddCost(97, -1.3430279752578591); //[Node: [  8 , 13  ]]
                      ctx.AddCost(98, -0.61214046671506683); //[Node: [  8 , 6  ]]
                      ctx.AddCost(99, -0.88040445330974626); //[Node: [  8 , 8  ]]
                      ctx.AddCost(100, -0.75524131035574); //[Node: [  8 , 7  ]]
                      ctx.AddCost(101, -1.4144869392400041); //[Node: [  8 , 14  ]]
                      ctx.AddCost(102, -1.4811783137386765); //[Node: [  7 , 15  ]]
                      ctx.AddCost(103, -1.4811783137386765); //[Node: [  8 , 15  ]]
                      ctx.AddCost(104, -1.5436986707200102); //[Node: [  8 , 16  ]]
                      ctx.AddCost(105, -1.6025391707429437); //[Node: [  8 , 17  ]]

                      ctx.AddEdge(0, 0);
                      ctx.AddEdge(0, 1);
                      ctx.AddEdge(0, 2);
                      ctx.AddEdge(0, 3);
                      ctx.AddEdge(0, 4);
                      ctx.AddEdge(0, 5);
                      ctx.AddEdge(1, 10);
                      ctx.AddEdge(1, 5);
                      ctx.AddEdge(1, 11);
                      ctx.AddEdge(1, 12);
                      ctx.AddEdge(1, 1);
                      ctx.AddEdge(1, 13);
                      ctx.AddEdge(1, 14);
                      ctx.AddEdge(1, 4);
                      ctx.AddEdge(1, 15);
                      ctx.AddEdge(1, 2);
                      ctx.AddEdge(1, 16);
                      ctx.AddEdge(1, 17);
                      ctx.AddEdge(2, 27);
                      ctx.AddEdge(2, 10);
                      ctx.AddEdge(2, 28);
                      ctx.AddEdge(2, 29);
                      ctx.AddEdge(2, 13);
                      ctx.AddEdge(2, 30);
                      ctx.AddEdge(2, 31);
                      ctx.AddEdge(2, 15);
                      ctx.AddEdge(2, 32);
                      ctx.AddEdge(2, 16);
                      ctx.AddEdge(2, 33);
                      ctx.AddEdge(2, 34);
                      ctx.AddEdge(3, 0);
                      ctx.AddEdge(3, 1);
                      ctx.AddEdge(3, 2);
                      ctx.AddEdge(3, 3);
                      ctx.AddEdge(3, 4);
                      ctx.AddEdge(3, 5);
                      ctx.AddEdge(4, 10);
                      ctx.AddEdge(4, 5);
                      ctx.AddEdge(4, 11);
                      ctx.AddEdge(4, 12);
                      ctx.AddEdge(4, 1);
                      ctx.AddEdge(4, 13);
                      ctx.AddEdge(4, 14);
                      ctx.AddEdge(4, 4);
                      ctx.AddEdge(4, 15);
                      ctx.AddEdge(4, 2);
                      ctx.AddEdge(4, 16);
                      ctx.AddEdge(4, 17);
                      ctx.AddEdge(5, 27);
                      ctx.AddEdge(5, 10);
                      ctx.AddEdge(5, 28);
                      ctx.AddEdge(5, 29);
                      ctx.AddEdge(5, 13);
                      ctx.AddEdge(5, 30);
                      ctx.AddEdge(5, 31);
                      ctx.AddEdge(5, 15);
                      ctx.AddEdge(5, 32);
                      ctx.AddEdge(5, 16);
                      ctx.AddEdge(5, 33);
                      ctx.AddEdge(5, 34);
                      ctx.AddEdge(6, 0);
                      ctx.AddEdge(6, 1);
                      ctx.AddEdge(6, 3);
                      ctx.AddEdge(6, 4);
                      ctx.AddEdge(7, 0);
                      ctx.AddEdge(7, 1);
                      ctx.AddEdge(7, 3);
                      ctx.AddEdge(7, 4);
                      ctx.AddEdge(8, 0);
                      ctx.AddEdge(8, 1);
                      ctx.AddEdge(8, 3);
                      ctx.AddEdge(8, 4);
                      ctx.AddEdge(9, 0);
                      ctx.AddEdge(9, 3);
                      ctx.AddEdge(10, 46);
                      ctx.AddEdge(10, 27);
                      ctx.AddEdge(10, 71);
                      ctx.AddEdge(10, 49);
                      ctx.AddEdge(10, 65);
                      ctx.AddEdge(10, 50);
                      ctx.AddEdge(10, 69);
                      ctx.AddEdge(10, 32);
                      ctx.AddEdge(10, 53);
                      ctx.AddEdge(10, 54);
                      ctx.AddEdge(10, 56);
                      ctx.AddEdge(10, 67);
                      ctx.AddEdge(11, 46);
                      ctx.AddEdge(11, 27);
                      ctx.AddEdge(11, 47);
                      ctx.AddEdge(11, 48);
                      ctx.AddEdge(11, 49);
                      ctx.AddEdge(11, 30);
                      ctx.AddEdge(11, 50);
                      ctx.AddEdge(11, 51);
                      ctx.AddEdge(11, 52);
                      ctx.AddEdge(11, 32);
                      ctx.AddEdge(11, 53);
                      ctx.AddEdge(11, 33);
                      ctx.AddEdge(11, 54);
                      ctx.AddEdge(11, 55);
                      ctx.AddEdge(11, 56);
                      ctx.AddEdge(12, 10);
                      ctx.AddEdge(12, 5);
                      ctx.AddEdge(12, 28);
                      ctx.AddEdge(12, 12);
                      ctx.AddEdge(12, 29);
                      ctx.AddEdge(12, 13);
                      ctx.AddEdge(12, 30);
                      ctx.AddEdge(12, 39);
                      ctx.AddEdge(12, 15);
                      ctx.AddEdge(12, 32);
                      ctx.AddEdge(12, 16);
                      ctx.AddEdge(12, 34);
                      ctx.AddEdge(13, 46);
                      ctx.AddEdge(13, 27);
                      ctx.AddEdge(13, 47);
                      ctx.AddEdge(13, 49);
                      ctx.AddEdge(13, 30);
                      ctx.AddEdge(13, 50);
                      ctx.AddEdge(13, 52);
                      ctx.AddEdge(13, 32);
                      ctx.AddEdge(13, 53);
                      ctx.AddEdge(13, 33);
                      ctx.AddEdge(13, 54);
                      ctx.AddEdge(13, 56);
                      ctx.AddEdge(14, 46);
                      ctx.AddEdge(14, 48);
                      ctx.AddEdge(14, 65);
                      ctx.AddEdge(14, 50);
                      ctx.AddEdge(14, 51);
                      ctx.AddEdge(14, 53);
                      ctx.AddEdge(14, 66);
                      ctx.AddEdge(14, 54);
                      ctx.AddEdge(14, 67);
                      ctx.AddEdge(15, 27);
                      ctx.AddEdge(15, 10);
                      ctx.AddEdge(15, 29);
                      ctx.AddEdge(15, 49);
                      ctx.AddEdge(15, 30);
                      ctx.AddEdge(15, 61);
                      ctx.AddEdge(15, 32);
                      ctx.AddEdge(15, 33);
                      ctx.AddEdge(15, 56);
                      ctx.AddEdge(16, 46);
                      ctx.AddEdge(16, 27);
                      ctx.AddEdge(16, 48);
                      ctx.AddEdge(16, 49);
                      ctx.AddEdge(16, 65);
                      ctx.AddEdge(16, 50);
                      ctx.AddEdge(16, 51);
                      ctx.AddEdge(16, 69);
                      ctx.AddEdge(16, 53);
                      ctx.AddEdge(16, 66);
                      ctx.AddEdge(16, 54);
                      ctx.AddEdge(16, 67);
                      ctx.AddEdge(17, 5);
                      ctx.AddEdge(17, 11);
                      ctx.AddEdge(17, 12);
                      ctx.AddEdge(17, 1);
                      ctx.AddEdge(17, 13);
                      ctx.AddEdge(17, 4);
                      ctx.AddEdge(17, 15);
                      ctx.AddEdge(17, 2);
                      ctx.AddEdge(17, 17);
                      ctx.AddEdge(18, 0);
                      ctx.AddEdge(18, 3);
                      ctx.AddEdge(19, 0);
                      ctx.AddEdge(19, 3);
                      ctx.AddEdge(20, 0);
                      ctx.AddEdge(20, 3);
                      ctx.AddEdge(21, 1);
                      ctx.AddEdge(21, 2);
                      ctx.AddEdge(21, 4);
                      ctx.AddEdge(21, 5);
                      ctx.AddEdge(21, 17);
                      ctx.AddEdge(21, 12);
                      ctx.AddEdge(22, 0);
                      ctx.AddEdge(22, 3);
                      ctx.AddEdge(23, 5);
                      ctx.AddEdge(23, 0);
                      ctx.AddEdge(23, 3);
                      ctx.AddEdge(23, 12);
                      ctx.AddEdge(23, 1);
                      ctx.AddEdge(23, 6);
                      ctx.AddEdge(23, 4);
                      ctx.AddEdge(23, 2);
                      ctx.AddEdge(23, 17);
                      ctx.AddEdge(24, 0);
                      ctx.AddEdge(24, 3);
                      ctx.AddEdge(25, 0);
                      ctx.AddEdge(25, 1);
                      ctx.AddEdge(25, 3);
                      ctx.AddEdge(25, 4);
                      ctx.AddEdge(25, 6);
                      ctx.AddEdge(25, 17);
                      ctx.AddEdge(26, 0);
                      ctx.AddEdge(26, 3);
                      ctx.AddEdge(27, 91);
                      ctx.AddEdge(27, 78);
                      ctx.AddEdge(27, 88);
                      ctx.AddEdge(27, 65);
                      ctx.AddEdge(27, 92);
                      ctx.AddEdge(27, 69);
                      ctx.AddEdge(27, 75);
                      ctx.AddEdge(27, 84);
                      ctx.AddEdge(27, 66);
                      ctx.AddEdge(27, 79);
                      ctx.AddEdge(27, 89);
                      ctx.AddEdge(27, 67);
                      ctx.AddEdge(27, 76);
                      ctx.AddEdge(28, 65);
                      ctx.AddEdge(28, 46);
                      ctx.AddEdge(28, 51);
                      ctx.AddEdge(28, 75);
                      ctx.AddEdge(28, 66);
                      ctx.AddEdge(28, 76);
                      ctx.AddEdge(29, 27);
                      ctx.AddEdge(29, 71);
                      ctx.AddEdge(29, 29);
                      ctx.AddEdge(29, 49);
                      ctx.AddEdge(29, 50);
                      ctx.AddEdge(29, 61);
                      ctx.AddEdge(29, 69);
                      ctx.AddEdge(29, 32);
                      ctx.AddEdge(29, 53);
                      ctx.AddEdge(29, 73);
                      ctx.AddEdge(29, 56);
                      ctx.AddEdge(29, 67);
                      ctx.AddEdge(30, 46);
                      ctx.AddEdge(30, 78);
                      ctx.AddEdge(30, 49);
                      ctx.AddEdge(30, 65);
                      ctx.AddEdge(30, 51);
                      ctx.AddEdge(30, 69);
                      ctx.AddEdge(30, 75);
                      ctx.AddEdge(30, 53);
                      ctx.AddEdge(30, 66);
                      ctx.AddEdge(30, 79);
                      ctx.AddEdge(30, 67);
                      ctx.AddEdge(30, 76);
                      ctx.AddEdge(31, 82);
                      ctx.AddEdge(31, 83);
                      ctx.AddEdge(31, 84);
                      ctx.AddEdge(31, 85);
                      ctx.AddEdge(31, 86);
                      ctx.AddEdge(32, 46);
                      ctx.AddEdge(32, 71);
                      ctx.AddEdge(32, 78);
                      ctx.AddEdge(32, 49);
                      ctx.AddEdge(32, 65);
                      ctx.AddEdge(32, 81);
                      ctx.AddEdge(32, 69);
                      ctx.AddEdge(32, 75);
                      ctx.AddEdge(32, 53);
                      ctx.AddEdge(32, 79);
                      ctx.AddEdge(32, 56);
                      ctx.AddEdge(32, 67);
                      ctx.AddEdge(33, 88);
                      ctx.AddEdge(33, 65);
                      ctx.AddEdge(33, 82);
                      ctx.AddEdge(33, 75);
                      ctx.AddEdge(33, 84);
                      ctx.AddEdge(33, 66);
                      ctx.AddEdge(33, 89);
                      ctx.AddEdge(33, 76);
                      ctx.AddEdge(33, 86);
                      ctx.AddEdge(34, 10);
                      ctx.AddEdge(34, 63);
                      ctx.AddEdge(34, 29);
                      ctx.AddEdge(34, 30);
                      ctx.AddEdge(34, 61);
                      ctx.AddEdge(34, 15);
                      ctx.AddEdge(34, 32);
                      ctx.AddEdge(34, 34);
                      ctx.AddEdge(34, 56);
                      ctx.AddEdge(35, 0);
                      ctx.AddEdge(35, 1);
                      ctx.AddEdge(35, 3);
                      ctx.AddEdge(35, 4);
                      ctx.AddEdge(35, 6);
                      ctx.AddEdge(35, 17);
                      ctx.AddEdge(36, 0);
                      ctx.AddEdge(36, 3);
                      ctx.AddEdge(37, 0);
                      ctx.AddEdge(37, 3);
                      ctx.AddEdge(37, 6);
                      ctx.AddEdge(38, 0);
                      ctx.AddEdge(38, 3);
                      ctx.AddEdge(39, 10);
                      ctx.AddEdge(39, 5);
                      ctx.AddEdge(39, 12);
                      ctx.AddEdge(39, 29);
                      ctx.AddEdge(39, 13);
                      ctx.AddEdge(39, 39);
                      ctx.AddEdge(39, 15);
                      ctx.AddEdge(39, 16);
                      ctx.AddEdge(39, 34);
                      ctx.AddEdge(40, 0);
                      ctx.AddEdge(40, 3);
                      ctx.AddEdge(40, 6);
                      ctx.AddEdge(41, 0);
                      ctx.AddEdge(41, 3);
                      ctx.AddEdge(42, 0);
                      ctx.AddEdge(42, 3);
                      ctx.AddEdge(43, 5);
                      ctx.AddEdge(43, 21);
                      ctx.AddEdge(43, 12);
                      ctx.AddEdge(43, 13);
                      ctx.AddEdge(43, 39);
                      ctx.AddEdge(43, 4);
                      ctx.AddEdge(43, 15);
                      ctx.AddEdge(43, 17);
                      ctx.AddEdge(43, 34);
                      ctx.AddEdge(44, 4);
                      ctx.AddEdge(44, 5);
                      ctx.AddEdge(44, 17);
                      ctx.AddEdge(44, 12);
                      ctx.AddEdge(44, 21);
                      ctx.AddEdge(44, 39);
                      ctx.AddEdge(45, 0);
                      ctx.AddEdge(45, 3);
                      ctx.AddEdge(46, 99);
                      ctx.AddEdge(46, 91);
                      ctx.AddEdge(46, 88);
                      ctx.AddEdge(46, 98);
                      ctx.AddEdge(46, 92);
                      ctx.AddEdge(46, 94);
                      ctx.AddEdge(46, 84);
                      ctx.AddEdge(46, 100);
                      ctx.AddEdge(46, 89);
                      ctx.AddEdge(46, 96);
                      ctx.AddEdge(47, 93);
                      ctx.AddEdge(47, 88);
                      ctx.AddEdge(47, 82);
                      ctx.AddEdge(47, 94);
                      ctx.AddEdge(47, 84);
                      ctx.AddEdge(47, 95);
                      ctx.AddEdge(47, 85);
                      ctx.AddEdge(47, 96);
                      ctx.AddEdge(47, 76);
                      ctx.AddEdge(47, 86);
                      ctx.AddEdge(47, 97);
                      ctx.AddEdge(48, 101);
                      ctx.AddEdge(48, 93);
                      ctx.AddEdge(48, 95);
                      ctx.AddEdge(48, 96);
                      ctx.AddEdge(48, 97);
                      ctx.AddEdge(49, 91);
                      ctx.AddEdge(49, 71);
                      ctx.AddEdge(49, 78);
                      ctx.AddEdge(49, 65);
                      ctx.AddEdge(49, 81);
                      ctx.AddEdge(49, 92);
                      ctx.AddEdge(49, 69);
                      ctx.AddEdge(49, 75);
                      ctx.AddEdge(49, 87);
                      ctx.AddEdge(49, 79);
                      ctx.AddEdge(49, 89);
                      ctx.AddEdge(49, 67);
                      ctx.AddEdge(50, 99);
                      ctx.AddEdge(50, 78);
                      ctx.AddEdge(50, 88);
                      ctx.AddEdge(50, 93);
                      ctx.AddEdge(50, 92);
                      ctx.AddEdge(50, 94);
                      ctx.AddEdge(50, 75);
                      ctx.AddEdge(50, 84);
                      ctx.AddEdge(50, 100);
                      ctx.AddEdge(50, 89);
                      ctx.AddEdge(50, 96);
                      ctx.AddEdge(50, 76);
                      ctx.AddEdge(50, 86);
                      ctx.AddEdge(51, 93);
                      ctx.AddEdge(51, 99);
                      ctx.AddEdge(51, 94);
                      ctx.AddEdge(51, 100);
                      ctx.AddEdge(51, 96);
                      ctx.AddEdge(52, 83);
                      ctx.AddEdge(52, 93);
                      ctx.AddEdge(52, 82);
                      ctx.AddEdge(52, 101);
                      ctx.AddEdge(52, 102);
                      ctx.AddEdge(52, 95);
                      ctx.AddEdge(52, 85);
                      ctx.AddEdge(52, 103);
                      ctx.AddEdge(52, 86);
                      ctx.AddEdge(52, 97);
                      ctx.AddEdge(53, 99);
                      ctx.AddEdge(53, 91);
                      ctx.AddEdge(53, 78);
                      ctx.AddEdge(53, 88);
                      ctx.AddEdge(53, 98);
                      ctx.AddEdge(53, 81);
                      ctx.AddEdge(53, 92);
                      ctx.AddEdge(53, 94);
                      ctx.AddEdge(53, 75);
                      ctx.AddEdge(53, 87);
                      ctx.AddEdge(53, 100);
                      ctx.AddEdge(53, 79);
                      ctx.AddEdge(53, 89);
                      ctx.AddEdge(53, 76);
                      ctx.AddEdge(53, 90);
                      ctx.AddEdge(54, 99);
                      ctx.AddEdge(54, 88);
                      ctx.AddEdge(54, 93);
                      ctx.AddEdge(54, 82);
                      ctx.AddEdge(54, 94);
                      ctx.AddEdge(54, 84);
                      ctx.AddEdge(54, 95);
                      ctx.AddEdge(54, 89);
                      ctx.AddEdge(54, 96);
                      ctx.AddEdge(54, 86);
                      ctx.AddEdge(55, 101);
                      ctx.AddEdge(55, 104);
                      ctx.AddEdge(55, 105);
                      ctx.AddEdge(55, 95);
                      ctx.AddEdge(55, 103);
                      ctx.AddEdge(55, 97);
                      ctx.AddEdge(56, 74);
                      ctx.AddEdge(56, 71);
                      ctx.AddEdge(56, 49);
                      ctx.AddEdge(56, 81);
                      ctx.AddEdge(56, 61);
                      ctx.AddEdge(56, 69);
                      ctx.AddEdge(56, 73);
                      ctx.AddEdge(56, 79);
                      ctx.AddEdge(56, 56);
                      ctx.AddEdge(57, 0);
                      ctx.AddEdge(57, 3);
                      ctx.AddEdge(58, 3);
                      ctx.AddEdge(58, 4);
                      ctx.AddEdge(58, 6);
                      ctx.AddEdge(58, 17);
                      ctx.AddEdge(58, 7);
                      ctx.AddEdge(58, 21);
                      ctx.AddEdge(59, 3);
                      ctx.AddEdge(59, 6);
                      ctx.AddEdge(59, 7);
                      ctx.AddEdge(60, 0);
                      ctx.AddEdge(60, 3);
                      ctx.AddEdge(61, 71);
                      ctx.AddEdge(61, 63);
                      ctx.AddEdge(61, 29);
                      ctx.AddEdge(61, 64);
                      ctx.AddEdge(61, 61);
                      ctx.AddEdge(61, 32);
                      ctx.AddEdge(61, 73);
                      ctx.AddEdge(61, 34);
                      ctx.AddEdge(61, 56);
                      ctx.AddEdge(62, 3);
                      ctx.AddEdge(62, 6);
                      ctx.AddEdge(62, 7);
                      ctx.AddEdge(63, 10);
                      ctx.AddEdge(63, 63);
                      ctx.AddEdge(63, 12);
                      ctx.AddEdge(63, 29);
                      ctx.AddEdge(63, 39);
                      ctx.AddEdge(63, 61);
                      ctx.AddEdge(63, 15);
                      ctx.AddEdge(63, 43);
                      ctx.AddEdge(63, 34);
                      ctx.AddEdge(64, 63);
                      ctx.AddEdge(64, 21);
                      ctx.AddEdge(64, 12);
                      ctx.AddEdge(64, 23);
                      ctx.AddEdge(64, 39);
                      ctx.AddEdge(64, 15);
                      ctx.AddEdge(64, 43);
                      ctx.AddEdge(64, 17);
                      ctx.AddEdge(64, 34);
                      ctx.AddEdge(65, 98);
                      ctx.AddEdge(65, 91);
                      ctx.AddEdge(65, 77);
                      ctx.AddEdge(65, 92);
                      ctx.AddEdge(65, 80);
                      ctx.AddEdge(65, 100);
                      ctx.AddEdge(65, 87);
                      ctx.AddEdge(65, 90);
                      ctx.AddEdge(66, 98);
                      ctx.AddEdge(66, 99);
                      ctx.AddEdge(66, 100);
                      ctx.AddEdge(66, 90);
                      ctx.AddEdge(67, 91);
                      ctx.AddEdge(67, 74);
                      ctx.AddEdge(67, 72);
                      ctx.AddEdge(67, 77);
                      ctx.AddEdge(67, 98);
                      ctx.AddEdge(67, 81);
                      ctx.AddEdge(67, 80);
                      ctx.AddEdge(67, 68);
                      ctx.AddEdge(67, 87);
                      ctx.AddEdge(67, 79);
                      ctx.AddEdge(67, 70);
                      ctx.AddEdge(67, 90);
                      ctx.AddEdge(68, 8);
                      ctx.AddEdge(68, 21);
                      ctx.AddEdge(68, 12);
                      ctx.AddEdge(68, 23);
                      ctx.AddEdge(68, 6);
                      ctx.AddEdge(68, 39);
                      ctx.AddEdge(68, 7);
                      ctx.AddEdge(68, 43);
                      ctx.AddEdge(68, 17);
                      ctx.AddEdge(69, 91);
                      ctx.AddEdge(69, 74);
                      ctx.AddEdge(69, 71);
                      ctx.AddEdge(69, 77);
                      ctx.AddEdge(69, 64);
                      ctx.AddEdge(69, 81);
                      ctx.AddEdge(69, 69);
                      ctx.AddEdge(69, 68);
                      ctx.AddEdge(69, 87);
                      ctx.AddEdge(69, 73);
                      ctx.AddEdge(69, 79);
                      ctx.AddEdge(69, 70);
                      ctx.AddEdge(70, 6);
                      ctx.AddEdge(70, 17);
                      ctx.AddEdge(70, 7);
                      ctx.AddEdge(70, 21);
                      ctx.AddEdge(70, 8);
                      ctx.AddEdge(70, 23);
                      ctx.AddEdge(71, 74);
                      ctx.AddEdge(71, 44);
                      ctx.AddEdge(71, 63);
                      ctx.AddEdge(71, 71);
                      ctx.AddEdge(71, 58);
                      ctx.AddEdge(71, 64);
                      ctx.AddEdge(71, 81);
                      ctx.AddEdge(71, 61);
                      ctx.AddEdge(71, 68);
                      ctx.AddEdge(71, 43);
                      ctx.AddEdge(71, 73);
                      ctx.AddEdge(71, 56);
                      ctx.AddEdge(72, 6);
                      ctx.AddEdge(72, 7);
                      ctx.AddEdge(72, 8);
                      ctx.AddEdge(73, 44);
                      ctx.AddEdge(73, 63);
                      ctx.AddEdge(73, 29);
                      ctx.AddEdge(73, 64);
                      ctx.AddEdge(73, 39);
                      ctx.AddEdge(73, 61);
                      ctx.AddEdge(73, 43);
                      ctx.AddEdge(73, 73);
                      ctx.AddEdge(73, 34);
                      ctx.AddEdge(74, 21);
                      ctx.AddEdge(74, 39);
                      ctx.AddEdge(74, 23);
                      ctx.AddEdge(74, 43);
                      ctx.AddEdge(74, 25);
                      ctx.AddEdge(74, 44);
                      ctx.AddEdge(75, 77);
                      ctx.AddEdge(75, 72);
                      ctx.AddEdge(75, 80);
                      ctx.AddEdge(75, 59);
                      ctx.AddEdge(75, 87);
                      ctx.AddEdge(75, 62);
                      ctx.AddEdge(75, 90);
                      ctx.AddEdge(75, 70);
                      ctx.AddEdge(76, 80);
                      ctx.AddEdge(76, 72);
                      ctx.AddEdge(76, 62);
                      ctx.AddEdge(76, 90);
                      ctx.AddEdge(77, 7);
                      ctx.AddEdge(77, 21);
                      ctx.AddEdge(77, 8);
                      ctx.AddEdge(77, 23);
                      ctx.AddEdge(77, 9);
                      ctx.AddEdge(77, 25);
                      ctx.AddEdge(78, 74);
                      ctx.AddEdge(78, 37);
                      ctx.AddEdge(78, 72);
                      ctx.AddEdge(78, 58);
                      ctx.AddEdge(78, 77);
                      ctx.AddEdge(78, 40);
                      ctx.AddEdge(78, 59);
                      ctx.AddEdge(78, 80);
                      ctx.AddEdge(78, 68);
                      ctx.AddEdge(78, 62);
                      ctx.AddEdge(78, 35);
                      ctx.AddEdge(78, 70);
                      ctx.AddEdge(79, 74);
                      ctx.AddEdge(79, 44);
                      ctx.AddEdge(79, 37);
                      ctx.AddEdge(79, 58);
                      ctx.AddEdge(79, 77);
                      ctx.AddEdge(79, 64);
                      ctx.AddEdge(79, 59);
                      ctx.AddEdge(79, 25);
                      ctx.AddEdge(79, 68);
                      ctx.AddEdge(79, 73);
                      ctx.AddEdge(79, 35);
                      ctx.AddEdge(79, 70);
                      ctx.AddEdge(80, 7);
                      ctx.AddEdge(80, 8);
                      ctx.AddEdge(80, 9);
                      ctx.AddEdge(81, 44);
                      ctx.AddEdge(81, 63);
                      ctx.AddEdge(81, 58);
                      ctx.AddEdge(81, 23);
                      ctx.AddEdge(81, 64);
                      ctx.AddEdge(81, 25);
                      ctx.AddEdge(81, 68);
                      ctx.AddEdge(81, 43);
                      ctx.AddEdge(81, 35);
                      ctx.AddEdge(82, 38);
                      ctx.AddEdge(82, 36);
                      ctx.AddEdge(82, 26);
                      ctx.AddEdge(83, 41);
                      ctx.AddEdge(83, 38);
                      ctx.AddEdge(83, 42);
                      ctx.AddEdge(84, 24);
                      ctx.AddEdge(84, 22);
                      ctx.AddEdge(84, 26);
                      ctx.AddEdge(85, 38);
                      ctx.AddEdge(85, 36);
                      ctx.AddEdge(85, 41);
                      ctx.AddEdge(86, 24);
                      ctx.AddEdge(86, 36);
                      ctx.AddEdge(86, 26);
                      ctx.AddEdge(87, 8);
                      ctx.AddEdge(87, 23);
                      ctx.AddEdge(87, 9);
                      ctx.AddEdge(87, 25);
                      ctx.AddEdge(87, 18);
                      ctx.AddEdge(87, 35);
                      ctx.AddEdge(88, 22);
                      ctx.AddEdge(88, 20);
                      ctx.AddEdge(88, 40);
                      ctx.AddEdge(88, 24);
                      ctx.AddEdge(88, 62);
                      ctx.AddEdge(89, 37);
                      ctx.AddEdge(89, 20);
                      ctx.AddEdge(89, 22);
                      ctx.AddEdge(89, 40);
                      ctx.AddEdge(89, 59);
                      ctx.AddEdge(89, 62);
                      ctx.AddEdge(89, 19);
                      ctx.AddEdge(90, 8);
                      ctx.AddEdge(90, 9);
                      ctx.AddEdge(90, 18);
                      ctx.AddEdge(91, 44);
                      ctx.AddEdge(91, 37);
                      ctx.AddEdge(91, 9);
                      ctx.AddEdge(91, 58);
                      ctx.AddEdge(91, 18);
                      ctx.AddEdge(91, 59);
                      ctx.AddEdge(91, 25);
                      ctx.AddEdge(91, 19);
                      ctx.AddEdge(91, 35);
                      ctx.AddEdge(92, 20);
                      ctx.AddEdge(92, 37);
                      ctx.AddEdge(92, 58);
                      ctx.AddEdge(92, 40);
                      ctx.AddEdge(92, 18);
                      ctx.AddEdge(92, 59);
                      ctx.AddEdge(92, 19);
                      ctx.AddEdge(92, 62);
                      ctx.AddEdge(92, 35);
                      ctx.AddEdge(93, 24);
                      ctx.AddEdge(93, 26);
                      ctx.AddEdge(93, 36);
                      ctx.AddEdge(94, 20);
                      ctx.AddEdge(94, 22);
                      ctx.AddEdge(94, 24);
                      ctx.AddEdge(95, 26);
                      ctx.AddEdge(95, 36);
                      ctx.AddEdge(95, 38);
                      ctx.AddEdge(96, 22);
                      ctx.AddEdge(96, 24);
                      ctx.AddEdge(96, 26);
                      ctx.AddEdge(97, 36);
                      ctx.AddEdge(97, 38);
                      ctx.AddEdge(97, 41);
                      ctx.AddEdge(98, 9);
                      ctx.AddEdge(98, 18);
                      ctx.AddEdge(98, 19);
                      ctx.AddEdge(99, 19);
                      ctx.AddEdge(99, 20);
                      ctx.AddEdge(99, 22);
                      ctx.AddEdge(100, 18);
                      ctx.AddEdge(100, 19);
                      ctx.AddEdge(100, 20);
                      ctx.AddEdge(101, 38);
                      ctx.AddEdge(101, 41);
                      ctx.AddEdge(101, 42);
                      ctx.AddEdge(102, 41);
                      ctx.AddEdge(102, 45);
                      ctx.AddEdge(102, 42);
                      ctx.AddEdge(103, 41);
                      ctx.AddEdge(103, 42);
                      ctx.AddEdge(103, 45);
                      ctx.AddEdge(104, 42);
                      ctx.AddEdge(104, 45);
                      ctx.AddEdge(104, 57);
                      ctx.AddEdge(105, 45);
                      ctx.AddEdge(105, 57);
                      ctx.AddEdge(105, 60);

                      
                    });
    }
  }
}